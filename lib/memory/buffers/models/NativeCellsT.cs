
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe readonly struct NativeCells<T> : INativeCells
    {
        readonly long Id;

        public MemoryAddress BaseAddress {get;}

        public uint CellCount {get;}

        public uint CellSize {get;}

        public BitWidth Width {get;}

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => (ByteSize)Width;
        }

        [MethodImpl(Inline)]
        public NativeCells(long id, MemoryAddress @base, uint cellsize, uint count)
        {
            Id = id;
            BaseAddress = @base;
            CellCount = count;
            CellSize = cellsize;
            Width = (count*cellsize)*8;
        }

        [MethodImpl(Inline)]
        public ref NativeCell<T> Cell(uint index)
            => ref core.@as<NativeCell<T>>((BaseAddress + CellSize*index).Pointer());

        [MethodImpl(Inline)]
        public ref T Content(uint index)
            => ref Cell(index).Content;

        public void Dispose()
            => NativeCells.free(Id);
    }
}
