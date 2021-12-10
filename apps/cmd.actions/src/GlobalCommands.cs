//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using llvm;
    using Asm;

    using static core;
    using static Root;

    [CmdDispatcher]
    public partial class GlobalCommands : AppCmdService<GlobalCommands,CmdShellState>, ICmdDispatcher, ICmdHost
    {
        public GlobalCommands()
        {
            _Data = new();
        }

        ConcurrentDictionary<string,object> _Data;

        [MethodImpl(Inline)]
        T Data<T>(string key, Func<T> factory)
            => (T)_Data.GetOrAdd(key, k => factory());

        protected override void Initialized()
        {
            Dispatcher = CmdDispatcher.discover(this);
        }

        IntelXed Xed => Service(Wf.IntelXed);

        ApiHex ApiHex => Service(Wf.ApiHex);

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

        AsmTables AsmTables => Service(Wf.AsmTables);

        ApiPacks ApiPacks => Service(Wf.ApiPacks);

        ApiHexPacks ApiHexPacks => Service(Wf.ApiHexPacks);

        ApiPackArchive ApiPackArchive => Service(ApiPacks.Archive);

        IApiCatalog ApiRuntimeCatalog => Service(ApiRuntimeLoader.catalog);

        AsmCallPipe AsmCalls => Service(Wf.AsmCallPipe);

        AsmDecoder AsmDecoder => Service(Wf.AsmDecoder);

        Index<ProcessAsmRecord> ProcessAsm() => Data(nameof(ProcessAsm), _LoadProcessAsm);

        Index<ProcessAsmRecord> ProcessAsmBuffer() => Data(nameof(ProcessAsmBuffer), () => alloc<ProcessAsmRecord>(ProcessAsm().Count));

        Index<ProcessAsmRecord> _LoadProcessAsm()
        {
            var archive = ApiPacks.Current().Archive();
            var path = archive.ProcessAsmPath();
            var count = FS.linecount(path,TextEncodingKind.Asci) - 1;
            var buffer = alloc<ProcessAsmRecord>(count);
            var flow = Running(string.Format("Loading process asm from {0}", path.ToUri()));
            var result = AsmTables.load(path, buffer);
            if(result.Fail)
            {
                Error(result.Message);
                return Index<ProcessAsmRecord>.Empty;
            }
            Ran(flow);

            return buffer;
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
    }
}