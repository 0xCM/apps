//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    using static core;

    [ApiHost]
    public partial class AsmBits
    {
        const NumericKind Closure = UnsignedInts;

        const string FieldSep = " | ";

        const char Open = Chars.LBracket;

        const char Close = Chars.RBracket;

        static AsmBits The;

        AsmBits()
        {
        }

        static AsmBits()
        {
            The = new AsmBits();
        }


        [MethodImpl(Inline), Op]
        public static uint opcode(Hex8 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            BitRender.render8(src, ref  i, dst);
            return i-i0;
        }

        const string ModRmHeader = "mod | reg | r/m | hex | bitstring";

         [MethodImpl(Inline), Op]
         static byte combine(Pair<byte> a, Pair<byte> b, Pair<byte> c)
         {
             var dst = Bytes.sll(a.Left, a.Right);
             dst = Bytes.or(dst, Bytes.sll(b.Left, b.Right));
             dst = Bytes.or(dst, Bytes.sll(c.Left, c.Right));
             return dst;
         }

        [MethodImpl(Inline), Op]
        public static ModRm modrm(byte rm, byte reg, byte mod)
            => new ModRm(combine((rm, 0), (reg, 3), (mod, 6)));

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
                modrm(modrm(skip(f0, a), skip(f1, b), skip(f2, c)), ref k, dst);
                text.crlf(ref k, dst);
            }
            return k;
        }

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

            text.copy(src.Format(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            text.copy(FieldSep, ref i, dst);

            text.copy(src.ToBitString(), ref i, dst);

            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint vsib(Vsib src, Span<char> dst)
        {
            var i=0u;
            seek(dst,i++) = Open;
            BitNumbers.render(src.SS(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            BitNumbers.render(src.Index(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            BitNumbers.render(src.Base(), ref i, dst);
            seek(dst,i++) = Close;
            return i;
        }

        [Op]
        public static AsmBitstring bitstring(in AsmHexCode src)
            => src;

    }
}