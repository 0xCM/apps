//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    [ApiHost]
    public readonly struct ClrAssemblyNames
    {
        [MethodImpl(Inline), Op]
        public static ClrAssemblyName from(AssemblyName src)
            => new ClrAssemblyName(src);

        [MethodImpl(Inline), Op]
        public static ClrAssemblyName from(Assembly src)
            => new ClrAssemblyName(src);

        [MethodImpl(Inline), Op]
        public static AssemblyVersion version(AssemblyName src)
        {
            var version = src.Version;
            var dst = new AssemblyVersion((ushort)version.Major, (ushort)version.Minor, (ushort)version.Build, (ushort)version.Revision);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static string format(AssemblyName src, AssemblyNameKind kind = AssemblyNameKind.Simple)
            => kind == AssemblyNameKind.Full ? src.FullName : src.Name;
    }
}