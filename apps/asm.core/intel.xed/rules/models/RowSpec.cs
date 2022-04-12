//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RowSpec
        {
            public readonly Index<CellSpec> Antecedant;

            public readonly Index<CellSpec> Consequent;

            [MethodImpl(Inline)]
            public RowSpec(CellSpec[] p, CellSpec[] c)
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

            public static RowSpec Empty => new RowSpec(sys.empty<CellSpec>(), sys.empty<CellSpec>());
        }
    }
}