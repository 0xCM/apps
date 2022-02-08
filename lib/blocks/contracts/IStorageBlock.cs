//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface IStorageBlock : IHashed, INullity
    {
        ByteSize Size {get;}

        Span<byte> Bytes {get;}

        BlockKind Kind
            => BlockKind.Bytes;

        bool INullity.IsEmpty
            => Bytes.Length == 0;

        bool INullity.IsNonEmpty
            => Bytes.Length != 0;

        uint IHashed.Hash
            => alg.ghash.calc(Bytes);
    }

    public interface IStorageBlock<T> : IStorageBlock
        where T : unmanaged, IStorageBlock<T>
    {
        ByteSize IStorageBlock.Size
            => size<T>();

        Span<byte> IStorageBlock.Bytes
            => bytes((T)this);
    }
}