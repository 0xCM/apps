//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Hex
    {
        [MethodImpl(Inline)]
        public static HexIndex<K> index<K>(K[] src)
            where K : unmanaged, IHexNumber
                => new HexIndex<K>(src);

        [MethodImpl(Inline)]
        public static byte value<H>(H h= default)
            where H : unmanaged, IHexType
                => (byte)h.Value;

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex5> index(Hex5Kind[] src)
        //     => index<Hex5>(@as<Hex5Kind[],Hex5[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex6> index(Hex6Kind[] src)
        //     => index<Hex6>(@as<Hex6Kind[],Hex6[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex8> index(Hex8Kind[] src)
        //     => index<Hex8>(@as<Hex8Kind[],Hex8[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex1> index(N1 n, byte[] src)
        //     => index<Hex1>(@as<byte[],Hex1[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex2> index(N2 n, byte[] src)
        //     => index<Hex2>(@as<byte[],Hex2[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex4> index(N4 n, byte[] src)
        //     => index<Hex4>(@as<byte[],Hex4[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex5> index(N5 n, byte[] src)
        //     => index<Hex5>(@as<byte[],Hex5[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex6> index(N6 n, byte[] src)
        //     => index<Hex6>(@as<byte[],Hex6[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex8> index(N8 n, byte[] src)
        //     => index<Hex8>(@as<byte[],Hex8[]>(src));

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex1> index(Hex1[] src)
        //     => index<Hex1>(src);

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex2> index(Hex2[] src)
        //     => index<Hex2>(src);

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex4> index(Hex4[] src)
        //     => index<Hex4>(src);

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex5> index(Hex5[] src)
        //     => index<Hex5>(src);

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex6> index(Hex6[] src)
        //     => index<Hex6>(src);

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex7> index(Hex7[] src)
        //     => index<Hex7>(src);

        // [MethodImpl(Inline), Op]
        // public static HexIndex<Hex8> index(Hex8[] src)
        //     => index<Hex8>(src);
    }
}