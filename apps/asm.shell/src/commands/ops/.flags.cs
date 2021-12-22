//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp("eflags/status")]
        Outcome StatusFlags(CmdArgs args)
        {
            var result = Outcome.Success;
            var flags = new StatusFlags();
            flags.OF(true);
            flags.SF(true);
            Write(flags.Format());
            return result;
        }
    }
}