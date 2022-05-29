//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Specifies an address for a null-terminated unicode string
    /// </summary>
    public unsafe readonly struct StringAddress : IAddressable
    {
        [MethodImpl(Inline), Op]
        public static StringAddress from(string src)
            => new StringAddress(core.address(src));

        [MethodImpl(Inline)]
        public static StringAddress<N> natural<N>(string src)
            where N : unmanaged, ITypeNat
        {
            if(src.Length >= Typed.nat32i<N>())
                return new StringAddress<N>(from(src));
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static unsafe string format(StringAddress src)
            => new string(src.Address.Pointer<char>());

        [MethodImpl(Inline), Op]
        public static unsafe string format<N>(StringAddress<N> src)
            where N : unmanaged, ITypeNat
                => new string(src.Address.Pointer<char>());

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public StringAddress(MemoryAddress location)
        {
            Address = location == 0 ? core.address(EmptyString) : location;
        }

        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<char>(), Length);
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => MemoryStrings.length(this);
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Address.IsNonZero;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*2;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Bits;
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => MemoryStrings.render(this, ref i, dst);

        [MethodImpl(Inline)]
        public unsafe string Format()
            => StringAddress.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(StringAddress src)
            => Address.Equals(src.Address);

        MemoryAddress IAddressable.Address
            => Address;

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(StringAddress src)
            => src.Address;

        [MethodImpl(Inline)]
        public static explicit operator StringAddress(ulong src)
            => new StringAddress(src);

        [MethodImpl(Inline)]
        public static explicit operator StringAddress(MemoryAddress src)
            => new StringAddress(src);

        [MethodImpl(Inline)]
        public static implicit operator StringAddress(ResourceAddress src)
            => new StringAddress(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator StringAddress(string src)
            => from(src);

        [MethodImpl(Inline)]
        public static implicit operator StringAddress(Name src)
            => from(src.Content);

        public static StringAddress Zero
        {
            [MethodImpl(Inline)]
            get => new StringAddress(0);
        }
    }
}