//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ExprChecks : Checker<ExprChecks>
    {
        static ICheckNumeric Claim = NumericClaims.Checker;

        public void CheckTextExpr()
        {
            const string Body = "$(dst), $(src1), $(src2)";
            var x = TextExpr.init(Body);
            var vars = x.Vars;
            Claim.eq(vars.Length,3);
            x["dst"] = new TextVar("dst", (Identifier)"abc");
            x["src1"] = new TextVar("src1", (Identifier)"def");
            x["src2"] = new TextVar("src2", (Identifier)"hij");

            var result = x.Eval();
            Claim.eq("abc, def, hij", result);
        }
    }
}