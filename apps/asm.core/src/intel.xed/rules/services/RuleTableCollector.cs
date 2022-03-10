//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public sealed class TableCollector : RuleTraverser
        {
            ConcurrentDictionary<RuleSig,ConcurrentBag<RuleCriterion>> Premise;

            ConcurrentDictionary<RuleSig,ConcurrentBag<RuleCriterion>> Consequent;

            ConcurrentDictionary<RuleSig,RuleTable> TableLookup;

            public ConstLookup<RuleSig,RuleTable> Tables
                => TableLookup;

            public TableCollector(Action<string> errors, bool pll = true)
                : base(errors,pll)
            {

            }

            protected override void Traversing()
            {
                Premise = new();
                Consequent = new();
                TableLookup = new();
            }

            protected override void Traversing(in RuleTermTable src)
            {
                Premise.TryAdd(src.Sig, new());
                TableLookup.TryAdd(src.Sig, table(src));
            }

            protected override void Traversing(in RuleSig table, in RuleCriterion src)
            {
                if(src.IsPremise)
                {
                    if(Premise.TryGetValue(table, out var dst))
                        dst.Add(src);
                }
                else if(src.IsConsequent)
                {
                    if(Consequent.TryGetValue(table, out var dst))
                        dst.Add(src);
                }
            }

            protected override void Traversing(in RulePattern src)
            {

            }

            protected override void Traversing(uint pattern, in RuleToken token)
            {
            }


            static RuleTable table(in RuleTermTable src)
            {
                var buffer = alloc<RuleExpr>(src.Expressions.Count);
                for(var i=0; i<src.Expressions.Count; i++)
                {
                    ref readonly var input = ref src.Expressions[i];
                    var p = RuleTables.specs(true, input.Premise.Map(x=> x.Format()).Delimit(Chars.Space).Format());
                    var c = RuleTables.specs(false, input.Consequent.Map(x=> x.Format()).Delimit(Chars.Space).Format());
                    seek(buffer,i) = new RuleExpr(p,c);
                }
                var dst = RuleTable.Empty;
                dst.Expressions = buffer;
                dst.Name = src.Name;
                dst.ReturnType = src.ReturnType;
                XedParsers.parse(src.Name, out dst.EncodingGroup);
                return dst;
            }
        }
    }
}