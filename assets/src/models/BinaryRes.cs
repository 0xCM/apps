//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Chars;

    public interface IBinaryResLookup : IContentIndex<BinaryRes>
    {
    }

    /// <summary>
    /// Describes an embedded data resource
    /// </summary>
    public readonly struct BinaryRes
    {
        public Identifier Id {get;}

        public PartId Owner {get;}

        public ByteSize Size {get;}

        public MemoryAddress Address {get;}

        [MethodImpl(Inline)]
        public BinaryRes(PartId part, string id, ByteSize length, MemoryAddress address)
        {
            Owner = part;
            Id = id;
            Size = length;
            Address = address;
        }

        public bool IsEmpty
            => Address == 0;

        public string Uri
            => string.Concat("res", Colon, FSlash, FSlash, Owner.Format(), FSlash, Id);

        public unsafe ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => new ReadOnlySpan<byte>(Address.Pointer<byte>(), Size);
        }
    }
}