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

            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var fields = ref pattern.Fields;
                for(var j=0; j<fields.Count; j++)
                {
                    ref readonly var field = ref fields[j];
                    if(field.IsNonTerminal)
                    {
                        ref readonly var nt = ref field.AsNonterminal();
                        if(nt.Name == "MODRM")
                            continue;

                        var path = rules.FindTablePath(nt.Name);
                        if(path.IsNonEmpty)
                            Write(string.Format("{0,-18} | {1}::{2}", pattern.Classifier, nt, path));
                        else
                            Warn(string.Format("Table for nonterminal {0} not found", nt));
                    }
                }
            }

            //iter(rules.SigRows, row => Write(string.Format("{0,-6} | {1,-46} | {2}", row.TableKind, row.TableName, row.TableDef)));
            return true;
        }
    }
}