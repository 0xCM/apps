//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public Index<InstPattern> CalcInstPatterns()
            => CalcInstPatterns(CalcInstDefs());

        Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
            => Data(nameof(InstPattern), () => InstPattern.load(defs));
    }
}