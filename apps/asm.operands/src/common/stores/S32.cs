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
        public static uint capacity<T>(N32 size)
            where T : unmanaged
                => (uint)(size<T>()/size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S32<T> alloc<T>(N32 size, int count)
            where T : unmanaged
                => new S32<T>(count, default);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S32<T> init<T>(int count, ByteBlock32 data)
            where T : unmanaged
                => new S32<T>(count, data);

        [StructLayout(LayoutKind.Sequential, Size=ByteBlock32.Size + 4, Pack=1)]
        public struct S32<T>
            where T : unmanaged
        {
            public readonly uint Count;

            ByteBlock32 Data;

            [MethodImpl(Inline)]
            public S32(int count, ByteBlock32 src)
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