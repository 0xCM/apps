//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Reflection;

    using static Root;
    using static FS;

    partial class XTend
    {
        public static IRuntimeArchive RuntimeArchive(this Assembly src)
            => new RuntimeArchive(FS.path(src.Location).FolderPath);
    }

    [ApiHost]
    public readonly struct RuntimeArchive : IRuntimeArchive
    {
        public FS.FolderPath Root {get;}

        public FS.Files Files {get;}

        [MethodImpl(Inline)]
        public static IRuntimeArchive create()
            => new RuntimeArchive(FS.dir(RuntimeEnvironment.GetRuntimeDirectory()));

        [MethodImpl(Inline)]
        public static RuntimeArchive create(FS.FolderPath src)
            => new RuntimeArchive(src);

        [Op]
        public static string format(RuntimeAssembly src)
            => string.Format("{0}:{1}", src.Component.GetSimpleName(), src.Path.ToUri());

        [MethodImpl(Inline)]
        public static RuntimeAssembly assembly(Assembly component)
            => new RuntimeAssembly(component, FS.path(component.Location));

        [MethodImpl(Inline)]
        public static RuntimeAssembly assembly(Assembly component, FS.FilePath path)
            => new RuntimeAssembly(component, path);

        [MethodImpl(Inline)]
        internal RuntimeArchive(FS.FolderPath root)
        {
            Root = root;
            Files = root.Files(false, Exe, Dll, Pdb, Json, Xml).Where(x => !x.Name.Contains("System.Private.CoreLib"));
        }
    }
}