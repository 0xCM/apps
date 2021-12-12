//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static Root;

    partial class LlvmCmd
    {
        [CmdOp("llvm/asm/id")]
        Outcome ListAsmIds(CmdArgs args)
        {
            var asmids = DataProvider.SelectAsmIdentifiers();
            iter(asmids.Entries, x => Write(x.Value.Format()));
            return true;
        }
    }
}