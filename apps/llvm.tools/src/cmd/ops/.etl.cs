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
        [CmdOp(".etl")]
        Outcome RunRecordsEtl(CmdArgs args)
        {
            var data = LlvmEtl.Run();
            return true;
        }

        [CmdOp(".emit-lists")]
        Outcome EmitLists(CmdArgs args)
        {
            var src = LlvmPaths.Settings("ListEmissions", FS.List);
            var lines = src.ReadLines();
            var names = lines.Select(x => x.Trim()).Where(x => nonempty(x));
            iter(names, n => Write(n));
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