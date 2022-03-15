//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        // public RuleTableLookup CalcTables()
        // {
        //     void OnError(string src)
        //         => Write(src, FlairKind.Error);

        //     var parser = new RuleTableParser();
        //     var dst = dict<RuleSig,RuleTable>();

        //     var encdec = parser.Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));
        //     foreach(var t in encdec)
        //         dst.TryAdd(t.Sig, t);

        //     var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));
        //     foreach(var t in enc)
        //         dst.TryAdd(t.Sig, t);


        //     var dec = parser.Parse(XedPaths.DocSource(XedDocKind.DecRuleTable));
        //     foreach(var t in dec)
        //         dst.TryAdd(t.Sig, t);

        //     return dst;
        // }

        // public RuleTableLookup CalcEncDecTables()
        // {
        //     var parser = new RuleTableParser();
        //     var dst = dict<RuleSig,RuleTable>();
        //     var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));
        //     foreach(var t in enc)
        //         dst.Add(t.Sig, t);
        //     return dst;
        // }

        // public RuleTableLookup CalcEncTables()
        // {
        //     var parser = new RuleTableParser();
        //     var dst = dict<RuleSig,RuleTable>();
        //     var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));
        //     foreach(var t in enc)
        //         dst.Add(t.Sig, t);
        //     return dst;
        // }

        // public RuleTableLookup CalcDecTables()
        // {
        //     var parser = new RuleTableParser();
        //     var dst = dict<RuleSig,RuleTable>();
        //     var enc = parser.Parse(XedPaths.DocSource(XedDocKind.DecRuleTable));
        //     foreach(var t in enc)
        //         dst.TryAdd(t.Sig, t);
        //     return dst;
        // }
    }
}