//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/check/flags")]
        Outcome CheckAsmFlags(CmdArgs args)
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