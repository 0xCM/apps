//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        public static Index<InstPatternInfo> describe(Index<InstDef> src, bool pll = true)
        {
            var dst = bag<InstPatternInfo>();
            iter(src, def => describe(def,dst), pll);
            return dst.ToArray().Sort();
        }

        public static Index<InstPatternInfo> describe(Index<InstPattern> src, bool pll = true)
        {
            var parser = XedOpCodeParser.create();
            var count = src.Count;
            var dst = bag<InstPatternInfo>();
            iter(src, p => dst.Add(describe(p)), pll);
            return dst.Array().Sort();
        }

        static void describe(in InstDef def, ConcurrentBag<InstPatternInfo> dst)
        {
            var specs = def.PatternSpecs;
            for(var j=0; j<specs.Count; j++)
                dst.Add(describe(specs[j]));
        }

        public static InstPatternInfo describe(InstPattern src)
        {
            ref readonly var body = ref src.Body;
            var dst = InstPatternInfo.Empty;
            var opcode = XedOpCodeParser.create().Parse(src);
            dst.PatternId = src.PatternId;
            dst.InstId = src.InstId;
            dst.OcIndex = ocindex(opcode.Kind);
            dst.Class = src.Class;
            dst.OpCode = opcode.Value;
            dst.Body = XedRender.format(body);
            return dst;
        }

        public static InstPatternInfo describe(InstPatternSpec src)
        {
            ref readonly var body = ref src.Body;
            var dst = InstPatternInfo.Empty;
            var opcode = XedOpCodeParser.create().Parse(src);
            dst.PatternId = src.PatternId;
            dst.InstId = src.InstId;
            dst.OcIndex = ocindex(opcode.Kind);
            dst.Class = src.Class;
            dst.OpCode = opcode.Value;
            dst.Body = XedRender.format(body);
            return dst;
        }
    }
}