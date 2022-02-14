//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a reference to an immutable character sequence
    /// </summary>
    public unsafe readonly struct StringRef : IMemoryString<char>, IComparable<StringRef>, IEquatable<StringRef>
    {
        public MemoryAddress Address {get;}

        public uint Length {get;}

        [MethodImpl(Inline)]
        public StringRef(MemoryAddress @base, uint length)
        {
            Address = @base;
            Length = length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0 || Address == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0 || Address != 0;
        }

        public ref readonly char this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Address.Ref<char>(), index);
        }

        public ref readonly char this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Address.Ref<char>(), index);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*size<char>();
        }

        public uint Hash
            => alg.hash.marvin(Cells);

        public ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => cover<char>(Address.Pointer<char>(), Length);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => core.cover(Address.Pointer<byte>(), Size);
        }

        public bool Equals(StringRef src)
            => text.equals(Cells,src.Cells);

        public int CompareTo(StringRef src)
            => Cells.CompareTo(src.Cells, StringComparison.InvariantCulture);

        public string Format()
            => strings.format(this);


        public override string ToString()
            => Format();

        public static StringRef Empty
        {
            [MethodImpl(Inline)]
            get => new StringRef(0,0);
        }
    }
}