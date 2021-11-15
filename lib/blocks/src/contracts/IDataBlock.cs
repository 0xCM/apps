//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface IDataBlock
    {
        ByteSize Size {get;}

        Span<byte> Bytes {get;}
    }

    public interface IDataBlock<T> : IDataBlock
        where T : unmanaged, IDataBlock<T>
    {
        ByteSize IDataBlock.Size
            => size<T>();

        Span<byte> IDataBlock.Bytes
            => bytes((T)this);
    }
}