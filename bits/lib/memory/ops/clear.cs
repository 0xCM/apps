//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    unsafe partial struct memory
    {
        /// <summary>
        /// Zero-fills a token-identified buffer and returns the cleared memory content
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Span<byte> clear(in NativeBuffers src, byte index)
            => sys.clear(span(src.Token(index)));

        [MethodImpl(Inline), Op]
        public static void clear(BufferToken src)
            => span(src).Clear();
    }
}