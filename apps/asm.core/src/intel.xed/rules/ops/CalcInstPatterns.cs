//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<InstPattern> CalcInstPatterns()
            => CalcInstPatterns(CalcInstDefs());

        Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
        {
            var dst = bag<InstPattern>();
            iter(defs, def => calc(def, dst), true);
            var data = dst.ToArray().Sort();
            return Data(nameof(CalcInstPatterns), () => data);
        }

        static void calc(in InstDef def, ConcurrentBag<InstPattern> dst)
        {
            var specs = def.PatternSpecs;
            var buffer = list<PatternOpDetail>();
            for(var j=0; j<specs.Count; j++)
            {
                ref readonly var spec = ref specs[j];
                buffer.Clear();
                ref readonly var ops = ref spec.OpSpecs;
                for(byte k=0; k<ops.Count; k++)
                    buffer.Add(detail(spec,k));
                dst.Add(new InstPattern(def, spec, buffer.ToArray()));
            }
        }
    }
}