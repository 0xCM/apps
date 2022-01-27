//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class CheckCmdProvider
    {
        [CmdOp("check/expr/scopes")]
        Outcome TestScopes(CmdArgs args)
        {
            var result = Outcome.Success;

            ExprScope a = "a";

            Require.invariant(a.IsRoot);

            ExprScope b = "b";
            Require.invariant(b.IsRoot);

            var c = a + b;
            Require.equal(c, "a.b");

            var d = ExprScope.root("d");
            var e = c + d;
            Require.equal(e, "a.b.d");

            var fg = ExprScope.root("f") + ExprScope.root("g");
            var h = e + fg;
            Require.equal(h, "a.b.d.f.g");

            return result;
        }
    }
}