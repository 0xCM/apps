//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct DataStores
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint capacity<T>(N12 size)
            where T : unmanaged
                => (uint)(size<T>()/size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S12<T> alloc<T>(N12 size, int count)
            where T : unmanaged
                => new S12<T>(count, default);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S12<T> init<T>(int count, ByteBlock12 data)
            where T : unmanaged
                => new S12<T>(count, data);

        [StructLayout(LayoutKind.Sequential, Size=ByteBlock12.Size + 4, Pack=1)]
        public struct S12<T>
            where T : unmanaged
        {
            public readonly uint Count;

            ByteBlock12 Data;

            [MethodImpl(Inline)]
            public S12(int count, ByteBlock12 src)
            {
                Count = (byte)count;
                Data = src;
            }

            public ref T this[int i]
            {
                [MethodImpl(Inline)]
                get => ref @as<T>(seek(Data.First,i*size<T>()));
            }

            public ref T this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref @as<T>(seek(Data.First,i*size<T>()));
            }
        }
    }
}