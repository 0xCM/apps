//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".test-brace-match")]
        Outcome TestBraceMatching(CmdArgs args)
        {
            var result = Outcome.Success;
            const string Expect = "* 1 {} {33 a cde:} d*";
            var input = "aba {* 1 {} {33 a cde:} d*} x b";
            var inner = text.unfence(input,0, RenderFence.Embraced);
            if(inner!=Expect)
            {
                result = (false,string.Format("{0} != {1}", inner, Expect));
            }
            else
            {
                result = (true, "Success");
            }

            return result;

        }

        [CmdOp("test/bv128")]
        Outcome TestBv128(CmdArgs args)
        {
            var result = Outcome.Success;
            var bv0 = BitVectors.init(w128,(byte)0b10101010);
            Write(bv0.Format());
            var bv1 = bv0 << 12;
            Write(bv1.Format());
            var bv3 = bv1.Set(0,1).Set(1,1).Set(2,1).Set(3,1);
            Write(bv3);
            return result;
        }


        Span<char> GenBitStrings8(uint count)
        {
            // var count = 256;
            // var length = 8;
            var buffer = span<char>(count*8);
            for(var i=0; i<count; i++)
            {
                ref var c = ref seek(buffer,i*8);
                for(byte j=0; j<8; j++)
                    seek(c,7-j) = bit.test(i,(byte)j).ToChar();
            }
            return buffer;
        }

        void CheckBitSeq()
        {
            var count = 256u;
            byte length = 8;
            var buffer = GenBitStrings8(count);

            for(var i=0; i<count; i++)
            {
                var offset = i*length;
                var s = slice(buffer,offset,length);
                Write(string.Format("{0:D3}=0x{0:X2}=0b{1}", i, text.format(s)));
            }
        }


        void CheckCells()
        {
            var source = alloc<byte>(Pow2.T08);
            source.Clear();
            Random.Bytes(source);
            var cells = recover<Cell16>(source);
            var count = cells.Length;
            var n = (uint)width<Cell16>();
            var buffer = span<char>(128);
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                bits<Cell16> bits = (n, skip(cells,i));
                var len = BitRender.render(n,bits,buffer);
                slice(buffer,0,len);
                Write(string.Format("{0} Value{1} = {2};", bits.TypeName, i, text.format(slice(buffer,0,len))));
            }
        }

        void ShowLiterals(Type src, Base2 @base)
        {
            var literals = Clr.literals(src, @base).View;
            var count = literals.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var literal = ref skip(literals, i);
                Write(string.Format("{0,-24} | {1,-64} | {2}", literal.Name, literal.Data, literal.Text));
            }
        }
   }
}