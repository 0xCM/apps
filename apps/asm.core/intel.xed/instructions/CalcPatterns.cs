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
        public Index<InstPattern> CalcPatterns(Index<InstDef> defs, bool pll = true)
        {
            var dst = bag<InstPattern>();
            iter(defs, def => CalcPatterns(def, dst), pll);
            return dst.ToArray().Sort();
        }

        void CalcPatterns(in InstDef def, ConcurrentBag<InstPattern> dst)
        {
            var specs = def.PatternSpecs;
            var buffer = list<PatternOp>();
            for(var j=0; j<specs.Count; j++)
            {
                ref readonly var spec = ref specs[j];
                var parser = OpSpecParser.create(OpWidthsLookup, spec.Body);
                buffer.Clear();
                for(byte k=0; k<spec.Ops.Count; k++)
                    buffer.Add(parser.ParseOperand(spec,k));
                dst.Add(new InstPattern(def, spec, buffer.ToArray()));
            }
        }
    }
}