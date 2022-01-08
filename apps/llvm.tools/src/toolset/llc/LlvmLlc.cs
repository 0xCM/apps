//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static Root;
    using static LlcSubtarget;

    [Tool(ToolId)]
    public class LlvmLlcSvc : ToolService<LlvmLlcSvc>
    {
        public const string ToolId = LlvmNames.Tools.llc;

        ProjectScriptSvc ScriptSvc => Service(Wf.ProjectScriptSvc);

        BuildResponseHandler ResponseHandler => Service(() => BuildResponseHandler.create(Wf));

        public LlvmLlcSvc()
            : base(ToolId)
        {

        }

        public Outcome<Index<ToolCmdFlow>> Build(IProjectWs project, LlcSubtarget subtarget, bool runexe = false)
        {
            var result = Outcome.Success;
            var scriptid = subtarget switch
            {
                Sse => "llc-build-sse",
                Sse2 => "llc-build-sse2",
                Sse3 => "llc-build-sse3",
                Sse41 => "llc-build-sse41",
                Sse42 => "llc-build-sse42",
                Avx => "llc-build-avx",
                Avx2 => "llc-build-avx2",
                Avx512 => "llc-build-avx512",
                _ => EmptyString
            };

            return ScriptSvc.RunScript(project, scriptid, EmptyString, flow => ResponseHandler.HandleBuildResponse(flow,runexe));
        }

        public void Build(IProjectWs project)
        {
            var result = Outcome.Success;
            var ll = FS.ext("ll");
            var dir = project.Subdir("src/ll");
            if(!dir.Exists)
            {
                Error(string.Format("The project directory '{0}' does not exist", dir));
                return;
            }

            var src = dir.Files(false, FS.ext("ll"));
            var specs = isets(src);
            var count = specs.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref specs[i];
                var isets = spec.Right;
                var path = spec.Left;
                if(isets.Length == 0)
                {
                    Error(string.Format("No instruction sets specified for {0}", path));
                    break;
                }

                var id = path.FileName.WithoutExtension.Format();
                for(var j=0; j<isets.Length; j++)
                {
                    ref readonly var iset = ref isets[j];
                    var script = project.Script(string.Format("llc-build-{0}", iset));
                    if(script.Exists)
                    {
                        var vars = Cmd.vars(("SrcId",id));
                        result = OmniScript.Run(script, vars, false, out var response);
                        if(result.Fail)
                        {
                            Error(result.Message);
                            break;
                        }
                    }
                    else
                    {
                        Error(FS.missing(script));
                        break;
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
                        var k1 = text.index(content, Chars.Eq);
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