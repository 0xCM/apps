//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct RuleOpSpec
        {
            public RuleOpName Kind {get;}

            public OpDirection Direction {get;}

            public OperandWidth Width {get;}

            public @string WidthRefinement {get;}

            public TableFunction Function {get;}

            public Index<string> Attributes {get;}

            [MethodImpl(Inline)]
            public RuleOpSpec(RuleOpName kind, string[] attributes)
            {
                Kind = kind;
                Direction = 0;
                Width = OperandWidth.Empty;
                WidthRefinement = @string.Empty;
                Function = TableFunction.Empty;
                Attributes = attributes;
            }

            [MethodImpl(Inline)]
            public RuleOpSpec(RuleOpName kind, OpDirection dir, OperandWidth width, string refinement, TableFunction fx)
            {
                Kind = kind;
                Direction = dir;
                Width = width;
                Function = fx;
                WidthRefinement = refinement;
                Attributes = sys.empty<string>();
            }

            [MethodImpl(Inline)]
            public RuleOpSpec(RuleOpName kind, OpDirection dir, OperandWidth width, string refinement)
            {
                Kind = kind;
                Width = width;
                Direction = dir;
                WidthRefinement = refinement;
                Function = TableFunction.Empty;
                Attributes = sys.empty<string>();
            }

            public string Format()
            {
                if(Attributes.IsNonEmpty)
                    return string.Format("{0}:{1}", Kind, Attributes.Delimit(Chars.Colon));

                var dir = Symbols.expr(Direction);

                if(Function.IsNonEmpty)
                    return string.Format("{0}:{1}:{2}:{3}:{4}", Kind, dir, Function, Width, WidthRefinement);
                else if(Width.IsEmpty)
                    return string.Format("{0}:{1}", Kind, dir);
                else
                    return string.Format("{0}:{1}:{2}:{3}", Kind, dir, Width, WidthRefinement);
            }

            public override string ToString()
                => Format();
        }
    }
}