//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using B = ByteBlock10;
    using api = StorageBlocks;

    /// <summary>
    /// 10 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1), DataType("block<n:10,t:u8>")]
    public struct ByteBlock10 : IStorageBlock<B>
    {
        public const uint Size = 10;

        ByteBlock9 A;

        ByteBlock1 B;

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
        public static implicit operator ByteBlock10(ulong src)
        {
            var dst = new ByteBlock10();
            @as<ulong>(dst.First) = src;
            return dst;
        }

        public static B Empty => default;
    }
}