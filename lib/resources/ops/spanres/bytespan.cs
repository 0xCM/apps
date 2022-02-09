//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct SpanRes
    {
        [MethodImpl(Inline)]
        public static ByteSpanSpec<T> bytespan<T>(Identifier name, T[] data, bool @static = true)
            where T : unmanaged
                => new ByteSpanSpec<T>(name, data, @static);
    }
}