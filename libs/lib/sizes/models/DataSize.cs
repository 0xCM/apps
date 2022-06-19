//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(64)]
    public readonly record struct DataSize : IComparable<DataSize>
    {
        [Parser]
        public static bool parse(string src, out DataSize dst)
        {
            dst = Empty;
            var parts = text.split(text.trim(text.despace(src)),Chars.Space);
            var result = parts.Length == 2;
            if(result)
            {
                result &= DataParser.parse(skip(parts,0), out uint p);
                result &= DataParser.parse(skip(parts,1), out uint n);
                dst = new DataSize(p,n);
            }
            return result;
        }

        readonly ulong Data;

        [MethodImpl(Inline)]
        public DataSize(uint packed, uint native)
            => Data = ((ulong)packed | (ulong)native << 32);

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

        public uint Packed
        {
            [MethodImpl(Inline)]
            get => (uint)Data;
        }

        public uint Native
        {
            [MethodImpl(Inline)]
            get => (uint)(Data >> 32);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
           get => Data != 0;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out uint packed, out uint native)
        {
            packed = Packed;
            native = Native;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Data | (uint)(Data >> 48);
        }

        public override int GetHashCode()
            => Hash;

        public string Format(byte pN, byte nN)
            => string.Format(string.Format("{0} {1}", RP.digits(0,pN), RP.digits(1, nN)), Packed, Native);

        public string Format()
            => Format(4,4);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(DataSize src)
            => Packed == src.Packed && Native == src.Native;

        [MethodImpl(Inline)]
        public int CompareTo(DataSize src)
            => Packed.CompareTo(src.Packed);

        [MethodImpl(Inline)]
        public static implicit operator DataSize((uint packed, uint native) src)
            => new DataSize(src.packed, src.native);

        [MethodImpl(Inline)]
        public static DataSize operator +(DataSize a, DataSize b)
            => new DataSize(a.Packed + b.Packed, a.Native + b.Native);

        [MethodImpl(Inline)]
        public static DataSize operator -(DataSize a, DataSize b)
            => new DataSize(a.Packed - b.Packed, a.Native - b.Native);

        [MethodImpl(Inline)]
        public static bit operator <(DataSize a, DataSize b)
            => a.Packed < b.Packed;

        [MethodImpl(Inline)]
        public static bit operator >(DataSize a, DataSize b)
            => a.Packed > b.Packed;

        [MethodImpl(Inline)]
        public static bit operator <=(DataSize a, DataSize b)
            => a.Packed <= b.Packed;

        [MethodImpl(Inline)]
        public static bit operator >=(DataSize a, DataSize b)
            => a.Packed >= b.Packed;

        [MethodImpl(Inline)]
        public static bool operator true(DataSize src)
            => src.IsNonEmpty;

        [MethodImpl(Inline)]
        public static bool operator false(DataSize src)
            => src.IsZero;

        [MethodImpl(Inline)]
        public static explicit operator bool(DataSize src)
            => src.IsNonZero;

        public static DataSize Empty => default;

        public static DataSize Zero => default;
    }
}