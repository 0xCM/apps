//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        /// <summary>
        /// Presents a uint64 as an address
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(ulong src)
            => new MemoryAddress(src);

        /// <summary>
        /// Presents a <see cref='Ptr'/> as a <see cref='MemoryAddress'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(IntPtr src)
            => new MemoryAddress((ulong)src.ToInt64());

        [MethodImpl(Inline), Op]
        public unsafe static MemoryAddress address(void* pSrc)
            => address((ulong)pSrc);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<P>(P* pSrc)
            where P : unmanaged
                => new MemoryAddress(pSrc);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<T>(Span<T> src)
            => new MemoryAddress(pvoid(first(src)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<T>(ReadOnlySpan<T> src)
            => new MemoryAddress(pvoid(first(src)));

        /// <summary>
        /// Derives the address of a <see cref='Type'/> from the value of its <see cref='Type.TypeHandle' />
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemoryAddress address(Type src)
            => sys.handle(src).ToPointer();

        /// <summary>
        /// Returns the address of the first character in the source string
        /// </summary>
        /// <param name="src">The source string</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemoryAddress address(string src)
            => address(pchar(src));

        /// <summary>
        /// Determines the address of a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<T>(in T src)
            => new MemoryAddress(pvoid(src));

        /// <summary>
        /// Determines the address of the leading source cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op]
        public static unsafe MemoryAddress address<T>(T[] src)
            => pvoid(first(src));

        /// <summary>
        /// Determines the address of a cell in an array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The stored type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<T>(T[] src, int index)
            =>  pvoid(seek(src,index));

        [MethodImpl(Inline), Op]
        public static Address8 address8(byte src)
            => new Address8(src);

        [MethodImpl(Inline), Op]
        public static Address16 address16(ushort src)
            => new Address16(src);

        [MethodImpl(Inline), Op]
        public static Address32 address32(uint src)
            => new Address32(src);

        [MethodImpl(Inline), Op]
        public static Address64 address64(ulong src)
            => new Address64(src);

        [MethodImpl(Inline), Op]
        public static Address<W8,byte> address(W8 w, byte src)
            => new Address<W8,byte>(src);

        [MethodImpl(Inline), Op]
        public static Address<W16,ushort> address(W16 w, ushort src)
            => new Address<W16,ushort>(src);

        [MethodImpl(Inline), Op]
        public static Address<W32,uint> address(W32 w, uint src)
            => new Address<W32,uint>(src);

        [MethodImpl(Inline), Op]
        public static Address<W64,ulong> address(W64 w, ulong src)
            => new Address<W64,ulong>(src);
    }
}