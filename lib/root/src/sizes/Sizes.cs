//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static ScalarCast;
    using static minicore;

    [ApiHost]
    public readonly struct Sizes
    {
        const ulong KbFactor = 1024;

        const ulong BitFactor = 8;

        const ulong BitsToKbFactor = KbFactor * BitFactor;

        [MethodImpl(Inline), Op]
        public static NativeSize native(BitWidth src)
        {
            if(src != 80)
            {
                var i = Pow2.log(src >> 3);
                return (NativeSizeCode)i;
            }
            else
                return NativeSizeCode.W80;
        }

        [MethodImpl(Inline), Op]
        public static BitWidth width(NativeSizeCode src)
            => src != NativeSizeCode.W80 ? (Pow2.pow((byte)src)*8ul) : 80;

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
        public static Kb kb(BitWidth src)
        {
            var kb = uint32(src.Content/BitsToKbFactor);
            var rem = uint32(src.Content % BitsToKbFactor);
            return new Kb(kb, rem);
        }

        [MethodImpl(Inline), Op]
        public static Mb mb(Kb src)
            => new Mb(src.Count/(uint)KbFactor);

        [MethodImpl(Inline), Op]
        public static BitWidth bits(Kb src)
        {
            var bits = (ulong)bytes(src).Bits;
            var rem = (ulong)src.Rem;
            return new BitWidth(bits + rem);
        }

        [MethodImpl(Inline), Op]
        public static uint hash(Kb src)
            => src.Count | src.Rem;

        [MethodImpl(Inline), Op]
        public static Kb kb(ByteSize src)
            => kb(src.Bits);

        [MethodImpl(Inline), Op]
        public static ByteSize bytes(Kb src)
            => new ByteSize((uint64(src.Count) * KbFactor) + uint64(src.Rem)/BitFactor);

        [MethodImpl(Inline), Op]
        public static bool eq(Kb a, Kb b)
            => a.Count == b.Count && a.Rem == b.Rem;

        [MethodImpl(Inline), Op]
        public static bool neq(Kb a, Kb b)
            => a.Count != b.Count || a.Rem != b.Rem;

        public static Outcome parse(string src, out ByteSize dst)
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