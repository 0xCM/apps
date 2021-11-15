//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static char @char(byte src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char @char(in asci2 src, Hex1Seq index)
            => (char)code(src, index);

        [MethodImpl(Inline), Op]
        public static char @char(in asci4 src, Hex2Seq index)
            => (char)code(src, index);

        [MethodImpl(Inline), Op]
        public static char @char(in asci8 src, Hex3Seq index)
            => (char)code(src, index);

        [MethodImpl(Inline), Op]
        public static char @char(in asci16 src, Hex4Seq index)
            => (char)code(src,index);

        [MethodImpl(Inline), Op]
        public static char @char(AsciSymbol src)
            => (char)src;
    }
}