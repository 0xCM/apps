//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct AsciSymbols
    {
        [MethodImpl(Inline), Op]
        public static AsciSequence seq(byte[] src)
            => new AsciSequence(src);

        [MethodImpl(Inline), Op]
        public static AsciSequence seq(string src)
        {
            var buffer = alloc<byte>(src.Length);
            var seq = new AsciSequence(buffer);
            return encode(src, seq);
        }

        [MethodImpl(Inline), Op]
        public static AsciSequence seq(string src, byte[] dst)
        {
            encode(src,dst);
            return seq(dst);
        }

        [MethodImpl(Inline)]
        public static AsciSequence<A> seq<A>(A content)
            where A : unmanaged, IByteSeq
                => new AsciSequence<A>(content);
    }
}