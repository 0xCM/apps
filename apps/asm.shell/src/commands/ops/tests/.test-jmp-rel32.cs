//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmSpecs;

    partial class AsmCmdService
    {
        [CmdOp(".test-jmp-rel32")]
        Outcome TestJmpRel32(CmdArgs args)
        {
            var result = Outcome.Success;
            var @case = AsmCaseAssets.create().Switch();

            var @base = (MemoryAddress)0x7ffd4512bf30;
            var @return = @base + (MemoryAddress)0x10b7;
            var sz = (byte)5;

            var l0 = 0x005a;
            var ip0 = @base + l0 + sz;
            var dx0 = asm.disp32(ip0, @return);
            var actual0 = jmp32(ip0, @return);
            var expect0 = asm.hexcode("e9 58 10 00 00");
            var d0l = asm.link(dx0, ip0, @return);
            Write(d0l);
            if(!actual0.Equals(expect0))
                Error(string.Format("{0} != {1}", expect0, actual0));
            else
                Write(string.Format("{0} == {1}", expect0, actual0));

            var l1 = 0x0065;
            var ip1 = @base + l1 + sz;
            var dx1 = asm.disp32(ip1, @return);
            var actual1 = jmp32(ip1, @return);
            var expect1 = asm.hexcode("e9 4d 10 00 00");
            var d1l = asm.link(dx1, ip1, @return);
            Write(d1l);
            if(!actual1.Equals(expect1))
                Error(string.Format("{0} != {1}", expect1, actual1));
            else
                Write(string.Format("{0} == {1}", expect1, actual1));

            var l2 = 0x0070;
            var ip2 = @base + l2 + sz;
            var dx2 = asm.disp32(ip2, @return);
            var actual2 = jmp32(ip2, @return);
            var expect2 = asm.hexcode("e9 42 10 00 00");
            var d2l = asm.link(dx2, ip2, @return);
            Write(d2l);
            if(!actual2.Equals(expect2))
                Error(string.Format("{0} != {1}", expect2, actual2));
            else
                Write(string.Format("{0} == {1}", expect2, actual2));

            var l3 = 0x007b;
            var ip3 = @base + l3 + sz;
            var dx3 = asm.disp32(ip3, @return);
            var actual3 = jmp32(ip3, @return);
            var expect3 = asm.hexcode("e9 37 10 00 00");
            var d3l = asm.link(dx3,ip3,@return);
            Write(d3l);
            if(!actual3.Equals(expect3))
                Error(string.Format("{0} != {1}", expect3, actual3));
            else
                Write(string.Format("{0} == {1}", expect3, actual3));

            return result;
        }
    }
}