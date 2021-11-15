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

    [ApiHost]
    public readonly struct AsciBlocks
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T load<T>(ReadOnlySpan<AsciCode> src, out T dst)
            where T : unmanaged, IAsciBlock<T>
        {
            dst = default(T);
            var count = min(src.Length,dst.Size);
            ref var target = ref @as<AsciCode>(dst.First);
            for(var i=0; i<count; i++)
                seek(target,i) = skip(src,i);
            return ref dst;
        }

        public static AsciBlock<N> alloc<N>(N n = default)
            where N : unmanaged, ITypeNat
        {
            var buffer = core.alloc<AsciCode>(Typed.value<N>());
            return new AsciBlock<N>(buffer);
        }

        public static AsciBlock<N> load<N>(AsciCode[] src, N n = default)
            where N : unmanaged, ITypeNat
        {
            Require.equal<N>(src.Length);
            return new AsciBlock<N>(src);
        }

        public static AsciBlock<N> create<N>(string src, N n = default)
            where N : unmanaged, ITypeNat
        {
            var buffer = core.alloc<AsciCode>(value<N>());
            buffer.Clear();
            var chars = span(src);
            ref var dst = ref first(buffer);
            var count = min(buffer.Length, chars.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (AsciCode)skip(chars,i);
            return new AsciBlock<N>(buffer);
        }

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

        public static string format<N>(AsciBlock<N> src)
            where N : unmanaged, ITypeNat
        {
            var input = src.View;
            var dst = span<char>(input.Length);
            var count = decode(input,dst);
            return new string(slice(dst,0,count));
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
            return recover<char>(bytes(new V256x4(x0, x1, x2, x3)));
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock4 encode(N4 n, ReadOnlySpan<char> src)
        {
            var dst = AsciBlock4.Empty;
            var count = min(n,src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock8 encode(N8 n, ReadOnlySpan<char> src)
        {
            var dst = AsciBlock8.Empty;
            var count = min(n,src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock16 encode(N16 n, ReadOnlySpan<char> src)
        {
            var dst = AsciBlock16.Empty;
            var count = min(n,src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsciBlock16 encode(ReadOnlySpan<char> src, out AsciBlock16 dst)
        {
            dst = default;
            var count = min(ByteBlock16.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock32 encode(N32 n, ReadOnlySpan<char> src)
        {
            var dst = AsciBlock32.Empty;
            var count = min(n,src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsciBlock32 encode(ReadOnlySpan<char> src, out AsciBlock32 dst)
        {
            dst = default;
            var count = min(ByteBlock32.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        static int encode(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
            return count;
        }
    }
}