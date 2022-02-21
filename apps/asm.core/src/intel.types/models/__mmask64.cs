//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct IntelDataTypes
    {
        public struct __mmask64
        {
            ulong Data;

            [MethodImpl(Inline)]
            public __mmask64(ulong src)
                => Data = src;

            [MethodImpl(Inline)]
            public static implicit operator __mmask64(ulong src)
                => new __mmask64(src);

            [MethodImpl(Inline)]
            public static implicit operator ulong(__mmask64 src)
                => src.Data;
        }
    }
}