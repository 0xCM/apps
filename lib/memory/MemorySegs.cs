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

    [ApiHost]
    public readonly struct MemorySegs
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Covers a memory reference with a readonly span
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> view<T>(MemorySeg src)
            => cover(src.BaseAddress.Ref<T>(), count<T>(src));

        /// <summary>
        /// Computes the whole number of T-cells identified by a reference
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint count<T>(MemorySeg src)
            => (uint)(src.Length/size<T>());

        /// <summary>
        /// Computes the whole number of <typeparamref name='T'/> cells covered by a specified <see cref='MemoryRange'/>
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint cells<T>(MemoryRange src)
            => (uint)(src.Size/size<T>());

        /// <summary>
        /// Covers a <see cref='MemoryRange'/> with a readonly span
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> view<T>(MemoryRange src)
            => cover(src.Min.Ref<T>(), cells<T>(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(ReadOnlySpan<SegRef> src, Span<T> dst)
            where T : struct
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = first(recover<T>(skip(src,i).Edit));
        }

        [MethodImpl(Inline), Op]
        public static void store(BinaryCode src, ByteSize size, MemoryAddress dst)
            => src.View.CopyTo(edit(dst, size));

        /// <summary>
        /// Defines a memory <see cref='MemorySeg'/> with a specified base and size
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="bytes">The number of reference bytes</param>
        [MethodImpl(Inline), Op]
        public static MemorySeg define(MemoryAddress @base, ByteSize bytes)
            => new MemorySeg(@base,bytes);

        /// <summary>
        /// Defines a memory <see cref='MemorySeg'/> over source span content
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static MemorySeg define(ReadOnlySpan<byte> src)
            => define((ulong)gptr(src), src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe MemorySeg define(string src)
            => define(pchar(src), (uint)src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe MemorySeg define(char* src, uint count)
            => new MemorySeg(address(src), count*2);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<byte> segref(in byte src, ByteSize size)
            => new SegRef<byte>(new SegRef(address(src), size));

        [MethodImpl(Inline), Op]
        public static ulong sib(MemorySeg n, int i, byte scale, ushort offset)
            => ((ulong)scale)*core.cell(n.Load(),i) + (ulong)offset;

        [MethodImpl(Inline), Op]
        public static ulong sib(ReadOnlySpan<MemorySeg> refs, in MemorySlot n, int i, byte scale, ushort offset)
            => sib(segment(refs,n), i, scale,offset);

        /// <summary>
        /// Captures a parametric reference to cell content beginning at a specified address
        /// </summary>
        /// <param name="src">The content address</param>
        /// <param name="count">The content cell count</param>
        /// <typeparam name="T">The content type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<T> segref<T>(MemoryAddress address, Count count)
            where T : unmanaged
                => new SegRef<T>(address, size<T>(count));

        /// <summary>
        /// Captures a sized readonly parametric reference to source span content
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SegRef<T> segref<T>(ReadOnlySpan<T> src)
            => new SegRef<T>(address(first(src)), size<T>((uint)src.Length));

        /// <summary>
        /// Captures a character segment over source string content
        /// </summary>
        /// <param name="src">The source string</param>
        [MethodImpl(Inline), Op]
        public static unsafe SegRef<char> segref(string src)
            => new SegRef<char>(new SegRef(core.address(src), (uint)src.Length*2));

        /// <summary>
        /// Captures a segment reference
        /// </summary>
        /// <param name="src">The leading cell</param>
        /// <param name="count">The covered cell count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<T> segref<T>(in T src, uint count)
            => new SegRef(core.address(src), count*core.size<T>());

        /// <summary>
        /// Captures a segment reference
        /// </summary>
        /// <param name="src">The leading cell</param>
        /// <param name="count">The covered cell count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SegRef<T> segref<T>(in T src, int count)
            => new SegRef<T>(core.address(src), core.size<T>((uint)count));

        /// <summary>
        /// Captures an untyped sized reference
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <param name="size">The data size</param>
        [MethodImpl(Inline), Op]
        public static unsafe SegRef segref(void* pSrc, ByteSize size)
            => new SegRef(core.address(pSrc), size);

        /// <summary>
        /// Captures a pointer-identified segment reference of a specified size
        /// </summary>
        /// <param name="pSrc">A base address pointer</param>
        /// <param name="size">The segment size, in bytes</param>
        /// <typeparam name="T">The sement type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SegRef<byte> segref(byte* pSrc, ByteSize size)
            => new SegRef<byte>(pSrc, size);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SegRef<T> segref<T>(T[] src)
            => segref<T>(first(src), (uint)src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe SegRef<sbyte> segref(sbyte[] src)
            => segref<sbyte>(address(src), (uint)src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe SegRef<byte> segref(byte[] src)
            => segref<byte>(address(src), (uint)src.Length);

        [MethodImpl(Inline), Op]
        public static unsafe SegRef<ulong> segref(ulong[] src)
            => segref<ulong>(address(src), (uint)src.Length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SegRef<T> segref<T>(Span<T> src)
            => new SegRef<T>(pvoid(first(src)), size<T>((uint)src.Length));

        /// <summary>
        /// Covers a <see cref='MemoryRange'/> with a <see cref='Span{T}'
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> edit<T>(MemoryRange src)
            => core.cover(src.Min.Ref<T>(), core.cells<T>(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> edit<T>(SegRef src)
            => src.Data<T>();

        /// <summary>
        /// Covers a memory segment with a span
        /// </summary>
        /// <param name="src">The base address</param>
        /// <param name="size">The segment size, in bytes</param>
        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> edit(MemoryAddress src, ByteSize size)
            => core.cover<byte>(src.Ref<byte>(), size);

        [MethodImpl(Inline), Op]
        public static SegRef<T>[] segrefs<T>(ReadOnlySpan<T> src)
            where T : struct
        {
            var dst = alloc<SegRef<T>>(src.Length);
            segrefs(src, dst);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void segrefs<T>(ReadOnlySpan<T> src, Span<SegRef<T>> dst)
            where T : struct
        {
            for(var i=0u; i<src.Length; i++)
                seek(dst,i) = segref(skip<T>(src,i), size<T>());
        }

        [MethodImpl(Inline), Op]
        public static ref readonly MemorySeg segment(ReadOnlySpan<MemorySeg> refs, MemorySlot n)
            => ref core.cell(refs, n);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> load<T>(MemorySeg src)
            where T : struct
                => src.Load<T>();

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> load(ReadOnlySpan<MemorySeg> src, MemorySlot n)
            => segment(src,n).Load();

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> slice(ReadOnlySpan<MemorySeg> refs, MemorySlot n, int offset)
            => core.slice(load(refs, n),offset);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> slice(ReadOnlySpan<MemorySeg> refs, MemorySlot n, int offset, int length)
            => core.slice(load(refs,n), offset, length);
        [Op]
        public static void materialize(ReadOnlySpan<SegRef> src, Span<byte> dst, byte? delimiter = null)
        {
            var m = src.Length;
            var n = dst.Length;
            var o = 0u;
            var d = delimiter ?? 0;
            for(var i=0u; i<m; i++)
            {
                var c = skip(src,i).Edit;
                var p = c.Length;

                for(var j=0u; j<p && o<n; j++, o++)
                    seek(dst,o) = core.skip(c,j);

                if(delimiter != null)
                    seek(dst, ++o) = d;
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T cell<T>(ReadOnlySpan<MemorySeg> src, MemorySlot n, long offset)
             where T : struct
                => ref core.cell<T>(load<T>(segment(src,n)), offset);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T cell<T>(ReadOnlySpan<MemorySeg> src, MemorySlot n, ulong offset)
             where T : struct
                => ref core.cell<T>(load<T>(segment(src,n)), offset);

        [MethodImpl(Inline), Op]
        public static ref readonly byte cell(ReadOnlySpan<MemorySeg> src, MemorySlot n, long i)
            => ref skip(segment(src,n).Load(), (uint)i);

        [MethodImpl(Inline), Op]
        public static ref readonly byte cell(ReadOnlySpan<MemorySeg> src, MemorySlot n, ulong i)
            => ref skip(segment(src,n).Load(), (uint)i);
    }
}