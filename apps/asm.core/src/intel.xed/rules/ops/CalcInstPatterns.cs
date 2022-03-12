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

        public Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
        {
            var dst = bag<InstPattern>();
            iter(defs, def => CalcInstPatterns(def, dst), true);
            return dst.ToArray().Sort();
        }

        static void CalcInstPatterns(in InstDef def, ConcurrentBag<InstPattern> dst)
        {
            var patterns = def.PatternSpecs;
            for(var j=0; j<patterns.Count; j++)
                dst.Add(new InstPattern(def, patterns[j]));
        }
    }
}