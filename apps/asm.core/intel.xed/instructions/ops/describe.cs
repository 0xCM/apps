//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedPatterns
    {
        public static Index<InstPatternRecord> describe(Index<InstPattern> src, bool pll = true)
        {
            var count = src.Count;
            var dst = bag<InstPatternRecord>();
            iter(src, p => dst.Add(describe(p)), pll);
            return dst.Array().Sort(PatternSort.comparer());
        }

        public static InstPatternRecord describe(in InstPattern src)
        {
            ref readonly var body = ref src.Body;
            var dst = InstPatternRecord.Empty;
            var opcode = XedPatterns.xedoc(body.Fields);
            dst.PatternId = src.PatternId;
            dst.InstId = src.InstId;
            dst.Mode = src.Mode;
            dst.OcKind = src.OpCode.Kind;
            dst.OcValue = src.OpCode.Value;
            dst.InstClass = src.InstClass;
            dst.InstForm = src.InstForm;
            dst.Body = body;
            return dst;
        }
    }
}