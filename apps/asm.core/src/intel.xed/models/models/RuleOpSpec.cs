//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct RuleOpSpec
        {
            public RuleOpName Name;

            public XedRuleOpKind Kind;

            public OpDirection Direction;

            public OperandWidth Width;

            public TableFunction Function;

            public Index<string> Attributes;

            public @string Expression;

            public string Format()
            {
                if(Attributes.IsNonEmpty)
                    return string.Format("{0}:{1}", Name, Attributes.Delimit(Chars.Colon));

                var dir = Symbols.expr(Direction);
                if(Function.IsNonEmpty)
                    return string.Format("{0}:{1}:{2}:{3}", Name, dir, Function, Width);
                else if(Width.IsEmpty)
                    return string.Format("{0}:{1}", Name, dir);
                else
                    return string.Format("{0}:{1}:{2}", Name, dir, Width);
            }

            public override string ToString()
                => Format();
        }
    }
}