//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static Root;
    using static core;
    using static ProjectScriptNames;

    partial class LlvmCmd
    {

        [CmdOp(".mc-build")]
        Outcome BuildMc(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, McBuild, "asm");

        [CmdOp(".c-build")]
        Outcome BuildCProj(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, CBuild, "c");

        [CmdOp(".cpp-build")]
        Outcome BuildCpp(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, CppBuild, "cpp");

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

        [CmdOp(".llc-build")]
        Outcome LlcBuild(CmdArgs args)
        {
            var result = Outcome.Success;
            var ll = FS.ext("ll");
            var src = Files().Where(x => x.Is(ll)).View;
            if(args.Length != 0)
            {
                var path = Project().SrcDir("ll") + FS.file(arg(args,0).Value, ll);
                if(path.Exists)
                    src = new FS.FilePath[]{path};
                else
                {
                    result = (false,FS.missing(path));
                    return result;
                }
            }

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
                    var script = Project().Script(string.Format("llc-build-{0}", iset));
                    if(script.Exists)
                    {
                        var vars = Cmd.vars(("SrcId",id));
                        OmniScript.Run(script, vars, false, out var response);
                    }
                }
            }

            return result;
        }

        [CmdOp(".llc-sse")]
        Outcome LlcSse(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse);

        [CmdOp(".llc-sse2")]
        Outcome LlcSse2(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse2);

        [CmdOp(".llc-sse3")]
        Outcome LlcSse3(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse3);

        [CmdOp(".llc-sse41")]
        Outcome LlcSse41(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse41);

        [CmdOp(".llc-sse42")]
        Outcome LlcSse42(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildSse42);

        [CmdOp(".llc-avx")]
        Outcome LlcAvx(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx);

        [CmdOp(".llc-avx2")]
        Outcome LlcAvx2(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx2);

        [CmdOp(".llc-avx512")]
        Outcome LlcAvx512(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, LlcBuildAvx512);
    }
}