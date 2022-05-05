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
        /// <summary>
        /// Classifies a <see cref='LayoutCell'/>
        /// </summary>
        public enum LayoutCellKind : byte
        {
            [Symbol("", "The tragic unknown")]
            None,

            /// <summary>
            ///  Specifies a <see cref='K.BitLiteral'/> kind
            /// </summary>
            [Symbol("BL", "Specifies a Bit literal")]
            BL = K.BitLiteral,

            /// <summary>
            ///  Specifies a <see cref='K.HexLiteral'/> kind
            /// </summary>
            [Symbol("XL", "Specifies a Hex literal")]
            XL = K.HexLiteral,

            /// <summary>
            ///  Specifies a <see cref='K.SegVar'/> kind
            /// </summary>
            [Symbol("SV", "Specifies a SegVar")]
            SV = K.SegVar,

            /// <summary>
            ///  Specifies a <see cref='K.FieldSeg'/> kind
            /// </summary>
            [Symbol("FS", "Specifies a FieldSeg")]
            FS = K.FieldSeg,

            /// <summary>
            ///  Specifies a <see cref='K.NontermCall'/> kind
            /// </summary>
            [Symbol("NT", "Specifies a NontermCall")]
            NT = K.NontermCall,
        }
    }
}