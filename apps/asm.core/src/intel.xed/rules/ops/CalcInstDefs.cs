//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public Index<InstDef> CalcEncInstDefs()
            => CalcInstDefs(XedPaths.DocSource(XedDocKind.EncInstDef));

        public Index<InstDef> CalcDecInstDefs()
            => CalcInstDefs(XedPaths.DocSource(XedDocKind.DecInstDef));

        Index<InstDef> CalcInstDefs(FS.FilePath src)
            => InstDefParser.ParseInstDefs(src);
    }
}