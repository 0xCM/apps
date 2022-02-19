//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    public struct __mmask32
    {
        uint Data;

        [MethodImpl(Inline)]
        public __mmask32(uint src)
            => Data = src;

        [MethodImpl(Inline)]
        public static implicit operator __mmask32(uint src)
            => new __mmask32(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(__mmask32 src)
            => src.Data;
    }
}