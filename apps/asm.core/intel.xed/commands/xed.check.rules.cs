//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedPatterns;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var rules = XedRules.CalcTableSet(true);


            //iter(rules.SigRows, row => Write(string.Format("{0,-6} | {1,-46} | {2}", row.TableKind, row.TableName, row.TableDef)));
            return true;
        }
    }
}