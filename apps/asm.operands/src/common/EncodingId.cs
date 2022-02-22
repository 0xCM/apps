//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EncodingId
    {
        readonly Hex64 Value;

        [MethodImpl(Inline)]
        public EncodingId(Hex64 value)
        {
            Value = value;
        }

        public string Format()
            => string.Format("{0:x16}", (ulong)Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hex64(EncodingId src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator EncodingId(Hex64 src)
            => new EncodingId(src);

        [MethodImpl(Inline)]
        public static explicit operator ulong(EncodingId src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator EncodingId(ulong src)
            => new EncodingId(src);

        public static EncodingId Empty => default;
    }
}