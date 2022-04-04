//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    /*
    partial struct DataStores
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count`{0}`<T>()
            where T : unmanaged
                => (uint)(core.size<T>()/S`{0}`.Size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S`{0}`<T> alloc`{0}`<T>(int count)
            where T : unmanaged
                => new S`{0}`<T>(count, default);

        [StructLayout(LayoutKind.Sequential, Size=Size, Pack=1)]
        public struct S`{0}`
        {
            public const int Size = `{0}`;

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

        [StructLayout(LayoutKind.Sequential, Size=S`{0}`.Size + 4, Pack=1)]
        public struct S`{0}`<T>
        {
            public readonly uint Count;

            S`{0}` Data;

            [MethodImpl(Inline)]
            public S`{0}`(int count, S`{0}` data)
            {
                Count = (uint)count;
                Data = data;
            }

            [MethodImpl(Inline)]
            public S`{0}`(uint count, S`{0}` data)
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

    */

    partial struct DataStores
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count568<T>()
            where T : unmanaged
                => (uint)(core.size<T>()/S568.Size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S568<T> alloc568<T>(int count)
            where T : unmanaged
                => new S568<T>(count, default);

        [StructLayout(LayoutKind.Sequential, Size=Size, Pack=1)]
        public struct S568
        {
            public const int Size = 568;

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

        [StructLayout(LayoutKind.Sequential, Size=S568.Size + 4, Pack=1)]
        public struct S568<T>
        {
            public readonly uint Count;

            S568 Data;

            [MethodImpl(Inline)]
            public S568(int count, S568 data)
            {
                Count = (uint)count;
                Data = data;
            }

            [MethodImpl(Inline)]
            public S568(uint count, S568 data)
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