//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public Index<InstOpCode> CalcPoc(Index<InstPattern> src)
            => Data(nameof(CalcPoc), () => XedOpCodes.poc(src));
    }
}