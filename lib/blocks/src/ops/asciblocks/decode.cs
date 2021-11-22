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

    partial struct AsciBlocks
    {
        [MethodImpl(Inline), Op]
        public static uint decode<N>(in AsciBlock<N> src, Span<char> dst)
            where N : unmanaged, ITypeNat
                => decode(src.View,dst);

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<AsciCode> src, Span<char> dst, bool stopOnNull = true)
        {
            var count = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                if(code == 0 && stopOnNull)
                    break;

                seek(dst,i) = (char)code;
                counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in AsciBlock4 src)
        {
            var storage = 0ul;
            ref var dst = ref @as<ulong,char>(storage);
            ref readonly var input = ref @as<byte,uint>(src.First);
            seek(dst, 0) = (char)(byte)(input >> 0);
            seek(dst, 1) = (char)(byte)(input >> 8);
            seek(dst, 2) = (char)(byte)(input >> 16);
            seek(dst, 3) = (char)(byte)(input >> 24);
            return cover(dst, ByteBlock4.Size);
        }

        [MethodImpl(Inline), Op]
        public static void decode(in AsciBlock8 src, ref char dst)
        {
            var decoded = vinflate256x16u(vbytes(w128, src));
            vstore(decoded.GetLower(), ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(in AsciBlock16 src, ref char dst)
        {
           var decoded = vinflate256x16u(src.First);
           vstore(decoded, ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(in AsciBlock32 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref seek(dst, 16));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in AsciBlock16 src)
        {
            var dst = CharBlock16.Null;
            decode(src, ref dst.First);
            var length = text.index(dst.Data, '\0');
            if(length == NotFound)
                return dst.Data;
            else
                return slice(dst.Data, 0, length);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in AsciBlock32 src)
        {
            var dst = CharBlock32.Null;
            decode(src, ref dst.First);
            var length = text.index(dst.Data, '\0');
            if(length == NotFound)
                return dst.Data;
            else
                return slice(dst.Data, 0, length);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in AsciBlock64 src)
        {
            ref var storage = ref src.First;
            var v1 = vload(w256, storage);
            var v2 = vload(w256, seek(storage, 32));
            var x0 = vinflatelo256x16u(v1);
            var x1 = vinflatehi256x16u(v1);
            var x2 = vinflatelo256x16u(v2);
            var x3 = vinflatehi256x16u(v2);
            var chars = recover<char>(bytes(new V256x4(x0, x1, x2, x3)));
            var length = text.index(chars, '\0');
            if(length == NotFound)
                return chars;
            else
                return slice(chars, 0, length);
        }
    }
}