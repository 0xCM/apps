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
        [CmdOp("asm/check/directives")]
        Outcome CheckDirectives(CmdArgs args)
        {
            var data = array<byte>(1,2,3,4,5,6);
            var actual = NativeShape.calc(data);
            var expect = NativeShape.define(n4:1, n2:1);
            Require.equal(actual,expect);
            return true;
        }
    }
}