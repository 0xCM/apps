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
        public static uint capacity<T>(N256 size)
            where T : unmanaged
                => (uint)(size<T>()/size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S256<T> alloc<T>(N256 size, int count)
            where T : unmanaged
                => new S256<T>(count, default);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S256<T> init<T>(int count, ByteBlock256 data)
            where T : unmanaged
                => new S256<T>(count, data);

        [StructLayout(LayoutKind.Sequential, Size=ByteBlock256.Size + 4, Pack=1)]
        public struct S256<T>
            where T : unmanaged
        {
            public readonly uint Count;

            ByteBlock256 Data;

            [MethodImpl(Inline)]
            public S256(int count, ByteBlock256 src)
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