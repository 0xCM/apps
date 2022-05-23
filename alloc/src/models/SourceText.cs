//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public unsafe readonly struct SourceText : IMemoryString<char>, IComparable<SourceText>, IEquatable<SourceText>
    {
        public MemoryAddress Address {get;}

        public int Length {get;}

        [MethodImpl(Inline)]
        public SourceText(MemoryAddress @base, int length)
        {
            Address = @base;
            Length = length;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*2;
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<byte>(), Size);
        }

        public ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<char>(), Length);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.ghash.calc(Cells);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public bool Equals(SourceText src)
            => text.equals(Cells,src.Cells);

        public int CompareTo(SourceText src)
            => Cells.CompareTo(src.Cells, StringComparison.InvariantCulture);

        public string Format()
            => new string(Cells);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is SourceText l && Equals(l);

        public static SourceText Empty => default;

        public static bool operator==(SourceText a, SourceText b)
            => a.Equals(b);

        public static bool operator!=(SourceText a, SourceText b)
            => !a.Equals(b);
    }
}