//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedImport
    {
        static void lookup(out ConstLookup<OpWidthCode,OpWidthRecord> dst)
            => dst = _OpWidths.Select(x => (x.Code,x)).ToDictionary();
    }
}