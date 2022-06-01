//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class ApiCmd
    {
        [CmdOp("api/emit/asmcalls")]
        protected Outcome EmitCallTable(CmdArgs args)
        {
            var blocks = ApiCode.LoadBlocks();
            AsmCalls.EmitRows(AsmDecoder.Decode(blocks.Storage), ProjectDb.Subdir("api/asm/calls"));
            return true;
        }

        Index<HostAsmRecord> HostAsm()
        {
            Index<HostAsmRecord> Load()
            {
                var pack = ApiPacks.Current();
                var paths = pack.Archive().HostAsmTables();
                return AsmTables.LoadHostAsmRows(paths);
            }
            return Data(nameof(HostAsm),Load);
        }
    }
}