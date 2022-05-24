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
        public ConstLookup<OpWidthCode,OpWidthRecord> CalcOpWidthLookup(Index<OpWidthRecord> src)
            => src.Select(x => (x.Code,x)).ToDictionary();
    }
}