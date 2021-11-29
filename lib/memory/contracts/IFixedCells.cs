//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IFixedCells
    {
        MemoryAddress Address {get;}

        uint CellCount {get;}

        ByteSize CellSize {get;}

        Type CellType {get;}
    }

    [Free]
    public interface IFixedCells<T> : IFixedCells
        where T : struct
    {
        ByteSize IFixedCells.CellSize
            => size<T>();

        Type IFixedCells.CellType
            => typeof(T);

        Span<T> Edit
            => cover<T>(Address, CellCount);

        ReadOnlySpan<T> View
            => cover<T>(Address, CellCount);
    }

    [Free]
    public interface IFixedStorage<S>
        where S : struct
    {
        ref S Buffer {get;}
        Span<T> Edit<T>()
            => cover<T>(@as<S,T>(Buffer), size<S>()/size<T>());

        ReadOnlySpan<T> View<T>()
            => Edit<T>();
    }
}