//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;

    partial class XedRules
    {
        public Index<XedOpCode> CalcOpCodes(Index<InstPattern> src)
            => Data(nameof(CalcOpCodes), () => src.Map(x => x.PatternSpec.OpCode).Sort());
    }
}