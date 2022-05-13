//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBitfieldDataset
    {
        uint FieldCount {get;}

        string BitrenderPattern {get;}

        ref readonly Index<uint> Offsets {get;}

        ref readonly Index<byte> Widths {get;}

        ref readonly BitfieldIntervals Intervals {get;}

        ref readonly Index<BitMask> Masks {get;}

        ref readonly byte Width(int index)
            => ref Widths[index];

        ref readonly byte Width(uint index)
            => ref Widths[index];

        ref readonly uint Offset(int index)
            => ref Offsets[index];
        ref readonly uint Offset(uint index)
            => ref Offsets[index];

        ref readonly BitMask Mask(int index)
            => ref Masks[index];

        ref readonly BitMask Mask(uint index)
            => ref Masks[index];

        ref readonly BitfieldInterval Interval(int index)
            => ref Intervals[index];

        ref readonly BitfieldInterval Interval(uint index)
            => ref Intervals[index];
    }

    public interface IBitfieldDataset<F> : IBitfieldDataset
        where F : unmanaged, Enum
    {
        ref readonly Index<F> Fields {get;}

        new ref readonly BitfieldIntervals<F> Intervals {get;}

        ref readonly BitfieldInterval<F> Interval(F field);
    }
}