//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        void EmitSigTerminals()
        {
            var rules = LoadSigProductions();
            var count = rules.Length;
            var productions = list<AsmSigProduction>();
            for(var i=0; i<count; i++)
            {
                ref readonly var rule = ref rules[i];
                var source = rule.Source;
                var terminals = rule.Target.Terminate();
                for(var j=0; j<terminals.Count; j++)
                    productions.Add(new AsmSigProduction(source, terminals[j]));
            }

            var prodCount = productions.Count;
            var records = list<AsmSigTerminal>(prodCount);
            var targets = dict<Identifier,AsmSigRuleExpr>();

            var k=0u;
            for(var i=0; i<prodCount; i++)
            {
                var production = productions[i];
                var source = production.Source;
                var target = production.Target;
                var name = AsmSigs.identify(target);
                if(targets.TryAdd(name, target))
                {
                    var record = new AsmSigTerminal();
                    record.Seq = k++;
                    record.Name = name;
                    record.Source = source;
                    record.Target = target;
                    records.Add(record);
                }
            }

            TableEmit(records.ViewDeposited(), AsmSigTerminal.RenderWidths, ProjectDb.TablePath<AsmSigTerminal>("sdm"));
        }
    }
}