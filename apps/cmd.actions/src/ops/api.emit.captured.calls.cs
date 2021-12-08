//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using System;
    using Asm;

    partial class GlobalCommands
    {
        [CmdOp("api/emit/captured/calls")]
        protected Outcome EmitCallTable(CmdArgs args)
        {
            var blocks = Data(nameof(ApiCodeBlock),Blocks);
            var dst = ProjectDb.Subdir("api/asm/calls");
            AsmCalls.EmitRows(AsmDecoder.Decode(blocks), dst);
            return true;
        }

        Index<ApiCodeBlock> Blocks()
            => ApiHex.ReadBlocks().Storage;

        SortedIndex<ApiCodeBlock> SortedBlocks()
            => ApiHex.ReadBlocks().Storage.ToSortedIndex();


        [CmdOp("emit-respack")]
        protected Outcome EmitResPack(CmdArgs args)
        {
            Wf.ResPackEmitter().Emit(Blocks());
            return true;
        }
    }
}