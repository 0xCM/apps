//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/directives")]
        Outcome CheckDirectives(CmdArgs args)
        {
            var data = array<byte>(1,2,3,4,5,6);
            var actual = NativeShape.calc(data);
            var expect = NativeShape.define(n4:1, n2:1);
            Require.equal(actual,expect);
            return true;
        }


        [CmdOp("check/asm/flags")]
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