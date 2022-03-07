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
        [CmdOp("xed/check/specs")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            void Traversed(string src)
            {
                Write(src, FlairKind.Error);
            }

            var traverser = new RuleTraverserX(Traversed, false);
            var rules = Xed.Rules.ExpandMacros(Xed.Rules.CalcRuleSet(RuleSetKind.EncDec));
            traverser.Traverse(rules);
            var tables = traverser.Tables;
            var sigs = tables.Keys.ToArray().Sort();
            var path = AppDb.XedPath("xed.rules.tables", FileKind.Txt);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            for(var i=0; i<sigs.Length; i++)
                writer.WriteLine(tables[skip(sigs,i)].Format());

            EmittedFile(emitting, sigs.Length);
            return true;
        }

    }
}