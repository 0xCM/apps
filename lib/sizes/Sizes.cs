//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ScalarCast;
    using static core;

    [ApiHost]
    public readonly struct Sizes
    {
        public const ulong BytesPerKb = 1024;

        public const ulong BytesPerMb = 1000*BytesPerKb;

        public const ulong BytesPerGb = 1073741824;

        const ulong BitsPerByte = 8;

        public const ulong BitsPerKb = BytesPerKb*BitsPerByte;

        public const ulong BitsPerMb = 1000*BitsPerKb;

        public const ulong BitsPerGb = 1000*BitsPerMb;

        readonly struct SizeCalc<T>
        {
            [MethodImpl(Inline)]
            public static uint calc()
                => (uint)Unsafe.SizeOf<T>();
        }

        public static uint bitwidth(Type src)
        {
            if(src is null || src == typeof(void) || src == typeof(Null))
                return 0;
            try
            {
                var type = typeof(SizeCalc<>).MakeGenericType(src);
                var method = first(type.StaticMethods().Public());
                return ((uint)method.Invoke(null, sys.empty<object>()))*8;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        [MethodImpl(Inline), Op]
        public static ByteSize size(Mb mb)
            => mb.Count * BytesPerMb;

        [MethodImpl(Inline), Op]
        public static ByteSize size(Gb gb)
            => gb.Count * BytesPerGb;

        [MethodImpl(Inline), Op]
        public static Kb kb(ByteSize src)
            => kb(src.Bits);

        [MethodImpl(Inline), Op]
        public static ByteSize size(Kb src)
            => new ByteSize((uint64(src.Count) * BytesPerKb) + uint64(src.Rem)/BitsPerByte);

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
        public static BitWidth bits(Kb src)
        {
            var bits = (ulong)size(src).Bits;
            var rem = (ulong)src.Rem;
            return new BitWidth(bits + rem);
        }

        public static uint bitwidth<T>()
            => bitwidth(typeof(T));

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
        public static NativeSize native(ClrPrimitiveKind src)
            => native((uint)PrimalBits.width(src));

        [MethodImpl(Inline)]
        public static NativeSize native<W>(W w)
            where W : unmanaged, IDataWidth
                => native((BitWidth)w.BitWidth);

        [MethodImpl(Inline)]
        public static NativeSize native<T>()
            where T : unmanaged
                => native(width<T>());

        [MethodImpl(Inline), Op]
        public static BitWidth width(NativeSizeCode src)
            => src != NativeSizeCode.W80 ? (Pow2.pow((byte)src)*8ul) : 80;

        [MethodImpl(Inline), Op]
        public static ByteSize bytes(NativeSizeCode src)
            => (ByteSize)width(src);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Size<T> size<T>(T src)
            where T : unmanaged
                => new Size<T>(src);

        [MethodImpl(Inline), Op]
        public static BitWidth bits(ulong src)
            => new BitWidth(src);

        [MethodImpl(Inline), Op]
        public static BitWidth bits(long src)
            => new BitWidth(src);

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
        public static uint hash(Kb src)
            => src.Count | src.Rem;


        [MethodImpl(Inline), Op]
        public static bool eq(Kb a, Kb b)
            => a.Count == b.Count && a.Rem == b.Rem;

        [MethodImpl(Inline), Op]
        public static bool neq(Kb a, Kb b)
            => a.Count != b.Count || a.Rem != b.Rem;

        [Parser]
        public static Outcome parse(string src, out ByteSize dst)
        {
            if(NumericParser.parse<ulong>(text.remove(src,Chars.Comma), out var x))
            {
                dst = x;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [Parser]
        public static Outcome parse(string src, out BitWidth dst)
        {
            if(NumericParser.parse<ulong>(src, out var x))
            {
                dst = x;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [Parser(typeof(ClrTypes.Integers))]
        public static Outcome parse<T>(string src, out Size<T> dst)
            where T : unmanaged
        {
            if(NumericParser.parse<ulong>(src, out var x))
            {
                dst = size<T>(generic<T>(x));
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}