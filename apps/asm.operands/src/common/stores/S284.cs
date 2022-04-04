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
        public static uint count284<T>()
            where T : unmanaged
                => (uint)(size<T>()/S284.Size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S284<T> alloc284<T>(int count)
            where T : unmanaged
                => new S284<T>(count, default);

        [StructLayout(LayoutKind.Sequential, Size=(int)Size, Pack=1)]
        public struct S284
        {
            public const int Size = 284;

            public Span<byte> Data
            {
                [MethodImpl(Inline)]
                get => bytes(this);
            }

            public ref byte First
            {
                [MethodImpl(Inline)]
                get => ref first(Data);
            }

            public ref byte this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref seek(Data,i);
            }

            public ref byte this[int i]
            {
                [MethodImpl(Inline)]
                get => ref seek(Data,i);
            }
        }

        [StructLayout(LayoutKind.Sequential, Size=S284.Size + 4, Pack=1)]
        public struct S284<T>
        {
            public readonly uint Count;

            S284 Data;

            [MethodImpl(Inline)]
            public S284(int count, S284 data)
            {
                Count = (uint)count;
                Data = data;
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