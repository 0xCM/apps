//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    [ApiHost]
    public partial class XedOperands
    {
        static XedPaths XedPaths => XedPaths.Service;

        static Index<OpWidthInfo> _Widths;

        static ConstLookup<OpWidthCode,OpWidthInfo> _WidthLookup;

        static XedOperands()
        {
            _Widths = CalcOpWidths();
            _WidthLookup = _Widths.Select(x => (x.Code,x)).ToDictionary();
        }

        public readonly partial struct Edit
        {

        }
    }
}