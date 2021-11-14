//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Outcome EmitCombinedToc()
        {
            var result = Outcome.Success;
            var src = SdmPaths.TocPaths();
            if(src.IsEmpty)
                return (false, "Found no toc's to combine");

            var encoding = pair(TextEncodingKind.Unicode, TextEncodingKind.Unicode);
            var dst = SdmPaths.TocImportPath();
            var flow = Wf.Running(string.Format("Creating combined toc from {0} source files", src.Length));
            DocServices.CombineDocs(src, dst, encoding);
            Wf.Ran(flow);
            return result;
        }
    }
}