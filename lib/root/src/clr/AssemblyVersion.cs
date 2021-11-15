//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Defines a four-part asemembly version number
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AssemblyVersion
    {
        public ushort Major {get;}

        public ushort Minor {get;}

        public ushort Build {get;}

        public ushort Revision {get;}

        [MethodImpl(Inline)]
        public AssemblyVersion(ushort a, ushort b, ushort c, ushort d)
        {
            Major = a;
            Minor = b;
            Build = c;
            Revision = d;
        }

        [MethodImpl(Inline)]
        public static explicit operator ulong(AssemblyVersion src)
            => minicore.uint64(src);

        [MethodImpl(Inline)]
        public static implicit operator AssemblyVersion(Version src)
            => new AssemblyVersion((ushort)src.Major, (ushort)src.Minor, (ushort)src.Build, (ushort)src.Revision);

        [MethodImpl(Inline)]
        public static implicit operator Version(AssemblyVersion src)
            => new Version(src.Major, src.Minor, src.Build, src.Revision);
    }
}