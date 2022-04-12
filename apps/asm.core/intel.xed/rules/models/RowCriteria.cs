//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RowCriteria
        {
            public readonly Index<CellSpec> Antecedant;

            public readonly Index<CellSpec> Consequent;

            [MethodImpl(Inline)]
            public RowCriteria(CellSpec[] p, CellSpec[] c)
            {
                Antecedant = p;
                Consequent = c;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Antecedant.Count == 0 && Consequent.Count == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RowCriteria Empty => new RowCriteria(sys.empty<CellSpec>(), sys.empty<CellSpec>());
        }
    }
}