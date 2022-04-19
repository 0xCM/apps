//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    partial struct FS
    {
        /// <summary>
        /// Returns true if a path-identified file is a managed module of some sort; otherwise, false
        /// </summary>
        /// <param name="src">The source path</param>
        [Op]
        public static bool managed(FilePath src)
            => name(src, out var _);

        /// <summary>
        /// Returns true if a path-identified file is a managed module of some sort; otherwise, false
        /// </summary>
        /// <param name="src">The source path</param>
        [Op]
        public static bool managed(FilePath src, out AssemblyName assname)
            => name(src, out assname);

        /// <summary>
        /// Searches the source for managed modules
        /// </summary>
        /// <param name="src">The directory to search to search</param>
        /// <param name="dst">The buffer to populate</param>
        /// <param name="recurse">Specifies whether subdirectories should be searched</param>
        [Op]
        public static Deferred<FilePath> managed(FolderPath src, bool recurse = false)
            => files(src, recurse, Dll, Exe).Where(managed);
    }
}