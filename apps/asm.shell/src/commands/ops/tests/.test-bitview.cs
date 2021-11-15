//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".test-bitview")]
        Outcome CheckBitView(CmdArgs args)
        {
            var result = Outcome.Success;
            //var m0 = BitMasks.odd<ulong>();
            var m = vmask.vodd(w128);
            var bits = BitView.create(m);
            Write(m.FormatHex(Chars.Space));
            var i=0u;
            Write($"1: {bits.View(w1, i)}");
            Write($"2: {bits.View(w2, i)}");
            Write($"3: {bits.View(w3, i)}");
            Write($"4: {bits.View(w4, i)}");
            Write($"5: {bits.View(w5, i)}");
            Write($"6: {bits.View(w6, i)}");
            Write($"7: {bits.View(w7, i)}");
            Write($"8: {bits.View(w8, i)}");

            i++;
            Write($"1: {bits.View(w1, i)}");
            Write($"2: {bits.View(w2, i)}");
            Write($"3: {bits.View(w3, i)}");
            Write($"4: {bits.View(w4, i)}");
            Write($"5: {bits.View(w5, i)}");
            Write($"6: {bits.View(w6, i)}");
            Write($"7: {bits.View(w7, i)}");
            Write($"8: {bits.View(w8, i)}");

            return result;
        }

        [CmdOp(".test-bitsparser")]
        Outcome TestBitsBarser(CmdArgs args)
        {
            var result = Outcome.Success;
            var input = "{0,1,1,0,0,1}";
            var parser = new BitsParser<byte>();
            result = parser.Parse(input, out var dst);
            if(result)
                Write(dst.Format());

            return result;
        }
    }
}