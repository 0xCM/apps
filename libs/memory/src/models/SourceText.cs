//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public unsafe readonly record struct SourceText : ILocatedSource<SourceText,char>
    {
        public readonly MemoryAddress Address;

        public readonly int Length;

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

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Cells.Length;
        }

        public Hash32 Hash
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
            => text.equals(Cells, src.Cells);

        public int CompareTo(SourceText src)
            => Cells.CompareTo(src.Cells, StringComparison.InvariantCulture);

        public string Format()
            => new string(Cells);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        MemoryAddress IAddressable.Address
            => Address;

        public static SourceText Empty => default;
    }
}