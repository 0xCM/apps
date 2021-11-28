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

    using B = ByteBlock16;
    using api = ByteBlocks;

    /// <summary>
    /// Defines 16 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1)]
    public struct ByteBlock16 : IDataBlock<B>
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
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public Vector128<T> Vector<T>()
            where T : unmanaged
                => vcore.vload<T>(w128, @as<T>(First));

        [MethodImpl(Inline)]
        public static implicit operator Vector128<byte>(B src)
            => vcore.vload(default(W128), src.Bytes);

        [MethodImpl(Inline)]
        public static implicit operator B(Vector128<byte> src)
        {
            var dst = Empty;
            vcore.vstore(src, dst.Bytes);
            return dst;
        }

        public static B Empty => default;
    }
}