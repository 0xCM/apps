//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static JsonDepsModel;

    [ApiHost]
    public readonly struct JsonDepsBuilder
    {
        [MethodImpl(Inline), Op]
        public static LibraryDependency lib(string assembly, string version)
        {
            var dst = new LibraryDependency();
            dst.Name= assembly;
            dst.Version = version;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ProjectDependency project(string assembly, string version)
        {
            var dst = new ProjectDependency();
            dst.AssemblyName = assembly;
            dst.AssemblyVersion = version;
            return dst;
        }
    }
}