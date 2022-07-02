//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct AsciSymbols
    {
        [MethodImpl(Inline), Op]
        public static AsciSeq seq(byte[] src)
            => new AsciSeq(src);

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(string src)
        {
            var buffer = alloc<byte>(src.Length);
            var seq = new AsciSeq(buffer);
            return encode(src, seq);
        }

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(string src, byte[] dst)
        {
            encode(src,dst);
            return seq(dst);
        }

        [MethodImpl(Inline)]
        public static AsciSeq<A> seq<A>(A content)
            where A : unmanaged, IAsciSeq<A>
                => new AsciSeq<A>(content);
    }
}