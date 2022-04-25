//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.RuleCellKind;

    partial class XedRules
    {
        public enum LayoutCellKind : byte
        {
            None,

            BL = K.BitLiteral,

            XL = K.HexLiteral,

            SV = K.SegVar,

            SF = K.SegField,

            NT = K.NontermCall,
        }

        public readonly record struct LayoutCell
        {
            readonly InstField Source;

            [MethodImpl(Inline)]
            public LayoutCell(InstField src)
            {
                Source = src;
            }

            public LayoutCellKind Kind
            {
                [MethodImpl(Inline)]
                get => Source.CellKind == K.InstSeg ? LayoutCellKind.SF : (LayoutCellKind)Source.CellKind;
            }

            public string Format()
                => Source.Format();

            public override string ToString()
                => Format();
        }
    }
}