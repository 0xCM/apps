//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("xed")]
    public enum XedDocKind : byte
    {
        EncInstDef,

        DecInstDef,

        EncRuleTable,

        DecRulePatterns,

        DecRuleTable,

        EncRulePatterns,

        EncDecRuleTable,

        Widths,

        PointerWidths,

        Fields,

        FormData,

        ChipData,

        OpCodeKinds,

        OpCodes,

        OperandEncoding,

        OperandDecoding
    }

}