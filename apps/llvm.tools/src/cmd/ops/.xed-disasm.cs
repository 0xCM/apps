//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".xed-disasm")]
        Outcome XedDisasm(CmdArgs args)
        {
            var paths = ProjectCollector.XedDisasmFiles(Project());
            var count = paths.Length;
            var xed = Wf.IntelXed();
            var dst = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref paths[i];
                var blocks = xed.ParseDisasmBlocks(path);
                xed.RenderSummaries(blocks, dst);
                Write(dst.Emit());
            }

            return true;
        }
    }
}