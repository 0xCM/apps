//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct seq
    {
        /// <summary>
        /// Deposits index-identified cells from a specified <see cref='ReadOnlySpan{T}'/> into as specified target <see cref='Span{T}'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="indices">The index selection</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void select<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> indices, Span<T> dst)
            => select<byte,T>(src, indices, dst);

        /// <summary>
        /// Deposits index-identified cells from a specified <see cref='ReadOnlySpan{T}'/> into as specified target <see cref='Span{T}'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="indices">The index selection</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void select<T>(ReadOnlySpan<T> src, ReadOnlySpan<ushort> indices, Span<T> dst)
            => select<ushort,T>(src, indices, dst);

        /// <summary>
        /// Deposits index-identified cells from a specified <see cref='ReadOnlySpan{T}'/> into as specified target <see cref='Span{T}'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="indices">The index selection</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void select<T>(ReadOnlySpan<T> src, ReadOnlySpan<uint> indices, Span<T> dst)
            => select<uint,T>(src, indices, dst);

        /// <summary>
        /// Deposits index-identified cells from a specified <see cref='ReadOnlySpan{T}'/> into as specified target <see cref='Span{T}'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="indices">The index selection</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void select<T>(ReadOnlySpan<T> src, ReadOnlySpan<ulong> indices, Span<T> dst)
            => select<ulong,T>(src, indices, dst);

        /// <summary>
        /// Deposits index-identified cells from a specified <see cref='ReadOnlySpan{T}'/> into as specified target <see cref='Span{T}'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="indices">The index selection</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <typeparam name="I">The index type</typeparam>
        [MethodImpl(Inline)]
        public static void select<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            if(size<I>() == 1)
                select8(src, indices, dst);
            else if(size<I>() == 2)
                select16(src, indices, dst);
            else if(size<I>() == 4)
                select32(src, indices, dst);
            else if(size<I>() == 8)
                select64(src, indices, dst);
            else
                throw no<I>();
        }

        [MethodImpl(Inline)]
        static void select8<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            var count = (byte)indices.Length;
            for(byte i=0; i<count; i++)
                seek(dst,i) = skip(src, @as<I,byte>(skip(indices,i)));
        }

        [MethodImpl(Inline)]
        static void select16<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            var count = (ushort)indices.Length;
            for(ushort i=0; i<count; i++)
                seek(dst,i) = skip(src, @as<I,ushort>(skip(indices,i)));
        }

        [MethodImpl(Inline)]
        static void select32<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            var count = (uint)indices.Length;
            for(uint i=0; i<count; i++)
                seek(dst,i) = skip(src, @as<I,uint>(skip(indices,i)));
        }

        [MethodImpl(Inline)]
        static void select64<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            var count = (ulong)indices.Length;
            for(ulong i=0; i<count; i++)
                seek(dst,i) = skip(src, @as<I,ulong>(skip(indices,i)));
        }
    }
}