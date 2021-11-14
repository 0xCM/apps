//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    partial class AsmCmdService
    {
        [CmdOp(".test-vcpu")]
        unsafe Outcome TestVCpu(CmdArgs args)
        {
            var result = Outcome.Success;
            var v0 = vmask.veven<byte>(w128, n2, n2);
            var v0bits = v0.ToBitSpan();
            var options = BitFormat.configure();
            options.BlockWidth = 8;
            Write(v0bits.Format(options));
            var v1 = vmask.veven<byte>(w256, n2, n2);
            var v1bits = v1.ToBitSpan();
            Write(v1bits.Format(options));
            return result;
        }
    }
}
