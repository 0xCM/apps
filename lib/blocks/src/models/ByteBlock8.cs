//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using B = ByteBlock8;
    using api = ByteBlocks;

    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1)]
    public struct ByteBlock8 : IDataBlock<B>
    {
        public const ushort Size = 8;

        public static N8 N => default;

        ByteBlock7 A;

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

        public ref uint Lo
        {
            [MethodImpl(Inline)]
            get => ref first32u(Bytes);
        }

        public ref uint Hi
        {
            [MethodImpl(Inline)]
            get => ref seek32(Bytes,1);
        }

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public static implicit operator B(ulong src)
            => @as<ulong,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator ulong(B src)
            => @as<B,ulong>(src);

        public static B Empty => default;
    }
}