//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using static AsciSymbols;
    using static AsciChars;

    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static void decode(N48 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            ref var target = ref @as<ushort>(first(dst));
            var v = cpu.vload(w256, src);
            var offset = z8;
            cpu.vstore(vpack.vinflatelo256x16u(v), ref target);
            offset+=16;
            cpu.vstore(vpack.vinflatehi256x16u(v), ref seek(target,offset));
            offset+=16;
            decode(n16, core.slice(src,offset), core.slice(dst,offset));
        }

        [MethodImpl(Inline), Op]
        public static Vector128<ushort> decode(ulong src)
            => cpu.vlo(vpack.vinflate256x16u(cpu.v8u(cpu.vscalar(src))));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> decode(Vector128<byte> src)
            => vpack.vinflate256x16u(src);

        [MethodImpl(Inline), Op]
        public static Vector512<ushort> decode(Vector256<byte> src)
            => cpu.vparts(w512, vpack.vinflatelo256x16u(src), vpack.vinflatehi256x16u(src));

        [MethodImpl(Inline), Op]
        public static ref string decode(ReadOnlySpan<byte> src, out string dst)
        {
            Span<char> buffer = stackalloc char[src.Length];
            AsciSymbols.decode(src, buffer);
            dst = sys.@string(buffer);
            return ref dst;
        }
    }
}