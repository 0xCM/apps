//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedRules;

    using T = XedRules.RuleTokenKind;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/machine")]
        Outcome CheckMachine(CmdArgs args)
        {
            var s0 = new RuleState();
            var machine = RuleMachine.create(s0);
            var m0 = machine.Values();
            var vm0 = m0.Values;
            var fcount = m0.EntryCount;
            var keys = m0.Keys;
            var patterns = Xed.Rules.CalcPatterns(RuleSetKind.Enc);
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                var count = Update(pattern,machine);
                if(count != 0)
                {
                    var m1 = machine.Values();
                    var vm1 = m1.Values;
                    for(var j=0; j<fcount; j++)
                    {
                        ref readonly var a = ref skip(vm0,j);
                        ref readonly var b = ref skip(vm1,j);
                        if(!object.Equals(a,b))
                        {
                            var f = skip(keys,j);
                            Write(string.Format("{0}:{1} -> {2}", f, a, b));
                        }
                    }
                }
            }
            return true;
        }


        uint Update(in RulePattern src, RuleMachine dst)
        {
            ref readonly var tokens = ref src.Tokens;
            var counter = 0u;
            for(var i=0; i<tokens.Count; i++)
            {
                ref readonly var token = ref tokens[i];
                ref readonly var kind = ref token.Kind;
                switch(kind)
                {
                    case T.BinLit:
                    {

                    }
                    break;
                    case T.HexLit:
                    {

                    }
                    break;
                    case T.DecLit:
                    {


                    }
                    break;
                    case T.Constraint:
                    {
                        var constraint = token.AsConstraint();
                    }
                    break;
                    case T.FieldSeg:
                    {
                        var seg = token.AsFieldSeg();
                        if(seg.IsLiteral)
                        {
                            dst.Update(seg.ToAssignment());
                            counter++;
                        }
                    }
                    break;
                    case T.Macro:
                    {
                        var macro = XedRules.macro(token.AsMacro());
                        for(var j=0; j<macro.Assignments.Count; j++, counter++)
                        {
                            ref readonly var a = ref macro.Assignments[j];
                            dst.Update(a);
                        }
                    }
                    break;
                    case T.Nonterm:
                    {

                    }
                    break;

                }
            }
            return counter;
        }

    }
}