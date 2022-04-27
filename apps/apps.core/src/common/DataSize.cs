//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct DataSize : IComparable<DataSize>
    {
        [MethodImpl(Inline)]
        public static DataSize variable()
            => new DataSize(Kind.Wv);

        readonly Kind Value;

        public DataSize(Kind src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public DataSize(BitWidth width)
        {
            if(width <= (ushort)Pow2x16.P2ᐞ13)
                Value = width == 1 ? Kind.W1 : (Kind)Pow2.log((Pow2x16)(uint)width);
            else
                Value = 0;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Value == 0 ?  0 : (Value == Kind.W1 ? 1 : Pow2.pow((byte)Value));
        }

        public NativeSize Native
        {
            [MethodImpl(Inline)]
            get => Sizes.native(Width);
        }

        public string Format()
            => ((ushort)Width).ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(DataSize src)
            => ((byte)Value).CompareTo((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator DataSize(Kind src)
            => new DataSize(src);

        [MethodImpl(Inline)]
        public static implicit operator DataSize(uint src)
            => new DataSize(src);

        public enum Kind : byte
        {
            None = 0,

            W1 = 1,

            W8 = 2,

            W16 = 4,

            W32 = 5,

            W64 = 6,

            W128 = 7,

            W256 = 8,

            W512 = 9,

            W1024 = 10,

            W2048 = 11,

            W4096 = 12,

            W8192 = 13,

            Wv = 14,
        }
    }
}