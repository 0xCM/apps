//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static core;

    [Free]
    public interface ILocatedCells
    {
        MemoryAddress Address {get;}

        uint CellCount {get;}

        ByteSize CellSize {get;}

        Type CellType {get;}
    }

    [Free]
    public interface ILocatedCells<T> : ILocatedCells
        where T : struct
    {
        ByteSize ILocatedCells.CellSize
            => size<T>();

        Type ILocatedCells.CellType
            => typeof(T);

        Span<T> Edit
            => cover<T>(Address, CellCount);

        ReadOnlySpan<T> View
            => cover<T>(Address, CellCount);
    }
    public interface ILocatedSource : ISourceCode, IMemoryString
    {
        MemoryAddress Location {get;}

        MemoryAddress IMemoryString.Address
            => Location;

        ReadOnlySpan<byte> IMemoryString.Bytes
            => Data;
    }

    public interface ILocatedSource<T> : ILocatedSource, ISourceCode<T>, IMemoryString<T>
        where T : unmanaged, IEquatable<T>
    {
    }

    public interface ILocatedSource<H,T> : ISourceCode<H,T>, ILocatedSource<T>
        where T : unmanaged, IEquatable<T>
        where H : ISourceCode<H,T>
    {

    }
}