//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/sdm/sigs")]
        Outcome CheckSdmSigs(CmdArgs args)
        {
            var rules = SdmRules.LoadSigProductions();
            var count = rules.Count;
            var productions = list<AsmSigProduction>();
            for(var i=0; i<count; i++)
            {
                ref readonly var rule = ref rules[i];
                var terminals = rule.Target.Terminate();
                for(var j=0; j<terminals.Count; j++)
                {
                    ref readonly var terminal = ref terminals[j];
                    productions.Add(new AsmSigProduction(rule.Source, terminal));
                }
            }

            var prodCount = productions.Count;
            var records = alloc<AsmSigTerminal>(prodCount);
            for(var i=0u; i<prodCount; i++)
            {
                ref var record = ref seek(records,i);
                record.Seq = i;
                record.Source = productions[(int)i].Source;
                record.Target = productions[(int)i].Target;
            }

            var dst = ProjectDb.TablePath<AsmSigTerminal>("sdm");
            TableEmit(@readonly(records), AsmSigTerminal.RenderWidths, dst);

            return true;
        }
    }
}