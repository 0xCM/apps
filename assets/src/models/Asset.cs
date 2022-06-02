//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    /// <summary>
    /// Describes an embedded resource
    /// </summary>
    public readonly struct Asset : IComparable<Asset>, IEquatable<Asset>, IAddressable
    {
        public readonly string Name;

        public readonly MemoryAddress Address;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public Asset(string name, MemoryAddress address, ByteSize size)
        {
            Name = name;
            Address = address;
            Size = size;
        }

        public FS.FileName FileName
            => FS.file(Name.ReplaceAny(Path.GetInvalidPathChars(), Chars.Underscore));

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
            get => Assets.view(this);
        }

        public AssetCatalogEntry CatalogEntry
        {
            [MethodImpl(Inline)]
            get => Assets.entry(this);
        }

        [MethodImpl(Inline)]
        public bool NameLike(string match)
            => Name.Contains(match);

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
            => new Asset(EmptyString, 0, 0);
    }
}