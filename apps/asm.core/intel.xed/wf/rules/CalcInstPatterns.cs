//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        public Index<InstPattern> CalcInstPatterns()
            => CalcInstPatterns(CalcInstDefs());

        Index<InstDef> CalcInstDefs()
            => Data(nameof(InstDef), () => InstDefParser.parse(XedPaths.DocSource(XedDocKind.EncInstDef)));

        Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
            => Data(nameof(InstPattern), () => patterns(defs));

    }
}