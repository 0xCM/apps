//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    using B = ByteBlock64;
    using api = ByteBlocks;

    /// <summary>
    /// Covers 64 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1)]
    public struct ByteBlock64 : IDataBlock<B>
    {
        public const ushort Size = 64;

        ByteBlock32 A;

        ByteBlock32 B;

        [MethodImpl(Inline)]
        public ByteBlock64(ByteBlock32 a, ByteBlock32 b)
        {
            A = a;
            B = b;
        }

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

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public Vector512<T> Vector<T>()
            where T : unmanaged
                => vcore.vload<T>(w512, @as<T>(First));

        [MethodImpl(Inline)]
        public static implicit operator Vector512<byte>(B src)
            => vcore.vload(default(W512), src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator B(Vector512<byte> src)
        {
            var dst = Empty;
            vcore.vstore(src, dst.Bytes);
            return dst;
        }

        public static B Empty => default;
    }
}