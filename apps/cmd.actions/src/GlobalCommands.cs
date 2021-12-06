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
    using static core;
    using static Root;

    [CmdDispatcher]
    public partial class GlobalCommands : AppCmdService<GlobalCommands,CmdShellState>, ICmdDispatcher
    {
        public GlobalCommands()
        {
        }

        protected override void Initialized()
        {
            Dispatcher = CmdDispatcher.discover(this);
        }

        Asm.IntelXed Xed => Service(Wf.IntelXed);

        ApiHex ApiHex => Service(Wf.ApiHex);

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

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
            => ApiHex.ReadBlocks().Storage;

        SortedIndex<ApiCodeBlock> SortedBlocks()
            => ApiHex.ReadBlocks().Storage.ToSortedIndex();
    }
}