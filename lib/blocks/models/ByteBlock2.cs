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

    using B = ByteBlock2;
    using api = ByteBlocks;

    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1)]
    public struct ByteBlock2 : IDataBlock<B>
    {
        public const ushort Size = 2;

        ByteBlock1 A;

        ByteBlock1 B;

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        [MethodImpl(Inline)]
        public static implicit operator B(ushort src)
            => @as<ushort,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(B src)
            => @as<B,ushort>(src);

        public static B Empty => default;
    }
}