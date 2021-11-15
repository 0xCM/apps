//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.IO;
    using Microsoft.CodeAnalysis.Emit;

    using static Root;

    [ApiHost]
    public readonly struct CsTools
    {
        [MethodImpl(Inline), Op]
        public static ToolShimSpec shimspec(Identifier name, FS.FilePath tool, FS.FolderPath dst)
            => new ToolShimSpec(name, tool, dst+ FS.file(name.Format(), FS.Exe));

        [Op]
        public static ToolShimSpec shim(Identifier name, FS.FilePath tool, FS.FolderPath dst)
        {
            var spec = shimspec(name,tool,dst);
            var emission = create(spec);
            if(!emission.Success)
                Throw.sourced(emission.Diagnostics.Map(x => x.ToString()).Array().Concat(Chars.Eol));
            return spec;
        }

        public static bool create(ToolShimSpec spec, out EmitResult dst, out string[] errors)
        {
            errors = sys.empty<string>();
            dst = create(spec);
            if(!dst.Success)
                errors = dst.Diagnostics.Map(x => x.ToString()).Array();
            return dst.Success;
        }

        public static PortableExecutableReference pe<T>()
            => PortableExecutableReference.CreateFromFile(typeof(T).Assembly.Location);

        [Op]
        public static PortableExecutableReference pe(Type src)
            => PortableExecutableReference.CreateFromFile(src.Assembly.Location);

        [Op]
        public static PortableExecutableReference[] pe(params Type[] src)
            => src.Select(pe);

        [Op]
        public static CSharpCompilation compilation(Identifier name)
            => CSharpCompilation.Create(name);

        [Op]
        public static SyntaxTree parse(string src)
            => CSharpSyntaxTree.ParseText(src);

        [Op]
        public static CSharpCompilation compilation(Identifier name, MetadataReference[] refs)
            => compilation(name).AddReferences(refs);

        [Op]
        public static CSharpCompilation compilation(Identifier name, MetadataReference[] refs, params SyntaxTree[] syntax)
            => compilation(name,refs).AddSyntaxTrees(syntax);

        public static CSharpCompilation compilation(ToolShimSpec config)
        {
            Require.invariant(config.ToolPath.Exists, () => $"The file {config.ToolPath}, it must exist");
            var refs = CsTools.pe(typeof(object), typeof(Enumerable), typeof(ProcessStartInfo));
            var code = new ToolShimCode(config.TargetPath);
            return CsTools.compilation(config.Name, refs, CsTools.parse(code.Generate()));
        }

        public static EmitResult create(ToolShimSpec config)
        {
            var compile = CsTools.compilation(config);
            var dst = config.TargetPath.EnsureParentExists();
            using (var exe = new FileStream(dst.Name, FileMode.Create))
            using (var resources = compile.CreateDefaultWin32Resources(true, true, null, null))
                return compile.Emit(exe, win32Resources: resources);
        }
    }
}