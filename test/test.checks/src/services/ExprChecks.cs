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
            var dst = TextTemplateVar.define("dst");
            var src1 = TextTemplateVar.define("src1");
            var src2 = TextTemplateVar.define("src2");
            var body = string.Format("{0}, {1}, {2}", dst, src1, src2);
            var x = TextTemplateExpr.init(body);
            var vars = x.Vars;
            Claim.eq(vars.Length,3);
            x["dst"] = new TextTemplateVar("dst", (Identifier)"abc");
            x["src1"] = new TextTemplateVar("src1", (Identifier)"def");
            x["src2"] = new TextTemplateVar("src2", (Identifier)"hij");

            var result = x.Eval();
            Claim.eq("abc, def, hij", result);
        }
    }
}