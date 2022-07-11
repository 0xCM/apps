//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static ScalarCast;
    using static Spans;
    using static Refs;
    using static Arrays;
    using static Sized;


    [ApiHost,Free]
    public partial class Sized
    {
        public const ulong BytesPerKb = 1024;

        public const ulong BytesPerMb = 1000*BytesPerKb;

        public const ulong BytesPerGb = 1073741824;

        const ulong BitsPerByte = 8;

        public const ulong BitsPerKb = BytesPerKb*BitsPerByte;

        public const ulong BitsPerMb = 1000*BitsPerKb;

        public const ulong BitsPerGb = 1000*BitsPerMb;


        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static ByteSize size(Mb mb)
            => mb.Count * BytesPerMb;

        [MethodImpl(Inline), Op]
        public static ByteSize size(Gb gb)
            => gb.Count * BytesPerGb;

        [MethodImpl(Inline), Op]
        public static ByteSize size(Kb src)
            => new ByteSize((uint64(src.Count) * BytesPerKb) + uint64(src.Rem)/BitsPerByte);

        [MethodImpl(Inline), Op]
        public static NativeSize native(BitWidth src)
        {
            if(src == 8)
                return NativeSizeCode.W8;
            else if(src == 80)
                return NativeSizeCode.W80;
            else
                return (NativeSizeCode)Pow2.log(src >> 3);
        }

        /// <summary>
        /// Computes the bit-width of the represented primitive
        /// </summary>
        /// <param name="src">The literal's bitfield</param>
        [MethodImpl(Inline), Op]
        public static NativeSize native(PrimalKind src)
            => native((uint)PrimalBits.width(src));

        [MethodImpl(Inline)]
        public static NativeSize native<W>(W w)
            where W : unmanaged, IDataWidth
                => native((BitWidth)w.BitWidth);


        [MethodImpl(Inline), Op]
        public static DataSize sum(ReadOnlySpan<DataSize> src)
        {
            var dst = DataSize.Zero;
            for(var i=0; i<src.Length; i++)
                dst += skip(src,i);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static DataSize max(ReadOnlySpan<DataSize> src)
        {
            var dst = DataSize.Zero;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src,i);
                if(x > dst)
                    dst = x;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static DataSize min(ReadOnlySpan<DataSize> src)
        {
            var dst = DataSize.Zero;
            var count = src.Length;
            if(count == 0)
                return dst;

            dst = first(src);
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(src,i);
                if(x < dst)
                    dst = x;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static DataSize sum(params DataSize[] src)
            => sum(@readonly(src));

        [MethodImpl(Inline), Op]
        public static DataSize max(params DataSize[] src)
            => max(@readonly(src));

        [MethodImpl(Inline), Op]
        public static BitWidth bits(ulong src)
            => new BitWidth(src);

        [MethodImpl(Inline), Op]
        public static BitWidth bits(long src)
            => new BitWidth(src);

        [MethodImpl(Inline), Op]
        public static BitWidth bits(NativeSizeCode src)
            => src != NativeSizeCode.W80 ? (Pow2.pow((byte)src)*8ul) : 80;

        [MethodImpl(Inline), Op]
        public static BitWidth width(NativeSizeCode src)
            => bits(src);

        [MethodImpl(Inline), Op]
        public static ByteSize align(ByteSize src, ulong factor)
            => src + (src % factor);

        [MethodImpl(Inline), Op]
        public static ByteSize align(ByteSize src, long factor)
            => src + (src % factor);

        [MethodImpl(Inline), Op]
        public static BitWidth align(BitWidth src, ulong factor)
            => src + (src % factor);

        [MethodImpl(Inline), Op]
        public static BitWidth align(BitWidth src, long factor)
            => src + (src % factor);

        [MethodImpl(Inline), Op]
        public static ByteSize bytes(NativeSizeCode src)
            => (ByteSize)width(src);

        [MethodImpl(Inline), Op]
        public static ByteSize bytes(ulong src)
            => new ByteSize(src);

        [MethodImpl(Inline), Op]
        public static ByteSize bytes(long src)
            => new ByteSize(src);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static ByteSize untyped<T>(Size<T> src)
            where T : unmanaged
                => bw64(src.Measure);

        [MethodImpl(Inline), Op]
        public static Kb kb(ByteSize src)
            => kb(src.Bits);

        [MethodImpl(Inline), Op]
        public static Kb kb(BitWidth src)
        {
            var kb = uint32(src.Content/BitsPerKb);
            var rem = uint32(src.Content % BitsPerKb);
            return new Kb(kb, rem);
        }

        [MethodImpl(Inline), Op]
        public static Mb mb(Kb src)
            => new Mb(src.Count/(uint)BytesPerKb);

        [MethodImpl(Inline), Op]
        public static Mb mb(Gb src)
            => new Mb(src.Count/(uint)BytesPerGb);

        [MethodImpl(Inline), Op]
        public static uint hash(Kb src)
            => src.Count | src.Rem;

        [MethodImpl(Inline), Op]
        public static bool eq(Kb a, Kb b)
            => a.Count == b.Count && a.Rem == b.Rem;

        [MethodImpl(Inline), Op]
        public static bool neq(Kb a, Kb b)
            => a.Count != b.Count || a.Rem != b.Rem;

        [MethodImpl(Inline), Op]
        public static BitWidth bits(Kb src)
        {
            var bits = (ulong)size(src).Bits;
            var rem = (ulong)src.Rem;
            return new BitWidth(bits + rem);
        }


        [MethodImpl(Inline)]
        public static DataSize datasize(BitWidth packed)
            => new DataSize(packed,(uint)(packed % 8 == 0 ? packed/8 : (packed/8) + 1));


        [MethodImpl(Inline)]
        public static NativeSize native<T>()
            where T : unmanaged
                => native(width<T>());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint width<T>()
            => (uint)SizeOf<T>()*8;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint size<T>()
            => (uint)SizeOf<T>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint size<T>(uint count)
            => (uint)SizeOf<T>() * count;

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 8
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static byte bw8<T>(T src)
            where T : unmanaged
                => u8(src);

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 16
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ushort bw16<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return (ushort)u32(src);
            else
                return (ushort)u64(src);
        }

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 32
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static uint bw32<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return u32(src);
            else
                return (uint)u64(src);
        }

        [MethodImpl(Inline), Op]
        public static int bw32i(ReadOnlySpan<byte> src)
        {
            var storage = z32i;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(4,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static uint bw32u(ReadOnlySpan<byte> src)
        {
            var storage = z32;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(4,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 64
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong bw64<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return u32(src);
            else
                return u64(src);
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long bw64i<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return i8(src);
            if(width<T>() == 16)
                return i16(src);
            else if(width<T>() == 32)
                return i32(src);
            else
                return i64(src);
        }

        [MethodImpl(Inline), Op]
        public static long bw64i(ReadOnlySpan<byte> src)
        {
            var storage = z64i;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(8,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static ulong bw64u(ReadOnlySpan<byte> src)
        {
            var storage = z64;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(8,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }
    }
}