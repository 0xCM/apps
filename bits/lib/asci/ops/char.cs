//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static char @char(byte src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char @char(in asci2 src, Hex1Kind index)
            => (char)code(src, index);

        [MethodImpl(Inline), Op]
        public static char @char(in asci4 src, Hex2Kind index)
            => (char)code(src, index);

        [MethodImpl(Inline), Op]
        public static char @char(in asci8 src, Hex3Kind index)
            => (char)code(src, index);

        [MethodImpl(Inline), Op]
        public static char @char(in asci16 src, Hex4Kind index)
            => (char)code(src,index);

        [MethodImpl(Inline), Op]
        public static char @char(AsciSymbol src)
            => (char)src;
    }
}