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

    using S = strings;

    [ApiHost]
    public readonly struct StringBuffers
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static StringBuffer<S> buffer<S>(uint length)
            where S : unmanaged
                => new StringBuffer<S>(length);

        [Op, Closures(Closure)]
        public static StringBuffer buffer(uint length)
            => new StringBuffer(length);

        /// <summary>
        /// Allocates and populates a <see cref='StringBuffer'/> with capacity and content determined the source operand
        /// </summary>
        /// <param name="src">The source strings</param>
        [Op]
        public static StringBuffer buffer(ReadOnlySpan<string> src)
        {
            var count = (uint)src.Length;
            var dst = buffer(S.length(src) + count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(src,i);
                var view = span(s);
                for(var j=0; j<count; j++)
                    dst[counter++] = skip(view,j);
                dst[counter++] = (char)0;
            }
            return dst;
        }

        public static StringAllocation strings(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;

            var storage = buffer(total);
            var allocator = storage.StringAllocator();
            var dst = core.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
                allocator.Allocate(skip(src,i), out seek(dst,i));
            return new StringAllocation(allocator, dst);
        }

        public static SourceAllocation sources(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0u; i<count; i++)
                total += (uint)skip(src,i).Length;

            var storage  = buffer(total);
            var allocator = storage.SourceAllocator();
            var dst = core.alloc<SourceText>(count);
            for(var i=0; i<count; i++)
                allocator.Allocate(skip(src,i), out seek(dst,i));
            return new SourceAllocation(allocator, dst);
        }

        public static LabelAllocation labels(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;

            var storage  = buffer(total);
            var allocator = storage.LabelAllocator();
            var labels = core.alloc<Label>(count);
            for(var i=0; i<count; i++)
                allocator.Allocate(skip(src,i), out seek(labels,i));
            return new LabelAllocation(allocator, labels);
        }

        /// <summary>
        /// Deposits a character sequence into a caller-supplied buffer and returns the label representation of the input
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="offset">The buffer offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static SourceText source(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var length = src.Length;
            if(length <= byte.MaxValue && store(src, offset, dst))
                return new SourceText(dst.Address(offset), length);
            else
                return SourceText.Empty;
        }

        /// <summary>
        /// Deposits a character sequence into a caller-supplied buffer and returns a reference to the input
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="offset">The buffer offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static StringRef stringref(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var length = src.Length;
            if(length <= byte.MaxValue && store(src, offset, dst))
                return new StringRef(dst.Address(offset), (byte)length);
            else
                return StringRef.Empty;
        }

        /// <summary>
        /// Deposits a character sequence into a caller-supplied buffer and returns the label representation of the input
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="offset">The buffer offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static Label label(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var length = src.Length;
            if(length <= byte.MaxValue && store(src, offset, dst))
                return new Label(dst.Address(offset), (byte)length);
            else
                return Label.Empty;
        }

        [MethodImpl(Inline), Op]
        public static bool store(ReadOnlySpan<char> src, uint offset, StringBuffer dst)
        {
            var available = (long)dst.Length - (long)offset;
            var requested = src.Length;
            if(requested <= available)
            {
                var j = offset;
                for(var i=0; i<requested; i++)
                    dst[j++] = skip(src,i);
                return true;
            }
            return false;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool store<S>(ReadOnlySpan<S> src, uint offset, StringBuffer<S> dst)
            where S : unmanaged
        {
            var available = (long)dst.Length - (long)offset;
            var requested = src.Length;
            if(requested <= available)
            {
                var j = offset;
                for(var i=0; i<requested; i++)
                    dst[j++] = skip(src,i);
                return true;
            }
            return false;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool store<S>(ReadOnlySpan<S> src, int offset, StringBuffer<S> dst)
            where S : unmanaged
                => store(src, (uint)offset, dst);
    }
}