//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static core;
    using static Root;

    [CmdDispatcher]
    public partial class GlobalCommands : AppCmdService<GlobalCommands,CmdShellState>, ICmdDispatcher
    {
        CmdDispatcher Dispatcher;

        public GlobalCommands()
        {
        }

        T Service<T>(Func<T> factory)
            => (T)ServiceCache.GetOrAdd(typeof(T), key => factory());

        ConcurrentDictionary<Type,object> ServiceCache {get;}
            = new();

        protected override void Initialized()
        {
            Dispatcher = CmdDispatcher.discover(this);
        }


        [CmdOp("import-sdm-opcodes")]
        Outcome SdmImport(CmdArgs args)
        {
            var result = Outcome.Success;
            var svc = Service(Wf.IntelSdm);
            svc.ImportOpCodes();
            return result;
        }

        [CmdOp("emit-metadata-sets")]
        protected Outcome EmitMetadataSets(CmdArgs args)
        {
            var options = WorkflowOptions.@default();
            var svc = Service(Wf.CliEmitter);
            svc.EmitMetadaSets(options);
            return true;
        }

        [CmdOp("emit-api-comments")]
        protected Outcome EmitApiComments(CmdArgs args)
        {
            var collected = Service(Wf.ApiComments).Collect();
            return true;
        }

        [CmdOp("emit-api-classes")]
        protected Outcome EmitApiClasses(CmdArgs args)
        {
            Wf.ApiCatalogs().EmitApiClasses();
            return true;
        }

        [CmdOp("emit-call-table")]
        protected Outcome EmitCallTable(CmdArgs args)
        {
            Wf.AsmCallPipe().EmitRows(Wf.AsmDecoder().Decode(Blocks()));
            return true;
        }

        [CmdOp("emit-hex-pack")]
        protected Outcome EmitHexPack(CmdArgs args)
        {
            Service(Wf.ApiHexPacks).Emit(SortedBlocks());
            return true;
        }

        [CmdOp("emit-cli-metadata")]
        protected Outcome EmitCliMetadata(CmdArgs args)
        {
            var pipe = Wf.CliEmitter();
            pipe.EmitRowStats(Wf.ApiCatalog.Components, Db.IndexTable<CliRowStats>());
            pipe.EmitFieldDefs(Wf.ApiCatalog.Components, Db.IndexTable<FieldDefInfo>());
            pipe.EmitMethodDefs(Wf.ApiCatalog.Components, Db.IndexTable<MethodDefInfo>());
            return true;
        }

        [CmdOp("emit-cil-opcodes")]
        protected Outcome EmitCilOpCodes(CmdArgs args)
        {
            var dst = Db.IndexTable<CilOpCode>();
            TableEmit(Cil.opcodes(), dst);
            return true;
        }

        [CmdOp("emit-sym-literals")]
        protected Outcome EmitSymLiterals(CmdArgs args)
        {
            var service = Wf.Symbolism();
            var dst = Db.AppTablePath<SymLiteralRow>();
            service.EmitLiterals(dst);
            return true;
        }

        [CmdOp("emit-api-tokens")]
        protected Outcome EmitApiTokens(CmdArgs args)
        {
            Service(Wf.ApiMetadata).EmitApiTokens();
            return true;
        }

        [CmdOp("emit-respack")]
        protected Outcome EmitResPack(CmdArgs args)
        {
            Wf.ResPackEmitter().Emit(Blocks());
            return true;
        }

        [CmdOp("asm-gen-models")]
        protected Outcome GenAsmModels(CmdArgs args)
        {
            var dst = Service(Wf.Generators).CodeGenDir("asm.models");
            return true;
        }



        public new Outcome Dispatch(string command, CmdArgs args)
            => Dispatcher.Dispatch(command, args);

        public Outcome Dispatch(string command)
            => Dispatcher.Dispatch(command);

        public ReadOnlySpan<string> Supported
        {
            [MethodImpl(Inline)]
            get => Dispatcher.Supported;
        }

        ReadOnlySpan<ApiCodeBlock> Blocks()
            => Wf.ApiHex().ReadBlocks().Storage;

        SortedIndex<ApiCodeBlock> SortedBlocks()
            => Wf.ApiHex().ReadBlocks().Storage.ToSortedIndex();
    }
}