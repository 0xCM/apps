//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Resources;

    /// <summary>
    /// Describes an embedded resource
    /// </summary>
    public readonly struct Asset : IComparable<Asset>, IEquatable<Asset>, IAddressable
    {
        public readonly Name Name {get;}

        public readonly MemoryAddress Address;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public Asset(Name name, MemoryAddress address, ByteSize size)
        {
            Name = name;
            Address = address;
            Size = size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Bits;
        }

        public MemorySeg Segment
        {
            [MethodImpl(Inline)]
            get => new MemorySeg(Address, Size);
        }

        public ReadOnlySpan<byte> ResBytes
        {
            [MethodImpl(Inline)]
            get => api.view(this);
        }

        public AssetCatalogEntry CatalogEntry
        {
            [MethodImpl(Inline)]
            get => api.entry(this);
        }

        [MethodImpl(Inline)]
        public bool NameLike(string match)
            => Name.Format().Contains(match);

        [MethodImpl(Inline)]
        public int CompareTo(Asset src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public bool Equals(Asset src)
            => Address.Equals(src.Address);

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx3, Address, Size, Name);

        public override string ToString()
            => Format();

        MemoryAddress IAddressable.Address
            => Address;

        public static Asset Empty
            => new Asset(Name.Empty, 0, 0);
    }
}