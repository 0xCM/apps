//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            var dst = dict<RuleSig, RuleTable>();
            var enc = Xed.Rules.Tables.CalcTables(RuleTableKind.Enc);
            iter(enc.Values, t => dst.Add(t.Sig,t));
            var dec = Xed.Rules.Tables.CalcTables(RuleTableKind.Dec);
            iter(dec.Values, t => dst.Add(t.Sig,t));
            var encdec = Xed.Rules.Tables.CalcTables(RuleTableKind.EncDec);
            iter(encdec.Values, t => dst.Add(t.Sig,t));

            return true;
        }

    }
}