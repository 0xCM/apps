//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using B = ByteBlock4;
    using api = StorageBlocks;

    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1), DataType("block<n:4,t:u8>")]
    [DataWidth(Size*8,Size*8)]
    public struct ByteBlock4 : IStorageBlock<B>
    {
        public const ushort Size = 4;

        public static N4 N => default;

        ByteBlock2 A;

        ByteBlock2 B;

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

        public string Format()
            => api.format(this);

        public string Format(bool prespec, bool uppercase)
            => api.format(this, Chars.Space, prespec, uppercase);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator B(uint src)
            => @as<uint,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(B src)
            => @as<B,uint>(src);

        [MethodImpl(Inline)]
        public static implicit operator B(ReadOnlySpan<byte> src)
            => api.block<B>(src);

        [MethodImpl(Inline)]
        public static implicit operator B(Span<byte> src)
            => api.block<B>(src);

        public static B Empty => default;
    }
}