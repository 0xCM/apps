//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using K = XedRules.FieldKind;
    using N = XedRules.RuleOpName;
    using T = XedRules.RuleTokenKind;

    using Asm;

    partial class XedRules
    {
        public class RuleMachine
        {
            RuleState state;

            [MethodImpl(Inline)]
            public static RuleMachine create()
                => new RuleMachine();

            [MethodImpl(Inline)]
            public static RuleMachine create(in RuleState src)
                => new RuleMachine(src);

            RuleMachine()
            {

            }

            RuleMachine(in RuleState src)
            {
                state = src;
            }

            public uint Update(ReadOnlySpan<RulePattern> src)
            {
                var counter = 0u;
                for(var i=0; i<src.Length; i++)
                    counter += Update(skip(src,i));
                return counter;
            }

            public uint Update(in RulePattern src)
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

                        }
                        break;
                        case T.FieldSeg:
                        {
                            // var seg = token.AsFieldSeg();
                            // if(seg.IsLiteral)
                            // {
                            //     Update(seg.ToAssignment());
                            //     counter++;
                            // }
                        }
                        break;
                        case T.Macro:
                        {
                            // var macro = XedRules.macro(token.AsMacro());
                            // for(var j=0; j<macro.Assignments.Count; j++, counter++)
                            // {
                            //     ref readonly var a = ref macro.Assignments[j];
                            //     Update(a);
                            // }
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

            [MethodImpl(Inline)]
            public ref readonly RuleState State()
                => ref state;

            [MethodImpl(Inline)]
            public RuleMachine Reset()
            {
                state = default;
                return this;
            }

            public RuleOperands RuleOps(in AsmHexCode code)
            {
                var _ops = list<RuleOp>();
                if(state.IMM0)
                    _ops.Add(new RuleOp(N.IMM0, imm(state, code)));

                if(state.BASE0 != 0)
                    _ops.Add(new RuleOp(N.BASE0, state.BASE0));

                if(state.BASE1 != 0)
                    _ops.Add(new RuleOp(N.BASE1, state.BASE1));

                if(state.SCALE != 0)
                    _ops.Add(new RuleOp(N.SCALE, state.SCALE));

                if(state.INDEX != 0)
                    _ops.Add(new RuleOp(N.INDEX, state.INDEX));

                if(state.REG0 != 0)
                    _ops.Add(new RuleOp(N.REG0, state.REG0));

                if(state.REG1 != 0)
                    _ops.Add(new RuleOp(N.REG1, state.REG1));

                if(state.REG2 != 0)
                    _ops.Add(new RuleOp(N.REG2, state.REG2));

                if(state.REG3 != 0)
                    _ops.Add(new RuleOp(N.REG3, state.REG3));

                if(state.REG4 != 0)
                    _ops.Add(new RuleOp(N.REG4, state.REG4));

                if(state.REG5 != 0)
                    _ops.Add(new RuleOp(N.REG5, state.REG5));

                if(state.REG6 != 0)
                    _ops.Add(new RuleOp(N.REG6, state.REG6));

                if(state.REG7 != 0)
                    _ops.Add(new RuleOp(N.REG7, state.REG7));

                if(state.REG8 != 0)
                    _ops.Add(new RuleOp(N.REG8, state.REG8));

                if(state.REG9 != 0)
                    _ops.Add(new RuleOp(N.REG9, state.REG9));

                if(state.DISP_WIDTH != 0)
                    _ops.Add(new RuleOp(N.DISP, disp(state, code)));

                if(state.RELBRVal.IsNonZero)
                    _ops.Add(new RuleOp(N.RELBR, state.RELBRVal));

                if(state.MEM0Val.IsNonEmpty)
                    _ops.Add(new RuleOp(N.MEM0, state.MEM0Val));

                if(state.MEM1Val.IsNonEmpty)
                    _ops.Add(new RuleOp(N.MEM1, state.MEM1Val));

                if(state.AGENVal.IsNonEmpty)
                    _ops.Add(new RuleOp(N.AGEN, state.AGENVal));

                return map(_ops, o => (o.Name, o)).ToDictionary();
            }

            public ConstLookup<FieldKind,object> Values()
            {
                var dst = dict<FieldKind,object>();
                var kinds = new ReflectedFields();
                var fields = kinds.RightValues;
                foreach(var f in fields)
                    dst.Add(kinds[f], f.GetValue(state));
                return dst;
            }

            public static ConstLookup<FieldKind,FieldInfo> fields()
            {
                var fields = typeof(RuleState).PublicInstanceFields();
                var count = fields.Length;
                var dst = dict<FieldKind,FieldInfo>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var field = ref skip(fields,i);
                    var tag = field.Tag<RuleFieldAttribute>();
                    if(tag)
                        dst.TryAdd(tag.Value.Kind, field);
                }
                return dst;
            }

        }
    }
}