//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

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