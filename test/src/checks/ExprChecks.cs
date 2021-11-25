//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ExprChecks : Checker<ExprChecks>
    {
        static ICheckNumeric Claim = NumericClaims.Checker;

        public void CheckTextExpr()
        {
            const string Body = "$(dst), $(src1), $(src2)";
            var x = expr.textexpr(Body);
            var vars = x.Vars;
            Claim.eq(vars.Length,3);
            x["dst"] = "abc";
            x["src1"] = "def";
            x["src2"] = "hij";

            var result = x.Eval();
            Claim.eq("abc, def, hij", result);
        }
    }
}