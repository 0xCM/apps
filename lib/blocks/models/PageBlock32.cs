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

    /// <summary>
    /// Reserves 16 pages of memory that covers 2^17 = 131,072 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock32 : IPageBlock<PageBlock32>
    {
        public const uint SZ = Pow2.T17;

        public const uint PageCount = 32;

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

    }
}