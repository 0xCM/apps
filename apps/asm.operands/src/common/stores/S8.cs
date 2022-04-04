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
        public static uint capacity<T>(N8 size)
            where T : unmanaged
                => (uint)(size<T>()/size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S8<T> alloc<T>(N8 size, int count)
            where T : unmanaged
                => new S8<T>(count, default);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S8<T> init<T>(int count, ByteBlock8 data)
            where T : unmanaged
                => new S8<T>(count, data);

        [StructLayout(LayoutKind.Sequential, Size=ByteBlock8.Size + 4, Pack=1)]
        public struct S8<T>
            where T : unmanaged
        {
            public readonly uint Count;

            ByteBlock8 Data;

            [MethodImpl(Inline)]
            public S8(int count, ByteBlock8 src)
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