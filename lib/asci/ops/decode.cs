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
    using static vcore;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci2 src)
        {
            var storage = 0u;
            ref var dst = ref @as<uint,char>(storage);
            seek(dst, 0) = (char)(byte)(src.Storage >> 0);
            seek(dst, 1) = (char)(byte)(src.Storage >> 8);
            return core.cover(dst, 2);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci4 src)
        {
            var storage = 0ul;
            ref var dst = ref @as<ulong,char>(storage);
            seek(dst, 0) = (char)(byte)(src.Storage >> 0);
            seek(dst, 1) = (char)(byte)(src.Storage >> 8);
            seek(dst, 2) = (char)(byte)(src.Storage >> 16);
            seek(dst, 3) = (char)(byte)(src.Storage >> 24);
            return core.cover(dst, asci4.Size);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci8 src)
            => recover<char>(core.bytes(vlo(vinflate256x16u(vbytes(w128, src.Storage)))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in ByteBlock8 src)
            => recover<char>(core.bytes(vlo(vinflate256x16u(vbytes(w128, u64(src))))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in ByteBlock16 src)
            => recover<char>(core.bytes(vlo(vinflate256x16u(vbytes(w128, u64(src))))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in ByteBlock32 src)
        {
            var v = vload(w256, src.Bytes);
            var lo = vinflatelo256x16u(v);
            var hi = vinflatehi256x16u(v);
            return recover<char>(core.bytes(new V256x2(lo,hi)));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci16 src)
            => recover<char>(core.bytes(vinflate256x16u(src.Storage)));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci32 src)
        {
            var lo = vinflatelo256x16u(src.Storage);
            var hi = vinflatehi256x16u(src.Storage);
            return recover<char>(core.bytes(new V256x2(lo,hi)));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci64 src)
        {
            var x = src.Storage;
            var x0 = vinflatelo256x16u(x.Lo);
            var x1 = vinflatehi256x16u(x.Lo);
            var x2 = vinflatelo256x16u(x.Hi);
            var x3 = vinflatehi256x16u(x.Hi);
            return recover<char>(core.bytes(new V256x4(x0, x1, x2, x3)));
        }

        [MethodImpl(Inline), Op]
        public static void decode(in asci8 src, ref char dst)
        {
            var decoded = vinflate256x16u(vbytes(w128, src.Storage));
            vstore(decoded.GetLower(), ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(in asci16 src, ref char dst)
        {
           var decoded = vinflate256x16u(src.Storage);
           vstore(decoded, ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(in asci32 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref seek(dst, 16));
        }

        [MethodImpl(Inline), Op]
        public static void decode(in asci64 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref seek(dst, 32));
        }
    }
}