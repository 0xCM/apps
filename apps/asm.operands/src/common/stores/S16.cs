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
        public static uint capacity<T>(N16 size)
            where T : unmanaged
                => (uint)(size<T>()/size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S16<T> alloc<T>(N16 size, int count)
            where T : unmanaged
                => new S16<T>(count, default);

        [StructLayout(LayoutKind.Sequential, Size=ByteBlock16.Size + 4, Pack=1)]
        public struct S16<T>
            where T : unmanaged
        {
            public readonly uint Count;

            ByteBlock16 Data;

            [MethodImpl(Inline)]
            public S16(int count, ByteBlock16 src)
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