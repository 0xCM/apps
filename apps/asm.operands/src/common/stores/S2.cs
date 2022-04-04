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
        public static uint capacity<T>(N2 size)
            where T : unmanaged
                => (uint)(size<T>()/size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S2<T> alloc<T>(N2 size, int count)
            where T : unmanaged
                => new S2<T>(count, default);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S2<T> init<T>(int count, ByteBlock2 data)
            where T : unmanaged
                => new S2<T>(count, data);

        [StructLayout(LayoutKind.Sequential, Size=ByteBlock2.Size + 4, Pack=1)]
        public struct S2<T>
            where T : unmanaged
        {
            public readonly uint Count;

            ByteBlock2 Data;

            [MethodImpl(Inline)]
            public S2(int count, ByteBlock2 src)
            {
                Count = (uint)count;
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