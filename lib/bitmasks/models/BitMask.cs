//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct BitMask
    {
        [MethodImpl(Inline)]
        public static ref BitMask invert(ref BitMask src)
        {
            src.Value = ~src.Value;
            return ref src;
        }

        internal readonly byte Width;

        internal ulong Value;

        [MethodImpl(Inline)]
        internal BitMask(byte width, ulong value)
        {
            Width = width;
            Value = value;
        }

        byte M8
        {
            [MethodImpl(Inline)]
            get => (byte)Value;
        }

        ushort M16
        {
            [MethodImpl(Inline)]
            get => (ushort)Value;
        }

        uint M32
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        ulong M64
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public byte Apply(byte src)
            => math.and(M8, src);

        [MethodImpl(Inline)]
        public ushort Apply(ushort src)
            => math.and(M16, src);

        [MethodImpl(Inline)]
        public uint Apply(uint src)
            => math.and(M32, src);

        [MethodImpl(Inline)]
        public ulong Apply(ulong src)
            => math.and(M64, src);

        public string Format()
            => ((BitMaskData)this).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static BitMask operator ~(BitMask src)
            => invert(ref src);

        [MethodImpl(Inline)]
        public static byte operator &(BitMask mask, byte value)
            => mask.Apply(value);

        [MethodImpl(Inline)]
        public static ushort operator &(BitMask mask, ushort value)
            => mask.Apply(value);

        [MethodImpl(Inline)]
        public static uint operator &(BitMask mask, uint value)
            => mask.Apply(value);

        [MethodImpl(Inline)]
        public static ulong operator &(BitMask mask, ulong value)
            => mask.Apply(value);

        [MethodImpl(Inline)]
        public static byte operator |(BitMask mask, byte value)
            => math.or(mask.M8, value);

        [MethodImpl(Inline)]
        public static ushort operator |(BitMask mask, ushort value)
            => math.or(mask.M16, value);

        [MethodImpl(Inline)]
        public static uint operator |(BitMask mask, uint value)
            => math.or(mask.M32, value);

        [MethodImpl(Inline)]
        public static ulong operator |(BitMask mask, ulong value)
            => math.or(mask.M64, value);

        [MethodImpl(Inline)]
        public static byte operator ^(BitMask mask, byte value)
            => math.xor(mask.M8, value);

        [MethodImpl(Inline)]
        public static ushort operator ^(BitMask mask, ushort value)
            => math.xor(mask.M16, value);

        [MethodImpl(Inline)]
        public static uint operator ^(BitMask mask, uint value)
            => math.xor(mask.M32, value);

        [MethodImpl(Inline)]
        public static ulong operator ^(BitMask mask, ulong value)
            => math.xor(mask.M64, value);

        [MethodImpl(Inline)]
        public static implicit operator BitMaskData(BitMask src)
            => new BitMaskData(src.Value, src.Width);

        public static BitMask Empty => default;
    }
}