//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct NontermExpr
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Op;

            public readonly Nonterminal Nonterm;

            [MethodImpl(Inline)]
            public NontermExpr(FieldKind field, RuleOperator op, Nonterminal nt)
            {
                Field = field;
                Op = op;
                Nonterm = nt;
            }

            public bool IsEmpty
            {
                get => Field == 0 && Op.IsEmpty && Nonterm.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public string Name
                => Nonterm.Name;

            public string Format()
                => IsNonEmpty ? string.Format("{0}{1}{2}", XedRender.format(Field), Op.Format(), Nonterm.Format()) : RP.Error;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator uint(NontermExpr src)
                => core.u32(src);

            [MethodImpl(Inline)]
            public static explicit operator NontermExpr(uint src)
                => core.generic<NontermExpr>(src);
        }
    }
}