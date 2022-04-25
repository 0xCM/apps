//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BitNumbers
    {

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T pack<T>(ReadOnlySpan<byte> src, uint offset, out T dst)
            where T : unmanaged
        {
            dst = default;
            var buffer = bytes(dst);
            pack(src, offset, ref first(buffer));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static void pack(ReadOnlySpan<byte> src, uint offset, ref byte dst)
        {
            const byte M = 8;
            var count = src.Length;
            var kIn = (uint)(count - offset);
            var kOut = kIn/M + (kIn % M == 0 ? 0 : 1);
            for(int i=0, j=0; j<kOut; i+=M, j++)
            {
                ref var b = ref seek(dst, j);
                for(var k=0; k<M; k++)
                {
                    var srcIx = i + k + offset;
                    if(srcIx < kIn && skip(src, srcIx) != 0)
                        b |= (byte)(1 << k);
                }
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T pack<T>(ReadOnlySpan<bit> src, ref T dst)
            where T : unmanaged
        {
            pack(recover<bit,byte>(src),0u, out dst);
            return ref dst;
        }

        /// <summary>
        /// Reads a partial value if there aren't a sufficient number of bytes to comprise a target value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T scalar<T>(ReadOnlySpan<bit> src)
            where T : unmanaged
        {
            var dst = default(T);
            if(src.Length == 0)
                return dst;

            return pack(src, ref dst);
        }

        /// <summary>
        /// Packs a section of bits into a scalar
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T scalar<T>(ReadOnlySpan<bit> src, int offset = 0, int? count = null)
            where T : unmanaged
        {
            var len = min((count == null ? (int)width<T>() : count.Value), src.Length - offset);
            return scalar<T>(core.slice(src,offset, len));;
        }

        public static Outcome parse(string src, byte width, out byte b)
        {
            var count = 0;
            var input = text.trim(text.remove(text.remove(src,Chars.Underscore), "0b"));
            b = default;
            var storage = 0ul;
            var buffer = recover<bit>(slice(bytes(storage), 0, width));
            count = Z0.bits.parse(input, buffer);
            if(count >= 0)
            {
                b = scalar<byte>(buffer);
                return true;
            }

            var i = text.index(input, HexFormatSpecs.PreSpec);
            var result = false;
            if(i >=0)
                result = HexParser.parse8u(input, out b);
            else
                result = DataParser.parse(input, out b);
            return result;
        }

        [Parser]
        public static bool parse(string src, out uint1 dst)
        {
            var result = bit.parse(src, out bit b);
            dst = b;
            return result;
        }

        [Parser]
        public static bool parse(string src, out uint2 dst)
        {
            var result = parse(src, 2, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static bool parse(string src, out uint3 dst)
        {
            var result = parse(src, 3, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint4 dst)
        {
            var result = parse(src, 4, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint5 dst)
        {
            var result = parse(src, 5, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint6 dst)
        {
            var result = parse(src, 6, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint7 dst)
        {
            var result = parse(src, 7, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint8b dst)
        {
            var result = parse(src, 8, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }
    }
}