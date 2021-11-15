//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Resources;

    /// <summary>
    /// Describes an embedded resource
    /// </summary>
    public readonly struct Asset : IDataTypeComparable<Asset>, IAddressable
    {
        public Name Name {get;}

        public MemoryAddress Address {get;}

        public ByteSize Size {get;}

        [MethodImpl(Inline)]
        public Asset(Name name, MemoryAddress address, ByteSize size)
        {
            Name = name;
            Address = address;
            Size = size;
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

        public static Asset Empty
            => new Asset(Name.Empty, 0, 0);
    }
}