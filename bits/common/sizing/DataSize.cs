//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(64)]
    public readonly record struct DataSize : IComparable<DataSize>
    {
        readonly ulong Data;

        [MethodImpl(Inline)]
        public DataSize(uint packed, uint aligned)
            => Data = Bitfields.join(packed, aligned);

        public uint PackedWidth
        {
            [MethodImpl(Inline)]
            get => (uint)Data;
        }

        public uint NativeWidth
        {
            [MethodImpl(Inline)]
            get => (uint)(Data >> 32);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out byte packed, out byte native)
        {
            packed = (byte)PackedWidth;
            native = (byte)NativeWidth;
        }

        public string Format()
            => Format(4,4);

        public static string digits(byte index, byte n)
            => Chars.LBrace + $"{index}:D{n}" + Chars.RBrace;

        public string Format(byte pN, byte aN)
            => string.Format(string.Format("{0}:{1}", digits(0,pN), digits(1, aN)), PackedWidth, NativeWidth);

        public string Format(byte pN, byte aN, bool bracket)
            => bracket ? text.bracket(Format(pN, aN)) : Format(pN, aN);

        public string Format(bool bracket)
            => bracket ? text.bracket(Format()) : Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(DataSize src)
            => PackedWidth.CompareTo(src.PackedWidth);

        [MethodImpl(Inline)]
        public static implicit operator DataSize((uint packed, uint native) src)
            => new DataSize(src.packed, src.native);

        public static DataSize Empty => default;
    }
}