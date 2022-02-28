//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum RuleDocKind : byte
        {
            [Symbol("all-enc-instructions")]
            EncInstDef,

            [Symbol("all-dec-instructions")]
            DecInstDef,

            [Symbol("all-enc-patterns")]
            EncRuleTable,

            [Symbol("all-dec-patterns")]
            DecRuleTable,

            [Symbol("all-enc-dec-patterns")]
            EncDecRuleTable,

            [Symbol("all-widths")]
            Widths,

            [Symbol("all-pointer-names")]
            PointerWidths,

            RulePatterns,

            OpCodePatterns,

            OpCodes,

            OperandEncoding,

            OperandDecoding
        }
    }
}