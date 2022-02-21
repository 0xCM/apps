//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct IntelDataTypes
    {
        public struct __mmask8
        {
            byte Data;

            [MethodImpl(Inline)]
            public __mmask8(byte src)
                => Data = src;

            [MethodImpl(Inline)]
            public static implicit operator __mmask8(byte src)
                => new __mmask8(src);

            [MethodImpl(Inline)]
            public static implicit operator byte(__mmask8 src)
                => src.Data;
        }

    }
}