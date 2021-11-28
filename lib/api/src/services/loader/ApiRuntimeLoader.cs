//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    public readonly partial struct ApiRuntimeLoader
    {
        public static FS.FilePath path(Assembly src)
            => FS.path(src.Location);

        public static FS.FolderPath dir(Assembly src)
            => path(src).FolderPath;

        [Op]
        internal static FS.Files managed(FS.FolderPath dir)
            => dir.Exclude("System.Private.CoreLib").Where(f => FS.managed(f));
    }
}