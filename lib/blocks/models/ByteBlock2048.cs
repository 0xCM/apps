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

    using B = ByteBlock2048;
    using api = ByteBlocks;

    [StructLayout(LayoutKind.Sequential, Size = (int)Size, Pack=1), DataType("block<n:2048,t:u8>")]
    public struct ByteBlock2048 : IStorageBlock<B>
    {
        public const ushort Size = 2048;

        ByteBlock1024 A;

        ByteBlock1024 B;

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

        [MethodImpl(Inline)]
        public Span<T> Edit<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public ReadOnlySpan<T> View<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        public static B Empty => default;
   }
}