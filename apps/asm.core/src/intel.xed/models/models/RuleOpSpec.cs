//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRecords;

    partial struct XedModels
    {
        public struct RuleOpSpec
        {
            public RuleOpName Name;

            public XedRuleOpKind Kind;

            public OpDirection Direction;

            public OperandWidth Width;

            public @string WidthRefinement;

            public TableFunction Function;

            public Index<string> Attributes;

            public @string Expression;

            [MethodImpl(Inline)]
            public RuleOpSpec(RuleOpName name, string[] attributes)
            {
                Name = name;
                Direction = 0;
                Kind = 0;
                Width = OperandWidth.Empty;
                WidthRefinement = @string.Empty;
                Function = TableFunction.Empty;
                Attributes = attributes;
                Expression = EmptyString;
            }

            public string Format()
            {
                if(Attributes.IsNonEmpty)
                    return string.Format("{0}:{1}", Name, Attributes.Delimit(Chars.Colon));

                var dir = Symbols.expr(Direction);

                if(Function.IsNonEmpty)
                    return string.Format("{0}:{1}:{2}:{3}:{4}", Name, dir, Function, Width, WidthRefinement);
                else if(Width.IsEmpty)
                    return string.Format("{0}:{1}", Name, dir);
                else
                    return string.Format("{0}:{1}:{2}:{3}", Name, dir, Width, WidthRefinement);
            }

            public override string ToString()
                => Format();
        }
    }
}