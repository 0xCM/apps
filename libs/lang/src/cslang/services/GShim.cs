//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;

    using static CsModels;

    partial class CsLang
    {
        public class GShim : AppService<GShim>
        {
            public EmitResult Create(string name, FS.FilePath tool, FS.FolderPath dst)
                => Create(new ShimSpec(name, tool, dst+ FS.file(name, FS.Exe)));

            public EmitResult Create(ShimSpec spec)
            {
                var compile = compilation(spec);
                var dst = spec.TargetPath.EnsureParentExists();
                using (var exe = new FileStream(dst.Name, FileMode.Create))
                using (var resources = compile.CreateDefaultWin32Resources(true, true, null, null))
                    return compile.Emit(exe, win32Resources: resources);
            }

            static CSharpCompilation compilation(ShimSpec config)
            {
                Require.invariant(config.ToolPath.Exists, () => $"The file {config.ToolPath}, it must exist");
                var refs = CsCode.perefs(typeof(object), typeof(Enumerable), typeof(ProcessStartInfo));
                var code = new ShimCode(config.TargetPath);
                return CsCode.compilation(config.Name, refs, CsCode.parse(code.Generate()));
            }
        }
    }
}