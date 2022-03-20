//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public Index<InstPattern> CalcInstPatterns()
            => CalcInstPatterns(CalcInstDefs());

        Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
            => Data(nameof(CalcInstPatterns), () => InstDefs.patterns(defs));
    }
}