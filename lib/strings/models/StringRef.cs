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
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRef<S> word<S>(in StringRefs<S> src, ulong index, ulong length)
            where S : unmanaged
                => new StringRef<S>(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRef<S> word<S>(in StringRefs<S> src, long index, long length)
            where S : unmanaged
                => new StringRef<S>(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op]
        public static StringRef word(in StringRefs src, ulong index, ulong length)
            => new StringRef(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op]
        public static StringRef word(in StringRefs src, long index, long length)
            => new StringRef(src.Address(index), (uint)length);

        [Op]
        public static string format(in StringRef src)
            => new string(src.Cells);

        public static string format<S>(in StringRef<S> src)
            where S : unmanaged
                => new string(core.recover<S,char>(src.View));

        [Op]
        public static string format(in StringRefs src)
            => new string(src.View);

        public static string format<S>(in StringRefs<S> src)
            where S : unmanaged
                => new string(core.recover<S,char>(src.View));

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
            => format(this);


        public override string ToString()
            => Format();

        public static StringRef Empty
        {
            [MethodImpl(Inline)]
            get => new StringRef(0,0);
        }
    }
}