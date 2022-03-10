//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using T = XedRules.RuleTokenKind;


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