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
            AsmCalls.EmitRows(AsmDecoder.Decode(Blocks().Storage), ProjectDb.Subdir("api/asm/calls"));
            return true;
        }

        SortedIndex<ApiCodeBlock> Blocks()
        {
            SortedIndex<ApiCodeBlock> Load()
            {
                var pack = ApiPacks.Current();
                return ApiHex.ReadBlocks(pack.Archive().ParsedExtractPaths(pack));
            }

            return Data(nameof(Blocks), Load);
        }

        Index<HostAsmRecord> HostAsm()
        {
            Index<HostAsmRecord> Load()
            {
                var pack = ApiPacks.Current();
                return AsmTables.LoadHostAsmRows(pack.Archive().HostAsm());
            }
            return Data(nameof(HostAsm),Load);
        }
    }
}