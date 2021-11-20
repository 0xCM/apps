//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class AsmBits
    {
        const string ModRmHeader = "mod | reg | r/m | hex | bitstring";

        const string ModRmBitstring = "{0} {1} {2}";

        [Op]
        public static uint ModRmTable(Span<char> dst)
        {
            var f0 = BitSeq.bits(n3);
            var f1 = BitSeq.bits(n3);
            var f2 = BitSeq.bits(n2);
            var k=0u;
            text.copy(ModRmHeader, ref k, dst);
            text.crlf(ref k, dst);

            for(var c=0u; c<f2.Length; c++)
            for(var b=0u; b<f1.Length; b++)
            for(var a=0u; a<f0.Length; a++)
            {
                modrm(AsmEncoding.modrm(skip(f0, a), skip(f1, b), skip(f2, c)), ref k, dst);
                text.crlf(ref k, dst);
            }
            return k;
        }

        public static string bitstring(ModRm src)
            => string.Format(ModRmBitstring, BitRender.format2(src.Mod()), BitRender.format3(src.Reg()), BitRender.format3(src.Rm()));

        public static uint modrm(ModRm src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            BitRender.render2(src.Mod(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            text.copy(FieldSep, ref i, dst);

            BitRender.render3(src.Reg(), ref i, dst);
            text.copy(FieldSep, ref i, dst);

            BitRender.render3(src.Rm(), ref i, dst);
            text.copy(FieldSep, ref i, dst);

            text.copy(src.Encoded.FormatHex(2), ref i, dst);
            seek(dst,i++) = Chars.Space;
            text.copy(FieldSep, ref i, dst);

            text.copy(bitstring(src), ref i, dst);

            return i - i0;
        }
    }
}