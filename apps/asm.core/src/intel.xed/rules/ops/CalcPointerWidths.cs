//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
       Index<PointerWidthInfo> CalcPointerWidths()
            => Data(nameof(CalcPointerWidths), () => mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i)));
    }
}