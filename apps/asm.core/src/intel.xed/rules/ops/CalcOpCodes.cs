//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        public Index<XedOpCode> CalcOpCodes()
            => Data(nameof(CalcOpCodes), () => XedPatterns.opcodes(CalcInstPatterns()));
    }
}