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

    using B = ByteBlock10;
    using api = ByteBlocks;

    /// <summary>
    /// 10 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ, Pack=1)]
    public struct ByteBlock10 : IDataBlock<B>
    {
        public const uint SZ = 10;

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

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        public static B Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator ByteBlock10(ulong src)
        {
            var dst = new ByteBlock10();
            @as<ulong>(dst.First) = src;
            return dst;
        }
    }
}