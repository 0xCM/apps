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
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                var name = path.FileName.WithoutExtension.Format();
                var last = name.Length - 1;
                if(last > 0)
                {
                    var vol = (byte)Digital.digit(name[last]);

                }
            }

            // var flow = Running(string.Format("Creating combined toc from {0} source files", src.Length));
             CombineDocs(src, dst, encoding);
            // Ran(flow);
            return result;
        }
    }
}