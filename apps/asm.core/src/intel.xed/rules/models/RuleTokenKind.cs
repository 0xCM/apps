//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum RuleTokenKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("0x{0}")]
            HexLit,

            [Symbol("0b{0}")]
            BinLit,

            [Symbol("{0}")]
            DecLit,

            [Symbol("macro<{0}>()")]
            Macro,

            [Symbol("{0}()")]
            Nonterm,

            [Symbol("{0}[{1}]")]
            FieldSeg,

            [Symbol("{0}{1}{2}")]
            Constraint,
        }
    }
}