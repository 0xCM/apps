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
        Index<PatternInfo> CalcPatternInfo(Index<InstPattern> src)
        {
            var parser = XedOpCodeParser.create();
            var count = src.Count;
            var dst = alloc<PatternInfo>(count);
            for(var i=0; i<count;i++)
                seek(dst,i) = parser.Parse(src[i]);
            return dst.Sort();
        }
    }
}