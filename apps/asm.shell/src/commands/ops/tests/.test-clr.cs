//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".test-clr")]
        Outcome TestClrInternals(CmdArgs args)
        {
            var result = Outcome.Success;

            var src = typeof(math);
            var table = ClrInternals.methods(src);
            var eec = ClrInternals.eeclass(table);
            var c0 = ClrInternals.chunk(eec);
            var c1 = ClrInternals.next(c0);
            var c2 = ClrInternals.next(c1);
            var c3 = ClrInternals.next(c2);
            Write(c0);
            Write(c1);
            Write(c2);
            Write(c3);
            return result;
        }

    }
}