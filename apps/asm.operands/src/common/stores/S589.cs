//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct DataStores
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count589<T>()
            where T : unmanaged
                => (uint)(core.size<T>()/S589.Size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S589<T> alloc589<T>(int count)
            where T : unmanaged
                => new S589<T>(count, default);

        [StructLayout(LayoutKind.Sequential, Size=Size, Pack=1)]
        public struct S589
        {
            public const int Size = 589;

            public Span<byte> Data
            {
                [MethodImpl(Inline)]
                get => core.bytes(this);
            }

            public ref byte First
            {
                [MethodImpl(Inline)]
                get => ref core.first(Data);
            }

            public ref byte this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref core.seek(Data,i);
            }

            public ref byte this[int i]
            {
                [MethodImpl(Inline)]
                get => ref core.seek(Data,i);
            }
        }

        [StructLayout(LayoutKind.Sequential, Size=S589.Size + 4, Pack=1)]
        public struct S589<T>
        {
            public readonly uint Count;

            S589 Data;

            [MethodImpl(Inline)]
            public S589(int count, S589 data)
            {
                Count = (uint)count;
                Data = data;
            }

            [MethodImpl(Inline)]
            public S589(uint count, S589 data)
            {
                Count = count;
                Data = data;
            }

            public ref T this[int i]
            {
                [MethodImpl(Inline)]
                get => ref core.@as<T>(core.seek(Data.First,i*core.size<T>()));
            }

            public ref T this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref core.@as<T>(core.seek(Data.First,i*core.size<T>()));
            }
        }
    }
}
