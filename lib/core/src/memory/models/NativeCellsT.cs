
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public unsafe readonly struct NativeCells<T> : INativeCells
    {
        internal readonly long Allocation;

        public MemoryAddress BaseAddress {get;}

        public uint CellCount {get;}

        public uint CellSize {get;}

        [MethodImpl(Inline)]
        public NativeCells(long id, MemoryAddress @base, uint cellsize, uint count)
        {
            Allocation = id;
            BaseAddress = @base;
            CellCount = count;
            CellSize = cellsize;
        }

        [MethodImpl(Inline)]
        public ref NativeCell<T> Cell(uint index)
            => ref core.@as<NativeCell<T>>((BaseAddress + CellSize*index).Pointer());

        [MethodImpl(Inline)]
        public ref T Content(uint index)
            => ref Cell(index).Content;

        public void Dispose()
            => NativeCells.free(Allocation);
    }
}
