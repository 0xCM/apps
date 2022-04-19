//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BitNumber
    {
        const byte WidthOffset = 56;

        const ulong WidthMask = 0xFF000000_00000000;

        const ulong ValueMask = ~WidthMask;

        readonly ulong Data;

        [MethodImpl(Inline)]
        internal BitNumber(ulong data, byte width)
        {
            Data = (data & WidthMask) | ((ulong)width << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint1 data)
        {
            Data = (ulong)data | ((ulong)1 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(bit data)
        {
            Data = (ulong)data | ((ulong)1 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint2 data)
        {
            Data = (ulong)data | ((ulong)2 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint3 data)
        {
            Data = (ulong)data | ((ulong)3 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint4 data)
        {
            Data = (ulong)data | ((ulong)4 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint5 data)
        {
            Data = (ulong)data | ((ulong)5 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint6 data)
        {
            Data = (ulong)data | ((ulong)6 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint7 data)
        {
            Data = (ulong)data | ((ulong)7 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint8b data)
        {
            Data = (ulong)data | ((ulong)8 << WidthOffset);
        }

        public byte Width
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> WidthOffset);
        }

        public bit Val1
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public uint2 Val2
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public uint3 Val3
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public uint4 Val4
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public uint5 Val5
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public uint6 Val6
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public uint7 Val7
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public uint8b Val8
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        internal ulong Val56
        {
            [MethodImpl(Inline)]
            get => Data & ValueMask;
        }

        public string Format()
        {
            var width = Width;
            var dst = EmptyString;
            switch(width)
            {
                case 1:
                    dst = Val1.Format();
                break;
                case 2:
                    dst = Val2.Format();
                break;
                case 3:
                    dst = Val3.Format();
                break;
                case 4:
                    dst = Val4.Format();
                break;
                case 5:
                    dst = Val5.Format();
                break;
                case 6:
                    dst = Val6.Format();
                break;
                case 7:
                    dst = Val7.Format();
                break;
                case 8:
                    dst = Val8.Format();
                break;
                default:
                    dst = Val56.FormatBits();
                break;
            }
            return dst;
        }

        public string Format(BitFormat config)
        {
            var width = Width;
            var dst = EmptyString;
            switch(width)
            {
                case 1:
                    dst = config.SpecifierPrefix ? "0b" + Val1.Format() : Val1.Format();
                break;
                case 2:
                    dst = Val2.Format(config);
                break;
                case 3:
                    dst = Val3.Format(config);
                break;
                case 4:
                    dst = Val4.Format(config);
                break;
                case 5:
                    dst = Val5.Format(config);
                break;
                case 6:
                    dst = Val6.Format(config);
                break;
                case 7:
                    dst = Val7.Format(config);
                break;
                case 8:
                    dst = Val8.Format(config);
                break;
                default:
                    dst = Val56.FormatBits(config);
                break;
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint1 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(bit src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint2 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint3 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint4 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint5 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint6 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint7 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint8b src)
            => new BitNumber(src);
    }
}