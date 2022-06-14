//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IMemoryString : IAddressable, ICellular
    {
        ReadOnlySpan<byte> Data
            => Cells;

        ByteSize ISized.Size
            => Cells.Length;

        BitWidth ISized.Width
            => Cells.Length*8;

        Hash32 IHashed.Hash
            => core.hash(Cells);

        bool INullity.IsEmpty
            => Cells.Length == 0;

        bool INullity.IsNonEmpty
            => Cells.Length != 0;
    }

    [Free]
    public interface IMemoryString<T> : IMemoryString, ICellular<T>
        where T : unmanaged
    {
       Hash32 IHashed.Hash
            => core.hash(Cells);

    }

    [Free]
    public interface IMemoryString<F,T> : IMemoryString<T>, IString<F,T>
        where F : IMemoryString<F,T>, new()
        where T : unmanaged, IEquatable<T>, IComparable<T>
   {

    }
}