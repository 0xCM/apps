//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    partial class AsmCmdService
    {
        [CmdOp(".test-bitspans")]
        Outcome TestBitSpans(CmdArgs args)
        {
            var result = Outcome.Success;
            var options = BitFormat.Default.WithBlockWidth(8);
            var v1 = vmask.vmsb<byte>(w128, n8, n7);
            var b1 = v1.ToBitSpan();
            Write(b1.Format(options));
            return result;
        }
    }
}