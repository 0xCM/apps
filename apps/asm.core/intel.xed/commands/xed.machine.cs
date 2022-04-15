//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedCmdProvider
    {
        void Step(XedMachine machine, InstPattern pattern)
        {
            machine.Pattern() = pattern;
            machine.Emitter.EmitClassForms();
        }

        void Step(XedMachine machine, Index<InstPattern> src)
        {
            var ws = Ws.Project("xed.machine");
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern =ref src[i];
                if(pattern.InstClass.Classifier == IClass.AND)
                {
                    Step(machine, pattern);
                }
            }
        }

        [CmdOp("xed/machine")]
        Outcome RunMachine(CmdArgs args)
        {
            // var patterns = Xed.Rules.CalcInstPatterns();
            // using var machine = XedMachine.allocate(Wf);
            // Step(machine,patterns);

            Wf.XedMachinHost().Run();

            // var groups = Xed.Rules.CalcInstGroups(patterns);
            // var group = groups.Where(g => g.Class == IClass.AND);
            // var machine = Wf.XedMachine();
            // foreach(var g in group)
            // {
            //     ref readonly var members = ref g.Members;
            //     for(var i=0; i<g.MemberCount; i++)
            //     {
            //         ref readonly var member = ref g[i];
            //         ref readonly var pattern = ref member.Pattern;
            //         machine.Pattern() = pattern;
            //         ref readonly var mod = ref member.Mod;
            //         ref readonly var rexw = ref member.RexW;
            //         ref readonly var @lock = ref member.Lock;

            //         Write(string.Format("{0,-8} | {1,-18} | {2,-8} | {3,-8} | {4,-26}",
            //             machine.Mode(),
            //             machine.InstClass.Classifier,
            //             member.Indicator,
            //             member.Index,
            //             machine.OpCode.Format()
            //             ));

            //         for(byte j=0; j<machine.OpCount; j++)
            //         {
            //             ref readonly var op = ref machine.Op(j);
            //             Write(op.Format());
            //             if(op.IsNonterm)
            //             {
            //                 ref readonly var nonterm = ref op.NonTerm;
            //                 var table = machine.NontermOpTable(j);
            //                 Write(table.Format());
            //             }
            //         }
            //     }
            //}

            return true;
        }
    }
}