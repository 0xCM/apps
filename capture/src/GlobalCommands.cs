//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    [CmdDispatcher]
    public class GlobalCommands : AppService<GlobalCommands>, ICmdDispatcher
    {
        CmdDispatcher Dispatcher;

        public GlobalCommands()
        {
        }

        protected override void Initialized()
        {
            Dispatcher = Cmd.dispatcher(this);
        }

        [CmdOp("emit-metadata-sets")]
        public Outcome EmitMetadataSets(CmdArgs args)
        {
            var options = WorkflowOptions.@default();
            Wf.CliEmitter().EmitMetadaSets(options);
            return true;
        }

        [CmdOp("emit-api-comments")]
        public Outcome EmitApiComments(CmdArgs args)
        {
            Wf.ApiComments().Collect();
            return true;
        }

        [CmdOp("emit-api-classes")]
        public Outcome EmitApiClasses(CmdArgs args)
        {
            Wf.ApiCatalogs().EmitApiClasses();
            return true;
        }

        [CmdOp("emit-call-table")]
        public Outcome EmitCallTable(CmdArgs args)
        {
            Wf.AsmCallPipe().EmitRows(Wf.AsmDecoder().Decode(Blocks()));
            return true;
        }

        [CmdOp("emit-hex-pack")]
        public Outcome EmitHexPack(CmdArgs args)
        {
            var sorted = SortedBlocks();
            Wf.ApiHexPacks().Emit(sorted);
            return true;
        }

        [CmdOp("emit-cli-metadata")]
        public Outcome EmitCliMetadata(CmdArgs args)
        {
            var pipe = Wf.CliEmitter();
            pipe.EmitRowStats(Wf.ApiCatalog.Components, Db.IndexTable<CliRowStats>());
            pipe.EmitFieldDefs(Wf.ApiCatalog.Components, Db.IndexTable<FieldDefInfo>());
            pipe.EmitMethodDefs(Wf.ApiCatalog.Components, Db.IndexTable<MethodDefInfo>());
            return true;
        }

        [CmdOp("emit-cil-opcodes")]
        public Outcome EmitCilOpCodes(CmdArgs args)
        {
            var dst = Db.IndexTable<CilOpCode>();
            TableEmit(Cil.opcodes(), dst);
            return true;
        }

        [CmdOp("emit-sym-literals")]
        public Outcome EmitSymLiterals(CmdArgs args)
        {
            var service = Wf.Symbolism();
            var dst = Db.AppTablePath<SymLiteralRow>();
            service.EmitLiterals(dst);
            return true;
        }

        [CmdOp("emit-respack")]
        public Outcome EmitResPack(CmdArgs args)
        {
            Wf.ResPackEmitter().Emit(Blocks());
            return true;
        }

        [CmdOp("asm-gen-models")]
        public Outcome GenInstructionModels(CmdArgs args)
        {
            Wf.AsmModelGen().GenModelsInPlace();
            return true;
        }

        [CmdOp("asm-gen-models-preview")]
        public Outcome GenInstructionModelPreview(CmdArgs args)
        {
            Wf.AsmModelGen().GenModels(Db.AppLogRoot() + FS.folder("asm.lang.g"));
            return true;
        }

        [CmdOp("capture-v2")]
        public Outcome CaptureV2(CmdArgs args)
        {
           Wf.ApiExtractWorkflow().Run(args);
           return true;
        }

        [CmdOp("emit-xed-cat")]
        public Outcome EmitXedCat(CmdArgs args)
        {
           Wf.IntelXed().EmitCatalog();
           return true;
        }

        [CmdOp("capture-process")]
        public Outcome RunMachine(CmdArgs args)
        {
            using var machine = MachineRunner.create(Wf);
            machine.Run(WorkflowOptions.@default());
            return true;
        }

        [CmdOp("capture")]
        public Outcome CaptureV1(CmdArgs args)
        {
            var result = Capture.run();
            return true;
        }

        public Outcome Dispatch(string command, CmdArgs args)
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