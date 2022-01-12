//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class ApiCmdProvider
    {
        BitMaskServices ApiBitmasks => Service(Wf.ApiBitMasks);

        [CmdOp("api/emit/asmcalls")]
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
    }
}