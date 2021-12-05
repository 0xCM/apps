//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;
    using static core;

    public readonly struct CliBlobIndex : ICliHeapKey<CliBlobIndex>
    {
        public CliHeapKind HeapKind => CliHeapKind.Blob;

        public uint Value {get;}

        [MethodImpl(Inline)]
        public CliBlobIndex(uint src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public CliBlobIndex(BlobHandle src)
        {
            Value = u32(src);
        }

        public string Format()
            => Value.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BlobHandle(CliBlobIndex src)
            => @as<CliBlobIndex,BlobHandle>(src);

        [MethodImpl(Inline)]
        public static implicit operator CliBlobIndex(BlobHandle src)
            => new CliBlobIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator CliHeapKey(CliBlobIndex src)
            => new CliHeapKey(src.HeapKind, src.Value);
    }
}