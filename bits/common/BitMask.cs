//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public struct BitMask
    {
        [MethodImpl(Inline), Op]
        public static BitMask mask(ulong value)
            => new BitMask(value);

        [MethodImpl(Inline), Op]
        public static BitMask mask(byte width, ulong value)
            => new BitMask(width, value);

        [MethodImpl(Inline), Op]
        public static BitMask mask(W8 w, byte i0, byte i1)
            => new BitMask((byte)w, bits.ones(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W16 w, byte i0, byte i1)
            => new BitMask((byte)w, bits.ones(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W32 w, byte i0, byte i1)
            => new BitMask((byte)w, bits.ones(w, i0, i1));

        [MethodImpl(Inline), Op]
        public static BitMask mask(W64 w, byte i0, byte i1)
            => new BitMask((byte)w, bits.ones(w, i0, i1));

        [Op]
        public static BitMask mask(NativeSize size, byte i0, byte i1)
            => size.Code switch{
                NativeSizeCode.W8 => mask(w8, i0, i1),
                NativeSizeCode.W16 => mask(w16, i0, i1),
                NativeSizeCode.W32 => mask(w32, i0, i1),
                NativeSizeCode.W64 => mask(w64, i0, i1),
                _ => BitMask.Empty
            };

        public readonly byte Width;

        public ulong Value;

        [MethodImpl(Inline)]
        public BitMask(ulong value)
        {
            Width = 64;
            Value = value;
        }

        [MethodImpl(Inline)]
        public BitMask(byte width, ulong value)
        {
            Width = width;
            Value = value;
        }

        [MethodImpl(Inline)]
        public byte Apply(byte src)
            => math.and((byte)Value, src);

        [MethodImpl(Inline)]
        public ushort Apply(ushort src)
            => math.and((ushort)Value, src);

        [MethodImpl(Inline)]
        public uint Apply(uint src)
            => math.and((uint)Value, src);

        [MethodImpl(Inline)]
        public ulong Apply(ulong src)
            => math.and(Value, src);

        [MethodImpl(Inline)]
        public BitMask And(BitMask src)
            => new BitMask(math.max(Width,src.Width), Value & src.Value);

        [MethodImpl(Inline)]
        public BitMask Or(BitMask src)
            => new BitMask(math.max(Width,src.Width), Value | src.Value);

        [MethodImpl(Inline)]
        public BitMask Xor(BitMask src)
            => new BitMask(math.max(Width,src.Width), Value ^ src.Value);

        [MethodImpl(Inline)]
        public BitMask Invert()
            => new BitMask(Width, ~Value);

        [MethodImpl(Inline)]
        public BitMask Negate()
            => new BitMask(Width, math.negate(Value));

        [MethodImpl(Inline)]
        public BitMask Sll(byte count)
        {
            var value = Value << count;
            var width = math.max(bits.effwidth(value), Width);
            return new BitMask(width,value);
        }

        [MethodImpl(Inline)]
        public BitMask Srl(byte count)
        {
            var value = Value << count;
            var width = math.min(bits.effwidth(value), Width);
            return new BitMask(width,value);
        }

        public string Format()
            => ((BitMaskData)this).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static BitMask operator ~(BitMask src)
            => src.Invert();

        [MethodImpl(Inline)]
        public static BitMask operator -(BitMask src)
            => src.Negate();

        [MethodImpl(Inline)]
        public static BitMask operator &(BitMask a, BitMask b)
            => a.And(b);

        [MethodImpl(Inline)]
        public static BitMask operator |(BitMask a, BitMask b)
            => a.Or(b);

        [MethodImpl(Inline)]
        public static BitMask operator ^(BitMask a, BitMask b)
            => a.Xor(b);

        [MethodImpl(Inline)]
        public static BitMask operator <<(BitMask a, int count)
            => a.Sll((byte)count);

        [MethodImpl(Inline)]
        public static BitMask operator >>(BitMask a, int count)
            => a.Srl((byte)count);

        [MethodImpl(Inline)]
        public static implicit operator BitMask(ulong src)
            => new BitMask(src);

        [MethodImpl(Inline)]
        public static implicit operator BitMaskData(BitMask src)
            => new BitMaskData(src.Value, src.Width);

        public static BitMask Empty => default;
    }
}