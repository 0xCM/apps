//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using B = ByteBlock32;
    using api = StorageBlocks;

    /// <summary>
    /// Covers 32 bytes = 256 bits of stack-allocated storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1), DataType("block<n:32,t:u8>")]
    public struct ByteBlock32 : IStorageBlock<B>
    {
        public const ushort Size = 32;

        public static N32 N => default;

        ByteBlock16 A;

        ByteBlock16 B;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public ByteBlock16 Lo
        {
            [MethodImpl(Inline)]
            get => A;
        }

        public ByteBlock16 Hi
        {
            [MethodImpl(Inline)]
            get => B;
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
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public ref T Cell<T>(int index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public ref T Cell<T>(uint index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public Vector256<T> Vector<T>()
            where T : unmanaged
                => gcpu.vload<T>(w256, @as<T>(First));

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Vector256<byte>(B src)
            => cpu.vload(default(W256), src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator B(Vector256<byte> src)
        {
            var dst = Empty;
            cpu.vstore(src, dst.Bytes);
            return dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator B(ReadOnlySpan<byte> src)
        {
            var dst = Empty;
            api.copy(src,ref dst);
            return dst;
        }

        public static B Empty => default;
    }
}