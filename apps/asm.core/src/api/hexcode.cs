//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [Op]
        public static AsmHexCode hexcode(string src)
        {
            if(AsmHexCode.parse(src, out var dst))
                return dst;
            else
                return AsmHexCode.Empty;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode hexcode(ulong src)
            => AsmHexCode.load(src);

        [MethodImpl(Inline), Op]
        public static Outcome hexcode(ReadOnlySpan<char> src, out AsmHexCode dst)
            => AsmHexCode.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static AsmHexCode hexcode(ReadOnlySpan<byte> src)
            => AsmHexCode.load(src);
    }
}