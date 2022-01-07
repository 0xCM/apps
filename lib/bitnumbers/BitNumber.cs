//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using System.Runtime.CompilerServices;

    using static Root;

    using NK = NumericKind;

    public readonly struct BitNumber
    {
        [Op]
        public static BitNumber infer(object src)
        {
            if(src == null)
                return BitNumber.Empty;

            var kind = src.GetType().NumericKind();
            return kind switch{
                NK.U8 => (byte)src,
                NK.U16 => (ushort)src,
                NK.U32 => (uint)src,
                NK.U64 => (ulong)src,
                NK.I8 => (byte)(sbyte)src,
                NK.I16 => (ushort)(short)src,
                NK.I32 => (uint)(int)src,
                NK.I64 => (ulong)(long)src,
                _ => BitNumber.Empty
            };
        }

        readonly ulong Data;

        public readonly byte DataWidth;

        [MethodImpl(Inline)]
        public BitNumber(byte src)
        {
            Data = src;
            DataWidth = 8;
        }

        [MethodImpl(Inline)]
        public BitNumber(ushort src)
        {
            Data = src;
            DataWidth = 16;
        }

        [MethodImpl(Inline)]
        public BitNumber(uint src)
        {
            Data = src;
            DataWidth = 32;
        }

        [MethodImpl(Inline)]
        public BitNumber(ulong src)
        {
            Data = src;
            DataWidth = 64;
        }

        [MethodImpl(Inline)]
        public BitNumber(ulong src, byte width)
        {
            Data = src;
            DataWidth = width;
        }

        [MethodImpl(Inline)]
        public ref byte Value(out byte value)
        {
            value = (byte)Data;
            return ref value;
        }

        [MethodImpl(Inline)]
        public ref ushort Value(out ushort value)
        {
            value = (ushort)Data;
            return ref value;
        }

        [MethodImpl(Inline)]
        public ref uint Value(out uint value)
        {
            value = (uint)Data;
            return ref value;
        }

        [MethodImpl(Inline)]
        public ref ulong Value(out ulong value)
        {
            value = Data;
            return ref value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => DataWidth == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => DataWidth == 0;
        }

        public NumericKind DataKind
        {
            [MethodImpl(Inline)]
            get
            {
                if(DataWidth <=8)
                    return NumericKind.U8;
                else if(DataWidth <=16)
                    return NumericKind.U16;
                else if(DataWidth <=32)
                    return NumericKind.U32;
                else
                    return NumericKind.U64;
            }
        }

        public string Format()
        {
            if(IsEmpty)
                return EmptyString;

            if(DataWidth <=8)
                return ((byte)Data).FormatBits();
            else if(DataWidth <=16)
                return ((ushort)Data).FormatBits();
            else if(DataWidth <=32)
                return ((uint)Data).FormatBits();
            else
                return ((ulong)Data).FormatBits();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(byte src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(ushort src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(ulong src)
            => new BitNumber(src);

        public static BitNumber Empty => default;
    }
}