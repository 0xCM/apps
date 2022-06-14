//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICellular : ISized, ICounted, IHashed, INullity
    {
        ReadOnlySpan<byte> Cells {get;}

        Hash32 IHashed.Hash
            => core.hash(Cells);

        uint CellCount
            => (uint)Cells.Length;

        uint CellSize
            => 1;

        ByteSize ISized.Size
            =>  CellSize * CellCount;

        BitWidth ISized.Width
            => CellSize*8*CellCount;

        uint ICounted.Count
            => CellCount;

        bool INullity.IsEmpty
            => CellCount == 0;

        bool INullity.IsNonEmpty
            => CellCount != 0;
    }

    public interface ICellular<T> : ICellular
        where T : unmanaged
    {
        new ReadOnlySpan<T> Cells {get;}

        uint ICounted.Count
            => (uint)Cells.Length;

        Hash32 IHashed.Hash
            => core.hash(Cells);

        ReadOnlySpan<byte> ICellular.Cells
            => core.recover<T,byte>(Cells);

        uint ICellular.CellCount
            => (uint)Cells.Length;

        uint ICellular.CellSize
            => core.size<T>();
    }
}