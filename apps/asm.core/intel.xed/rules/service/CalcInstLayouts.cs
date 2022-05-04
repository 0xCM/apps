//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public Index<InstLayoutRecord> CalcInstLayouts(Index<InstPattern> src)
            => Data(nameof(CalcInstLayouts), () => LayoutCalcs.records(src));
    }
}