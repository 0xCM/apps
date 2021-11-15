//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;
    using static cpu;
    using static vpack;

    [ApiHost]
    public readonly struct vtext
    {
        const NumericKind Closure = UInt64k;

        /// <summary>
        /// Converts 16 source characters to 16 asci codes
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The number of source characters to convert</param>
        /// <param name="dst">The receiving buffer</param>
        [MethodImpl(Inline), Op]
        public static void pack16(in CharBlock16 src, ref ByteBlock16 dst)
            => vstore(vpack128x8u(vload(w256, @char(src))), ref @byte(dst));

        [MethodImpl(Inline), Op]
        public static void pack32(in CharBlock32 src, ref ByteBlock32 dst)
        {
            ref readonly var c0 = ref c16(src);
            ref var b0 = ref u8(dst);
            vstore(vpack128x8u(vload(w256, c0)), ref b0);
            ref readonly var c1 = ref skip(c16(src),16);
            ref var b1 = ref seek(u8(dst),16);
            vstore(vpack128x8u(vload(w256, c1)), ref b1);
        }

        [MethodImpl(Inline), Op]
        public static void pack64(in CharBlock64 src, ref ByteBlock64 dst)
        {
            ref readonly var c0 = ref c16(src);
            ref var b0 = ref u8(dst);
            vstore(vpack128x8u(vload(w256, c0)), ref b0);
            ref readonly var c1 = ref skip(c16(src),16);
            ref var b1 = ref seek(u8(dst),16);
            vstore(vpack128x8u(vload(w256, c1)), ref b1);
            ref readonly var c2 = ref skip(c16(src),32);
            ref var b2 = ref seek(u8(dst),32);
            vstore(vpack128x8u(vload(w256, c2)), ref b2);
            ref readonly var c3 = ref skip(c16(src),48);
            ref var b3 = ref seek(u8(dst),48);
            vstore(vpack128x8u(vload(w256, c3)), ref b3);
        }

        [MethodImpl(Inline), Op]
        public static void unpack32(in ByteBlock32 src, ref CharBlock32 dst)
        {
            var v = vload(w256, src.Bytes);
            var b0 = vinflatelo256x16u(v);
            ref var c0 = ref u16(dst);
            vstore(b0, ref c0);
            var b1 = vinflatehi256x16u(v);
            ref var c1 = ref seek(u16(dst), 16);
            vstore(b1, ref c1);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(in ByteBlock32 src)
        {
            var v = vload(w256, src.Bytes);
            var lo = vinflatelo256x16u(v);
            var hi = vinflatehi256x16u(v);
            return recover<char>(bytes(new V256x2(lo,hi)));
        }

        [MethodImpl(Inline), Op]
        public static void bits(Vector128<byte> src, Span<char> dst)
        {
            var a = vinflate256x8u(vcell(src,1), 0);
            var lo = vlo256x16u(a);
            ref var target = ref u16(first(dst));
            vstore(lo, ref seek(target,0));
            var hi = vhi256x16u(a);
            vstore(hi, ref seek(target,16));
        }

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vunicode256(ReadOnlySpan<char> src)
            => vload(w256, recover<ushort>(src));

        [MethodImpl(Inline), Op]
        public static Vector256<byte> vasci256(ReadOnlySpan<byte> src)
            => vload(w256, src);

        [MethodImpl(Inline), Op]
        public static ref CharBlock16 copy16(ReadOnlySpan<char> src, ref CharBlock16 dst)
        {
            vstore(vload(w128, u8(first(src))), ref u8(dst));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref CharBlock32 copy32(ReadOnlySpan<char> src, ref CharBlock32 dst)
        {
            ref readonly var _u8Src = ref u8(first(src));
            ref var _u8Dst = ref u8(dst);
            vstore(vload(w256, _u8Src), ref _u8Dst);
            vstore(vload(w256, skip(_u8Src,32)), ref seek(_u8Dst, 32));
            return ref dst;
        }

        [Op, Closures(Closure)]
        public static void outcome<T>(SpanBlock128<T> x, SpanBlock128<T> y, Vector128<T> expect, Vector128<T> actual, Vector128<T> result, ITextBuffer dst)
            where T : unmanaged
        {
            dst.Label("left", Chars.Colon, x.Format());
            dst.Label("right", Chars.Colon, y.Format());
            dst.Label("expect", Chars.Colon, expect.Format());
            dst.Label("actual", Chars.Colon, actual.Format());
            dst.Label("result", Chars.Colon, result.Format());
        }

        [Op, Closures(Closure)]
        public static void outcome<T>(SpanBlock256<T> x, SpanBlock256<T> y, Vector256<T> expect, Vector256<T> actual, Vector256<T> result, ITextBuffer dst)
            where T : unmanaged
        {
            dst.Label("left", Chars.Colon, x.Format());
            dst.Label("right", Chars.Colon, y.Format());
            dst.Label("expect", Chars.Colon, expect.Format());
            dst.Label("actual", Chars.Colon, actual.Format());
            dst.Label("result", Chars.Colon, result.Format());
        }

        [Op, Closures(Closure)]
        public static void asmhex<T>(Vector128<T> src, ITextBuffer dst)
            where T : unmanaged
                => dst.Append(gcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void asmhex<T>(Vector256<T> src, ITextBuffer dst)
            where T : unmanaged
            => dst.Append(gcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void asmhex<T>(Vector512<T> src, ITextBuffer dst)
            where T : unmanaged
                => dst.Append(gcpu.vspan(src).FormatHex(Chars.Space, false));

        [Op, Closures(Closure)]
        public static void lanes<T>(Vector256<T> src, char sep, int pad, ITextBuffer dst)
            where T : unmanaged
        {
            dst.Append(string.Format("{0} {1}", src.GetLower().Format(sep, pad), src.GetUpper().Format(sep, pad)));
        }

        [Op, Closures(Closure)]
        public static void hex<T>(Vector128<T> src, ITextBuffer dst,  char sep = Chars.Comma, bool specifier = false)
            where T : unmanaged
                => dst.Append(gcpu.vspan(src).FormatHex(sep, specifier));

        [Op, Closures(Closure)]
        public static void hex<T>(Vector256<T> src, ITextBuffer dst, char sep = Chars.Comma, bool specifier = false)
             where T : unmanaged
                => dst.Append(gcpu.vspan(src).FormatHex(sep, specifier));

       public static void projection<S,T>(Vector128<S> a, Vector128<T> b, ITextBuffer dst)
            where S : unmanaged
            where T : unmanaged
        {
            var srcType = TypeIdentity.numeric<S>();
            var srcCount = a.Length();
            var dstType = TypeIdentity.numeric<T>();
            var dstCount = b.Length();
            var srcWidth = srcCount * width<S>();
            var dstWidth = dstCount * width<T>();
            var srcLabel = $"v{srcWidth}x{srcType}";
            var dstLabel = $"v{dstWidth}x{dstType}";
            var label = $"{srcLabel}_{dstLabel}";
            var formatted = $"{label}:[{a.FormatHex()}] -> [{b.FormatHex()}]";
            dst.Append(formatted);
        }

        public static void projection<S,T>(SpanBlock64<S> a, Vector128<T> b, ITextBuffer dst)
            where S : unmanaged
            where T : unmanaged
        {
            var sep = Chars.Space;
            var srcType = TypeIdentity.numeric<S>();
            var srcCount = a.CellCount;
            var dstType = TypeIdentity.numeric<T>();
            var dstCount = b.Length();
            var srcWidth = srcCount * width<S>();
            var dstWidth = dstCount * width<T>();
            var srcLabel = $"m{srcWidth}x{srcType}";
            var dstLabel = $"v{dstWidth}x{dstType}";
            var label = $"{srcLabel}_{dstLabel}";
            var formatted = $"{label}:[{a.Storage.FormatHex(sep, false)}] -> [{b.FormatHex(sep, false)}]";
            dst.Append(formatted);
        }
    }
}