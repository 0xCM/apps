//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface ICellBlock<T> : IStorageBlock
        where T : unmanaged
    {
        BlockKind IStorageBlock.Kind
            => BlockKind.Generic;

        Span<T> Cells {get;}

        ByteSize IStorageBlock.Size
            => Cells.Length*size<T>();

        Span<byte> IStorageBlock.Bytes
            => bytes(Cells);
    }

    public interface ICellBlock<F,T> : ICellBlock<T>
        where T : unmanaged
        where F : ICellBlock<F,T>
    {

    }
}