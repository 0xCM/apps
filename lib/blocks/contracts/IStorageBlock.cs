//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface IStorageBlock
    {
        BlockKind Kind => BlockKind.Bytes;

        ByteSize Size {get;}

        Span<byte> Bytes {get;}
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