//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static Chars;

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