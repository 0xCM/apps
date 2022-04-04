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
        public static uint capacity<T>(N64 size)
            where T : unmanaged
                => (uint)(size<T>()/size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S64<T> alloc<T>(N64 size, int count)
            where T : unmanaged
                => new S64<T>(count, default);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S64<T> init<T>(int count, ByteBlock64 data)
            where T : unmanaged
                => new S64<T>(count, data);

        [StructLayout(LayoutKind.Sequential, Size=ByteBlock64.Size + 4, Pack=1)]
        public struct S64<T>
            where T : unmanaged
        {
            public readonly uint Count;

            ByteBlock64 Data;

            [MethodImpl(Inline)]
            public S64(int count, ByteBlock64 src)
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