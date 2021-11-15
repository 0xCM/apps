//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static HexString hexstring(ReadOnlySpan<char> src)
            => new HexString(src);

        [MethodImpl(Inline), Op]
        public static HexString<Hex1Seq> hexstring(N1 n)
            => hexstring<Hex1Seq>();

        [MethodImpl(Inline), Op]
        public static HexString<Hex2Seq> hexstring(N2 n)
            => hexstring<Hex2Seq>();

        [MethodImpl(Inline), Op]
        public static HexString<Hex3Seq> hexstring(N3 n)
            => hexstring<Hex3Seq>();

        [MethodImpl(Inline), Op]
        public static HexString<Hex4Seq> hexstring(N4 n)
            => hexstring<Hex4Seq>();

        [MethodImpl(Inline)]
        public static HexString<K> hexstring<K>()
            where K : unmanaged, Enum
        {
            if(typeof(K) == typeof(Hex1Seq))
                return generic<K>(new HexString<Hex1Seq>(Hex1Text.x00));
            else if(typeof(K) == typeof(Hex2Seq))
                return generic<K>(new HexString<Hex2Seq>(Hex2Text.x00));
            else if(typeof(K) == typeof(Hex3Seq))
                return generic<K>(new HexString<Hex3Seq>(Hex3Text.x00));
            else if(typeof(K) == typeof(Hex4Seq))
                return generic<K>(new HexString<Hex4Seq>(Hex4Text.x00));
            else
                return HexString<K>.Empty;
        }
    }
}