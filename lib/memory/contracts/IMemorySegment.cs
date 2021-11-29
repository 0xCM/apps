//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a segment reference
    /// </summary>
    public interface IMemorySegment : INullity, ITextual, IHashed
    {
        MemoryAddress BaseAddress {get;}

        uint Length  {get;}

        bool INullity.IsEmpty
            => Length == 0;

        uint CellCount
            => Length * CellSize;

        uint CellSize
            => 1;

        ByteSize SegSize
            => Length;

        ref byte Cell(int index);

        ref byte this[int index]
            => ref Cell(index);
    }
}