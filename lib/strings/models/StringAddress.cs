//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public unsafe readonly struct StringAddress : IAddressable
    {
        [MethodImpl(Inline)]
        public static StringAddress<N> natural<N>(string src)
            where N : unmanaged, ITypeNat
        {
            if(src.Length >= Typed.nat32i<N>())
                return new StringAddress<N>(strings.address(src));
            else
                return default;
        }

        public MemoryAddress Address {get;}

        [MethodImpl(Inline)]
        public StringAddress(MemoryAddress location)
        {
            Address = location == 0 ? strings.address(EmptyString) : location;
        }

        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<char>(), Length);
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => strings.length(this);
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Address.IsNonZero;
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => strings.render(this, ref i, dst);

        [MethodImpl(Inline)]
        public unsafe string Format()
            => strings.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(StringAddress src)
            => Address.Equals(src.Address);

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
            => strings.address(src);

        [MethodImpl(Inline)]
        public static implicit operator StringAddress(Name src)
            => strings.address(src.Content);

        public static StringAddress Zero
        {
            [MethodImpl(Inline)]
            get => new StringAddress(0);
        }
    }
}