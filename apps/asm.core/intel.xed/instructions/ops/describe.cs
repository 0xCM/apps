//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedPatterns
    {
        public static Index<InstPatternInfo> describe(Index<InstPattern> src, bool pll = true)
        {
            var count = src.Count;
            var dst = bag<InstPatternInfo>();
            iter(src, p => dst.Add(describe(p.PatternSpec)), pll);
            return dst.Array().Sort();
        }

        public static InstPatternInfo describe(InstPatternSpec src)
        {
            ref readonly var body = ref src.Body;
            var dst = InstPatternInfo.Empty;
            var opcode = XedPatterns.xedoc(src.PatternId, body);
            dst.PatternId = src.PatternId;
            dst.InstId = src.InstId;
            dst.Mode = src.Mode;
            dst.OpCode = opcode;
            dst.Class = src.Class;
            dst.Form = src.Form;
            dst.Body = XedRender.format(body);
            return dst;
        }
    }
}