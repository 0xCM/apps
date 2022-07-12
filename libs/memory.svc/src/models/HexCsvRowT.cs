//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HexCsvRow<T>
        where T : unmanaged, IStorageBlock<T>
    {
        const string TableId = "hex";

        [Render(16)]
        public MemoryAddress Address;

        [Render(1)]
        public T Data;

        [MethodImpl(Inline)]
        public HexCsvRow(MemoryAddress address, T data)
        {
            Address = address;
            Data = data;
        }
    }
}