//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    [Tool(ToolId)]
    public class LlvmLlcSvc : ToolService<LlvmLlcSvc>
    {
        public const string ToolId = LlvmNames.Tools.llc;

        public LlvmLlcSvc()
            : base(ToolId)
        {


        }

        public void Build(IProjectWs ws)
        {
            var result = Outcome.Success;
            var ll = FS.ext("ll");
            var src = ws.Subdir("src/ll").Files(false,FS.ext("ll"));
            var specs = isets(src);
            var count = specs.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref specs[i];
                var isets = spec.Right;
                var path = spec.Left;
                var id = path.FileName.WithoutExtension.Format();
                for(var j=0; j<isets.Length; j++)
                {
                    ref readonly var iset = ref isets[j];
                    var script = ws.Script(string.Format("llc-build-{0}", iset));
                    if(script.Exists)
                    {
                        var vars = Cmd.vars(("SrcId",id));
                        OmniScript.Run(script, vars, false, out var response);
                    }
                }
            }
        }

        static Pairings<FS.FilePath,Index<string>> isets(ReadOnlySpan<FS.FilePath> src)
        {
            var count = src.Length;

            var dst = alloc<Paired<FS.FilePath,Index<string>>>(count);
            var empty = Index<string>.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                seek(dst,i) = (path,empty);
                using var reader = path.Utf8LineReader();
                var counter = 0u;
                while(reader.Next(out var line) && counter <= 3)
                {
                    var content = line.Content.Trim();
                    if(text.index(content, "; iset") >= 0)
                    {
                        var k1 = text.index(content,Chars.Eq);
                        if(k1 >= 0)
                        {
                            var isets= text.right(content,k1).Split(Chars.Plus).Select(x => x.Trim());
                            seek(dst,i) = (path,isets);
                        }
                    }
                }
            }
            return dst;
        }
    }
}
