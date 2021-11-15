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
        [Op]
        public static uint SibTable(Span<char> dst)
        {
            const string Header = "scale | index | base | hex | bitstring";

            var m=0u;
            text.copy(Header, ref m, dst);
            text.crlf(ref m, dst);

            var f0 = BitSeq.bits(n3);
            var f1 = BitSeq.bits(n3);
            var f2 = BitSeq.bits(n2);

            for(var k=0; k<f2.Length; k++)
            {
                for(var j=0; j<f1.Length; j++)
                {
                    for(var i=0; i<f0.Length; i++)
                    {
                        var b0 = skip(f0, i);
                        var b1 = skip(f1, j);
                        var b2 = skip(f2, k);
                        sib(new Sib(BitNumbers.join(b0,b1,b2)), ref m, dst);
                        text.crlf(ref m, dst);
                    }
                }
            }
            return m;
        }

        public static Index<SibBitfieldRow> SibRows()
        {
            var buffer = alloc<SibBitfieldRow>(256);
            var f0 = BitSeq.bits(n3);
            var f1 = BitSeq.bits(n3);
            var f2 = BitSeq.bits(n2);
            ref var dst = ref first(buffer);
            var m = 0u;
            for(var k=0; k<f2.Length; k++)
            {
                for(var j=0; j<f1.Length; j++)
                {
                    for(var i=0; i<f0.Length; i++)
                    {
                        ref var row = ref seek(dst,m);
                        row.@base = skip(f0, i);
                        row.index = skip(f1, j);
                        row.scale = skip(f2, k);
                        var sib = new Sib(BitNumbers.join(row.@base, row.index, row.scale));
                        row.bitstring = bitstring(sib);
                        row.hex = (byte)m;
                        m++;
                    }
                }
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static uint sib(Sib src, ref uint i, Span<char> dst)
        {
            var i0=i;
            BitRender.render2(src.Scale(), ref i, dst);
            text.copy(FieldSep, ref i, dst);

            BitRender.render3(src.Index(), ref i, dst);
            text.copy(FieldSep, ref i, dst);

            BitRender.render3(src.Base(), ref i, dst);

            text.copy(FieldSep, ref i, dst);

            text.copy(src.Encoded.FormatHex(2), ref i, dst);
            seek(dst,i++) = Chars.Space;
            text.copy(FieldSep, ref i, dst);

            text.copy(bitstring(src), ref i, dst);

            return i-i0;
        }

        public static string bitstring(Sib src)
            => string.Format("{0} {1} {2}", BitRender.format2(src.Scale()), BitRender.format3(src.Index()), BitRender.format3(src.Base()));
    }
}