//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;

    partial struct PdbServices
    {
        [MethodImpl(Inline), Op]
        public static PdbKind pdbkind(in byte src)
            => portable(src) ? PdbKind.Portable : PdbKind.Legacy;

        [MethodImpl(Inline), Op]
        public static PdbKind pdbkind(ReadOnlySpan<byte> src)
            => portable(src) ? PdbKind.Portable : PdbKind.Legacy;

        [MethodImpl(Inline), Op]
        public static unsafe PdbKind pdbkind(byte* pSrc)
            => portable(pSrc) ? PdbKind.Portable : PdbKind.Legacy;

        [MethodImpl(Inline), Op]
        public static PdbKind pdbkind(Stream src)
            => portable(src) ? PdbKind.Portable : PdbKind.Legacy;
    }
}