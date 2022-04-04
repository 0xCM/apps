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
        public static uint capacity<T>(N4 size)
            where T : unmanaged
                => (uint)(size<T>()/size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S4<T> alloc<T>(N4 size, int count)
            where T : unmanaged
                => new S4<T>(count, default);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S4<T> init<T>(int count, ByteBlock4 data)
            where T : unmanaged
                => new S4<T>(count, data);

        [StructLayout(LayoutKind.Sequential, Size=ByteBlock4.Size + 4, Pack=1)]
        public struct S4<T>
            where T : unmanaged
        {
            public readonly uint Count;

            ByteBlock4 Data;

            [MethodImpl(Inline)]
            public S4(int count, ByteBlock4 src)
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