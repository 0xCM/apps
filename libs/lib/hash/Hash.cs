//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;
    using System.Numerics;

    using static Hash.Marvin;
    using static Scalars;

    using H = Hash;

    [Free]
    [ApiHost]
    public class Hash
    {
        [MethodImpl(Inline)]
        public static Hash32 bytehash<C>(C src)
            where C : struct
                => Generic.bytehash(src);

        [Parser]
        public static Outcome parse(string src, out Hash8 dst)
        {
            var result = Hex8.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (byte)hex;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out Hash16 dst)
        {
            var result = Hex16.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (ushort)hex;
            return result;
        }


        [Parser]
        public static Outcome parse(string src, out Hash32 dst)
        {
            var result = Hex32.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (uint)hex;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out Hash64 dst)
        {
            var result = Hex64.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (ulong)hex;
            return result;
        }


        [ApiHost("hash.generic")]
        public class Generic
        {
            const NumericKind Closure = UnsignedInts;

            /// <summary>
            /// Computes calc codes for unmanaged system primitives
            /// </summary>
            /// <param name="src">The primal value</param>
            /// <typeparam name="T">The primitive type</typeparam>
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static uint calc<T>(T src)
                => calc_u(src);

            /// <summary>
            /// Calculates a hash code for structured content and returns the content along with the calculated hash
            /// </summary>
            /// <param name="src">The source content</param>
            /// <typeparam name="C">The content type</typeparam>
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static uint bytehash<C>(C src)
                where C : struct
                    => calc<byte>(Refs.bytes(src));

            /// <summary>
            /// Creates a 64-bit calccode over a pair
            /// </summary>
            /// <param name="x">The first member</param>
            /// <param name="y">The second member</param>
            /// <typeparam name="X">The first member type</typeparam>
            /// <typeparam name="Y">The second member type</typeparam>
            [MethodImpl(Inline)]
            public static ulong calc64<X,Y>(X x, Y y)
                => calc(x) | (calc(y) << 32);

            /// <summary>
            /// Creates a 32-bit calc code predicated on a type parameter
            /// </summary>
            /// <typeparam name="T">The source type</typeparam>
            [MethodImpl(Inline)]
            public static uint calc<T>()
                => H.calc(typeof(T));

            /// <summary>
            /// Creates a 64-bit calc code predicated on two type parameters
            /// </summary>
            /// <typeparam name="S">The first type</typeparam>
            /// <typeparam name="T">The second type</typeparam>
            [MethodImpl(Inline)]
            public static ulong calc<S,T>()
                => (ulong)calc<S>() | (ulong)calc<T>() << 32;

            /// <summary>
            /// Computes a combined calc code for a pair
            /// </summary>
            /// <typeparam name="T">The primitive type</typeparam>
            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static uint combine<T>(T x, T y)
                => calc_u(x,y);

            [MethodImpl(Inline), Op, Closures(Closure)]
            public static uint calc<T>(T a, T b, T c, T d)
                => combine(H.combine(calc(a), calc(b)), H.combine(calc(c), calc(d)));

            [MethodImpl(Inline), Op, Closures(AllNumeric)]
            public static uint calc<T>(ReadOnlySpan<T> src)
            {
                var length = src.Length;
                if(length == 0)
                    return 0;

                var rolling = FnvOffsetBias;
                for(var i=0u; i<length-1; i++)
                {
                    ref readonly var x = ref Spans.skip(src,i);
                    ref readonly var y = ref Spans.skip(src,i + 1);
                    rolling = H.combine(rolling, combine(x,y))*H.FnvPrime;
                }
                return rolling;
            }

            [MethodImpl(Inline)]
            public static uint calc<T>(Span<T> src)
                => calc(Spans.@readonly(src));

            [MethodImpl(Inline)]
            public static uint calc<T>(T[] src)
                => calc(Spans.span(src));

            [MethodImpl(Inline)]
            static uint calc_u<T>(T src)
            {
                if(typeof(T) == typeof(byte))
                    return H.calc(uint8(src));
                else if(typeof(T) == typeof(ushort))
                    return H.calc(uint16(src));
                else if(typeof(T) == typeof(uint))
                    return H.calc(uint32(src));
                else if(typeof(T) == typeof(ulong))
                    return H.calc(uint64(src));
                else
                    return calc_i(src);
            }

            [MethodImpl(Inline)]
            static uint calc_i<T>(T src)
            {
                if(typeof(T) == typeof(sbyte))
                    return H.calc(int8(src));
                else if(typeof(T) == typeof(short))
                    return H.calc(int16(src));
                else if(typeof(T) == typeof(int))
                    return H.calc(int32(src));
                else if(typeof(T) == typeof(long))
                    return H.calc(int64(src));
                else
                    return calc_f(src);
            }

            [MethodImpl(Inline)]
            static uint calc_f<T>(T src)
            {
                if(typeof(T) == typeof(float))
                    return H.calc(float32(src));
                else if(typeof(T) == typeof(double))
                    return H.calc(float64(src));
                else if(typeof(T) == typeof(decimal))
                    return H.calc(float128(src));
                else
                    return calc_x(src);
            }

            [MethodImpl(Inline)]
            static uint calc_x<T>(T src)
            {
                if(typeof(T) == typeof(char))
                    return H.calc(c16(src));
                else if(typeof(T) == typeof(bool))
                    return H.calc(@bool(src));
                else
                    return fallback(src);
            }

            [MethodImpl(Inline)]
            static uint calc_u<T>(T x, T y)
            {
                if(typeof(T) == typeof(byte))
                    return H.combine(uint8(x), uint8(y));
                else if(typeof(T) == typeof(ushort))
                    return H.combine(uint16(x), uint16(y));
                else if(typeof(T) == typeof(uint))
                    return H.combine(uint32(x), uint32(y));
                else if(typeof(T) == typeof(ulong))
                    return H.combine(uint64(x), uint64(y));
                else
                    return calc_i(x,y);
            }

            [MethodImpl(Inline)]
            static uint calc_i<T>(T x, T y)
            {
                if(typeof(T) == typeof(sbyte))
                    return H.combine(int8(x), int8(y));
                else if(typeof(T) == typeof(short))
                    return H.combine(int16(x), int16(y));
                else if(typeof(T) == typeof(int))
                    return H.combine(int32(x), int32(y));
                else if(typeof(T) == typeof(long))
                    return H.combine(int64(x), int64(y));
                else
                    return calc_f(x,y);
            }

            [MethodImpl(Inline)]
            static uint calc_f<T>(T x, T y)
            {
                if(typeof(T) == typeof(float))
                    return H.combine(float32(x), float32(y));
                else if(typeof(T) == typeof(double))
                    return H.combine(float64(x), float64(y));
                else if(typeof(T) == typeof(decimal))
                    return H.combine(float128(x), float128(y));
                else
                    return fallback(x,y);
            }

            [MethodImpl(Inline)]
            static uint fallback<T>(T src)
                => (uint)(src?.GetHashCode() ?? 0);

            [MethodImpl(Inline)]
            static uint fallback<S,T>(S x, T y)
                => H.combine(
                    (uint)(x?.GetHashCode() ?? 0),
                    (uint)(y?.GetHashCode() ?? 0)
                    );
        }

        //-----------------------------------------------------------------------------
        // Copyright   :  Licensed to the .NET Foundation under one or more agreements.
        // License     :  MIT
        //-----------------------------------------------------------------------------
        [Free]
        [ApiHost("hash.marvin")]
        public class Marvin
        {
            const ulong DefaultMarvivSeed = 0x7ffc5cf169c0aab1;

            /// <summary>
            /// Compute a Marvin hash and collapse it into a 32-bit hash.
            /// </summary>
            [MethodImpl(Inline), Op]
            public static uint marvin(ReadOnlySpan<byte> src, ulong seed = DefaultMarvivSeed)
                => (uint)ComputeHash32(ref Spans.edit(src), (uint)src.Length, (uint)seed, (uint)(seed >> 32));

            /// <summary>
            /// Compute a Marvin hash and collapse it into a 32-bit hash.
            /// </summary>
            [MethodImpl(Inline), Op]
            public static uint marvin(ReadOnlySpan<char> src, ulong seed = DefaultMarvivSeed)
                => marvin(Spans.recover<char,byte>(src), seed);

            /// <summary>
            /// Compute a Marvin hash and collapse it into a 32-bit hash.
            /// </summary>
            [Op]
            static int ComputeHash32(ref byte data, uint count, uint p0, uint p1)
            {
                // Control flow of this method generally flows top-to-bottom, trying to
                // minimize the number of branches taken for large (>= 8 bytes, 4 chars) inputs.
                // If small inputs (< 8 bytes, 4 chars) are given, this jumps to a "small inputs"
                // handler at the end of the method.

                if (count < 8)
                {
                    // We can't run the main loop, but we might still have 4 or more bytes available to us.
                    // If so, jump to the 4 .. 7 bytes logic immediately after the main loop.

                    if (count >= 4)
                        goto Between4And7BytesRemain;
                    else
                        goto InputTooSmallToEnterMainLoop;
                }

                // Main loop - read 8 bytes at a time.
                // The block function is unrolled 2x in this loop.

                uint loopCount = count / 8;
                Debug.Assert(loopCount > 0, "Shouldn't reach this code path for small inputs.");

                do
                {
                    // Most x86 processors have two dispatch ports for reads, so we can read 2x 32-bit
                    // values in parallel. We opt for this instead of a single 64-bit read since the
                    // typical use case for Marvin32 is computing String hash codes, and the particular
                    // layout of String instances means the starting data is never 8-byte aligned when
                    // running in a 64-bit process.
                    p0 += Unsafe.ReadUnaligned<uint>(ref data);
                    uint nextUInt32 = Unsafe.ReadUnaligned<uint>(ref Unsafe.AddByteOffset(ref data, (IntPtr)4ul));

                    // One block round for each of the 32-bit integers we just read, 2x rounds total.

                    Block(ref p0, ref p1);
                    p0 += nextUInt32;
                    Block(ref p0, ref p1);

                    // Bump the data reference pointer and decrement the loop count.

                    // Decrementing by 1 every time and comparing against zero allows the JIT to produce
                    // better codegen compared to a standard 'for' loop with an incrementing counter.
                    // Requires https://github.com/dotnet/runtime/issues/6794 to be addressed first
                    // before we can realize the full benefits of this.

                    data = ref Unsafe.AddByteOffset(ref data, (IntPtr)8ul);
                } while (--loopCount > 0);

                // n.b. We've not been updating the original 'count' parameter, so its actual value is
                // still the original data length. However, we can still rely on its least significant
                // 3 bits to tell us how much data remains (0 .. 7 bytes) after the loop above is
                // completed.

                if ((count & 0b_0100) == 0)
                {
                    goto DoFinalPartialRead;
                }

            Between4And7BytesRemain:

                // If after finishing the main loop we still have 4 or more leftover bytes, or if we had
                // 4 .. 7 bytes to begin with and couldn't enter the loop in the first place, we need to
                // consume 4 bytes immediately and send them through one round of the block function.

                Debug.Assert(count >= 4, "Only should've gotten here if the original count was >= 4.");

                p0 += Unsafe.ReadUnaligned<uint>(ref data);
                Block(ref p0, ref p1);

            DoFinalPartialRead:

                // Finally, we have 0 .. 3 bytes leftover. Since we know the original data length was at
                // least 4 bytes (smaller lengths are handled at the end of this routine), we can safely
                // read the 4 bytes at the end of the buffer without reading past the beginning of the
                // original buffer. This necessarily means the data we're about to read will overlap with
                // some data we've already processed, but we can handle that below.

                Debug.Assert(count >= 4, "Only should've gotten here if the original count was >= 4.");

                // Read the last 4 bytes of the buffer.

                uint partialResult = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref Unsafe.AddByteOffset(ref data, (IntPtr)((ulong)count & 7)), -4));

                // The 'partialResult' local above contains any data we have yet to read, plus some number
                // of bytes which we've already read from the buffer. An example of this is given below
                // for little-endian architectures. In this table, AA BB CC are the bytes which we still
                // need to consume, and ## are bytes which we want to throw away since we've already
                // consumed them as part of a previous read.
                //
                //                                                    (partialResult contains)   (we want it to contain)
                // count mod 4 = 0 -> [ ## ## ## ## |             ] -> 0x####_####             -> 0x0000_0080
                // count mod 4 = 1 -> [ ## ## ## ## | AA          ] -> 0xAA##_####             -> 0x0000_80AA
                // count mod 4 = 2 -> [ ## ## ## ## | AA BB       ] -> 0xBBAA_####             -> 0x0080_BBAA
                // count mod 4 = 3 -> [ ## ## ## ## | AA BB CC    ] -> 0xCCBB_AA##             -> 0x80CC_BBAA

                count = ~count << 3;

                if (BitConverter.IsLittleEndian)
                {
                    partialResult >>= 8; // make some room for the 0x80 byte
                    partialResult |= 0x8000_0000u; // put the 0x80 byte at the beginning
                    partialResult >>= (int)count & 0x1F; // shift out all previously consumed bytes
                }
                else
                {
                    partialResult <<= 8; // make some room for the 0x80 byte
                    partialResult |= 0x80u; // put the 0x80 byte at the end
                    partialResult <<= (int)count & 0x1F; // shift out all previously consumed bytes
                }

            DoFinalRoundsAndReturn:

                // Now that we've computed the final partial result, merge it in and run two rounds of
                // the block function to finish out the Marvin algorithm.

                p0 += partialResult;
                Block(ref p0, ref p1);
                Block(ref p0, ref p1);

                return (int)(p1 ^ p0);

            InputTooSmallToEnterMainLoop:

                // We had only 0 .. 3 bytes to begin with, so we can't perform any 32-bit reads.
                // This means that we're going to be building up the final result right away and
                // will only ever run two rounds total of the block function. Let's initialize
                // the partial result to "no data".

                if (BitConverter.IsLittleEndian)
                {
                    partialResult = 0x80u;
                }
                else
                {
                    partialResult = 0x80000000u;
                }

                if ((count & 0b_0001) != 0)
                {
                    // If the buffer is 1 or 3 bytes in length, let's read a single byte now
                    // and merge it into our partial result. This will result in partialResult
                    // having one of the two values below, where AA BB CC are the buffer bytes.
                    //
                    //                  (little-endian / big-endian)
                    // [ AA          ]  -> 0x0000_80AA / 0xAA80_0000
                    // [ AA BB CC    ]  -> 0x0000_80CC / 0xCC80_0000

                    partialResult = Unsafe.AddByteOffset(ref data, (IntPtr)((ulong)count & 2));

                    if (BitConverter.IsLittleEndian)
                    {
                        partialResult |= 0x8000;
                    }
                    else
                    {
                        partialResult <<= 24;
                        partialResult |= 0x800000u;
                    }
                }

                if ((count & 0b_0010) != 0)
                {
                    // If the buffer is 2 or 3 bytes in length, let's read a single ushort now
                    // and merge it into the partial result. This will result in partialResult
                    // having one of the two values below, where AA BB CC are the buffer bytes.
                    //
                    //                  (little-endian / big-endian)
                    // [ AA BB       ]  -> 0x0080_BBAA / 0xAABB_8000
                    // [ AA BB CC    ]  -> 0x80CC_BBAA / 0xAABB_CC80 (carried over from above)

                    if (BitConverter.IsLittleEndian)
                    {
                        partialResult <<= 16;
                        partialResult |= (uint)Unsafe.ReadUnaligned<ushort>(ref data);
                    }
                    else
                    {
                        partialResult |= (uint)Unsafe.ReadUnaligned<ushort>(ref data);
                        partialResult = BitOperations.RotateLeft(partialResult, 16);
                    }
                }

                // Everything is consumed! Go perform the final rounds and return.

                goto DoFinalRoundsAndReturn;
            }

            [MethodImpl(Inline), Op]
            static void Block(ref uint rp0, ref uint rp1)
            {
                // Intrinsified in mono interpreter
                uint p0 = rp0;
                uint p1 = rp1;

                p1 ^= p0;
                p0 = BitOperations.RotateLeft(p0, 20);

                p0 += p1;
                p1 = BitOperations.RotateLeft(p1, 9);

                p1 ^= p0;
                p0 = BitOperations.RotateLeft(p0, 27);

                p0 += p1;
                p1 = BitOperations.RotateLeft(p1, 19);

                rp0 = p0;
                rp1 = p1;
            }
        }
        internal const uint K = 0xA5555529;

        internal const uint FnvOffsetBias = 2166136261;

        internal const uint FnvPrime = 16777619;

        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        [MethodImpl(Inline), Op]
        public static uint calc(sbyte x)
            => (uint)x;

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        [MethodImpl(Inline), Op]
        public static uint calc(byte x)
            => (uint)x;

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(short x)
            => (uint)x;

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(ushort x)
            => (uint)x;

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(int x)
            => (uint)x;

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(uint x)
            => (uint)x;

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(long x)
            => combine((uint)x,(uint)(x >> 32));

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(ulong x)
            => combine((uint)x,(uint)(x >> 32));

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(char x)
            => (uint)x;

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(float x)
            => calc((long)x);

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(double x)
            => calc(u64(x));

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(decimal x)
            => calc(u64(x));

        /// <summary>
        /// Creates an unsigned calc code
        /// </summary>
        /// <param name="x">The source value</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint calc(bool x)
            => @byte(x);

        [MethodImpl(Inline), Op]
        public static uint calc(string src)
            => marvin(text.ifempty(src,EmptyString));

        [MethodImpl(Inline), Op]
        public static uint calc(ushort a, ushort b)
            => (uint)a | ((uint)b << 16);

        [MethodImpl(Inline), Op]
        public static uint calc(char a, char b)
            => (uint)a | ((uint)b << 16);

        [MethodImpl(Inline), Op]
        public static uint calc(Type src)
            => (uint)src.MetadataToken;

        /// <summary>
        /// Calculates a combined calc for 2 unsigned 32-bit integers
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(uint x, uint y)
            => (y * K) + x;

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(sbyte x, sbyte y)
            => combine((uint)x,(uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(byte x, byte y)
            => combine((uint)x,(uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(short x, short y)
            => combine((uint)x,(uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(ushort x, ushort y)
            => combine((uint)x,(uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(int x, int y)
            => combine((uint)x, (uint)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(ulong x, ulong y)
            => combine(combine((uint)x,(uint)(x >> 32)), combine((uint)y,(uint)(y >> 32)));

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(long x, long y)
            => combine((ulong)x,(ulong)y);

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(float x, float y)
            => combine(i32(x), i32(y));

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(double x, double y)
            => combine(u64(x), u64(y));

        /// <summary>
        /// Creates a combined/unsigned calc code
        /// </summary>
        /// <param name="x">The left source</param>
        /// <param name="y">The right source</param>
        /// <remarks>Adapted from the .Net core type System.Reflection.Internal.Hash</remarks>
        [MethodImpl(Inline), Op]
        public static uint combine(decimal x, decimal y)
            => combine(u64(x), u64(y));

        /// <summary>
        /// Creates a 64-bit calc code predicated on two types
        /// </summary>
        /// <typeparam name="S">The first type</typeparam>
        /// <typeparam name="T">The second type</typeparam>
        [MethodImpl(Inline)]
        public static ulong combine(Type t1, Type t2)
            => (ulong)calc(t1) | (ulong)calc(t2) << 32;

        /// <summary>
        /// Creates a 64-bit calc code predicated on three types
        /// </summary>
        /// <typeparam name="S">The first type</typeparam>
        /// <typeparam name="T">The second type</typeparam>
        [MethodImpl(Inline)]
        public static ulong combine(Type t1, Type t2, Type t3)
            => combine(t1,t2) ^ combine(t1, t3);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(sbyte x, sbyte y, sbyte z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(byte x, byte y, byte z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(ushort x, ushort y, ushort z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(short x, short y, short z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(uint x, uint y, uint z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 32-bit hash codes into 1 32-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(int x, int y, int z)
            => combine(combine(x,y), z);

        /// <summary>
        /// Combines 3 64-bit hash codes into 1 64-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(ulong x, ulong y, ulong z)
            => combine(combine(x,y),z);

        /// <summary>
        /// Combines 3 64-bit hash codes into 1 64-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(long x, long y, long z)
            => combine(combine(x,y),z);

        /// <summary>
        /// Combines 3 64-bit hash codes into 1 64-hash code
        /// </summary>
        /// <param name="x">The first hash</param>
        /// <param name="y">The second hash</param>
        /// <param name="z">The third hash</param>
        [MethodImpl(Inline), Op]
        public static uint combine(char x, char y, char z)
            => combine(combine(x,y),z);

        [MethodImpl(Inline)]
        static unsafe ulong u64(double src)
            => (*((ulong*)(&src)));

        [MethodImpl(Inline)]
        static unsafe ulong u64(decimal src)
            => (*((ulong*)(&src)));

        [MethodImpl(Inline)]
        static unsafe byte @byte(bool src)
            => (*((byte*)(&src)));

        [MethodImpl(Inline)]
        public static unsafe int i32(float src)
            => (*((int*)(&src)));
    }
}