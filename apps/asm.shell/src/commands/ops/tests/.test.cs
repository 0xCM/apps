//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    partial class AsmCmdService
    {
        Outcome TestBraceMatching(CmdArgs args)
        {
            var result = Outcome.Success;
            const string Expect = "* 1 {} {33 a cde:} d*";
            var input = "aba {* 1 {} {33 a cde:} d*} x b";
            var output = SymbolicQuery.enclosed(input, 0, RenderFence.Embraced);
            if(output.IsNonEmpty)
            {
                var inner = text.inside(input, output.Min - 1, output.Max + 1);
                if(inner == Expect)
                    Write("Success");
                else
                    Write(string.Format("Fail:{0} != {1}", inner, Expect));
            }
            else
                Write("Fail:Empty");

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

        [CmdOp(".test-string-res")]
        Outcome TestStringRes(CmdArgs args)
        {
            using var flow = Wf.Running();
            var resources = Resources.strings(typeof(AsciText)).View;
            var count = resources.Length;
            for(var i=0; i<count; i++)
            {
                Write(skip(resources,i));
            }
            return true;
        }

        void CheckBitsParser()
        {
            // var source = BitFlow.nbits(12,0b110001110101u);
            // var input = "{1,1,0,0,0,1,1,1,0,1,0,1}";
            // var rendered = source.Format();
            // var parser = Parsers.bits<uint>();
            // var result = parser.Parse(input, out var output);
            // if(result.Fail)
            // {
            //     Error(result.Message);
            // }
            // else
            //     Write(string.Format("{0} => {1}", rendered, output));
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

        static Outcome same(string a, string b)
        {
            var same = a.Equals(b);
            return (same, string.Format("{0} {1} {2}", a, same ? "==" : "!=", b));
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