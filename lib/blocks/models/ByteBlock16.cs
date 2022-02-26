//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using B = ByteBlock16;
    using api = StorageBlocks;

    /// <summary>
    /// Defines 16 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1), DataType("block<n:16,t:u8>")]
    public struct ByteBlock16 : IStorageBlock<B>
    {
        public const ushort Size = 16;

        public static N16 N => default;

        public ulong A;

        public ulong B;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref first(Bytes);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => api.empty(this);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !api.empty(this);
        }

        public ref byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public ref byte this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        [MethodImpl(Inline)]
        public ref T Cell<T>(int index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public ref T Cell<T>(uint index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public Vector128<T> Vector<T>()
            where T : unmanaged
                => gcpu.vload<T>(w128, @as<T>(First));

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Vector128<byte>(B src)
            => gcpu.vload(default(W128), src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator B(Vector128<byte> src)
        {
            var dst = Empty;
            gcpu.vstore(src, dst.Bytes);
            return dst;
        }

        public static B Empty => default;
    }
}