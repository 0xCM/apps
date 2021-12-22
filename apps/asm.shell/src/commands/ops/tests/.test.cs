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

        [CmdOp("test/flags")]
        Outcome TestFlags(CmdArgs args)
        {
            var result = Outcome.Success;

            void Check1()
            {
                var expect = "1000001001000100";
                var flags = Flags.create(Pow2x16.P2ᐞ02 | Pow2x16.P2ᐞ06 | Pow2x16.P2ᐞ09 | Pow2x16.P2ᐞ15);
                var actual = flags.Format();
                result = actual == expect;
            }

            Check1();
            if(result.Fail)
                return result;

            void Check2()
            {
                var flags = Flags.create(Pow2x32.P2ᐞ06 | Pow2x32.P2ᐞ07 | Pow2x32.P2ᐞ08 | Pow2x32.P2ᐞ09);
            }

            Check2();
            if(result.Fail)
                return result;


            return result;
        }

        [CmdOp(".test-native-cells")]
        unsafe Outcome TestNativeCells(CmdArgs args)
        {
            var count = 256u;
            byte length = 8;
            var result = Outcome.Success;
            using var native = NativeCells.alloc<string>(count, out var id);
            var bits = GenBitStrings8(count);
            for(var i=0u; i<count; i++)
            {
                var offset = i*length;
                native.Content(i) = new string(slice(bits, offset, length));
            }

            for(var i=0u; i<count; i++)
                Write(native.Content(i));

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

        Outcome ShowObjDump(CmdArgs args)
        {
            var result = Outcome.Success;

            var tool = Wf.LlvmObjDump();
            var rows = tool.Consolidated(State.ProjectId()).View;
            var count = rows.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                Write(string.Format("Statement:{0}", row.Asm));
                Write(string.Format("Encoding :{0}", row.Encoding));
            }
            return result;
        }

        void CheckCells()
        {
            var source = alloc<byte>(Pow2.T08);
            source.Clear();
            Random.Bytes(source);
            var cells = recover<Cell16>(source);
            var count = cells.Length;
            var n = width<Cell16>();
            var buffer = span<char>(128);
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                var bits = bit.nbits(n, skip(cells,i));
                var len = bit.render(bits,buffer);
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