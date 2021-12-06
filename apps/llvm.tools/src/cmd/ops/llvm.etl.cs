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
        [CmdOp("llvm/etl")]
        Outcome RunRecordsEtl(CmdArgs args)
        {
            LlvmEtl.Run();
            return true;
        }

        [CmdOp(".asmid")]
        Outcome ListAsmIds(CmdArgs args)
        {
            var descriptors = LlvmEtl.ExtractAsmIdList();
            iter(descriptors.Entries, x => Write(x.Value.Format()));
            return true;
        }
    }
}