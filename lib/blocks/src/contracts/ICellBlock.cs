//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface ICellBlock<T> : IDataBlock
        where T : unmanaged
    {
        Span<T> Cells {get;}

        ByteSize IDataBlock.Size
            => Cells.Length*size<T>();

        Span<byte> IDataBlock.Bytes
            => bytes(Cells);
    }

    public interface ICellBlock<F,T> : ICellBlock<T>
        where T : unmanaged
        where F : ICellBlock<F,T>
    {

    }
}