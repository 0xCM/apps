//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IMemoryRange : IAddressable, ISized
    {
        MemoryAddress Min {get;}

        MemoryAddress Max {get;}

        MemoryAddress IAddressable.Address
            => Min;

        ByteSize ISized.Size
            => (ulong)Max - (ulong)Min;

        BitWidth ISized.Width
            => ((ulong)Max - (ulong)Min)*8;
    }

    public interface IMemoryRange<F> : IMemoryRange, IEquatable<F>, IComparable<F>, ITextual
        where F : unmanaged, IMemoryRange<F>
    {

    }
}