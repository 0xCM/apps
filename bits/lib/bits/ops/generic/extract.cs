//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        /// <summary>
        /// Extracts a contiguous sequence of bits from a source and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="a">The bit source</param>
        /// <param name="min">The 0-based index of the first selected bit</param>
        /// <param name="max">The 0-based index of the last selected bit</param>
        /// <param name="dst">The target that receives the sequence</param>
        /// <param name="offset">The target offset</param>
        /// <typeparam name="T">The primal bit source type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static void extract<T>(T a, byte min, byte max, Span<byte> dst, int offset)
            where T : unmanaged
        {
            var seg = extract(a, min, max);
            var kBytes = bit.minbytes(max - min + 1);
            var src = core.slice(bytes(seg), 0, kBytes);
            copy(src,offset,dst);
        }

        [MethodImpl(Inline)]
        static void copy(Span<byte> src, int offset, Span<byte> dst)
        {
            var count = src.Length;
            var j=0;
            for(var i=offset; i<offset + count; i++)
                seek(dst,j++) = skip(src,i);
        }

        /// <summary>
        /// Extracts a T-valued segment, cross-cell or same-cell, from the source as determined by an inclusive position range
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="min">The sequence-relative position of the first bit</param>
        /// <param name="max">The sequence-relative position of the last bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static T extract<T>(Span<T> src, BitPos<T> min, BitPos<T> max)
            where T : unmanaged
        {
            var bitcount = (uint)(max - min);
            if(bitcount > width<T>())
                return Limits.maxval<T>();

            var sameSeg = min.CellIndex == max.CellIndex;
            var firstCount = ScalarCast.uint8(sameSeg ? bitcount : (uint)(width<T>() - min.BitOffset));
            var part1 = slice(bitcell(src, min), (byte)min.BitOffset, firstCount);

            if(sameSeg)
                return part1;
            else
            {
                var lastCount = ScalarCast.uint8(bitcount - firstCount);
                return gmath.or(part1, gmath.sal(slice(bitcell(src,max), 0, lastCount), firstCount));
            }
        }

        /// <summary>
        /// Extracts a contiguous range of bits from a primal source inclusively between two index positions
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="rhs">The left bit position</param>
        /// <param name="dst">The right bit position</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(AllNumeric)]
        public static T extract<T>(T src, byte min, byte max)
            where T : unmanaged
                => extract_u(src, min, max);

        /// <summary>
        /// Extracts a T-valued segment, cross-cell or same-cell, from the source as determined by an inclusive linear index range
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="min">The sequence-relative index of the first bit</param>
        /// <param name="max">The sequence-relative index of the last bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static T extract<T>(Span<T> src, byte min, byte max)
            where T : unmanaged
                => extract(src, bit.bitpos<T>((uint)min), bit.bitpos<T>((uint)max));

        [MethodImpl(Inline)]
        static T extract_i<T>(T src, byte i0, byte i1)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(bits.extract(int8(src), i0, i1));
            else if(typeof(T) == typeof(short))
                 return generic<T>(bits.extract(int16(src), i0, i1));
            else if(typeof(T) == typeof(int))
                 return generic<T>(bits.extract(int32(src), i0, i1));
            else if(typeof(T) == typeof(long))
                 return generic<T>(bits.segment(int64(src), i0, i1));
            else
                return extract_f(src,i0,i1);
        }

        [MethodImpl(Inline)]
        static T extract_u<T>(T src, byte i0, byte i1)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                 return generic<T>(bits.extract(uint8(src), i0, i1));
            else if(typeof(T) == typeof(ushort))
                 return generic<T>(bits.extract(uint16(src), i0, i1));
            else if(typeof(T) == typeof(uint))
                 return generic<T>(bits.extract(uint32(src), i0, i1));
            else if(typeof(T) == typeof(ulong))
                 return generic<T>(bits.extract(uint64(src), i0, i1));
            else
                return extract_i(src,i0,i1);
        }

        [MethodImpl(Inline)]
        static T extract_f<T>(T src, byte i0, byte i1)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return generic<T>(bits.extract(float32(src), i0, i1));
            else if(typeof(T) == typeof(double))
                 return generic<T>(bits.extract(float64(src),  i0, i1));
            else
                throw no<T>();
        }
    }
}