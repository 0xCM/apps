//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        public static Index<InstPattern> patterns(Index<InstDef> defs)
        {
            var count = 0u;
            iter(defs, def => count += def.PatternSpecs.Count);
            var dst = alloc<InstPattern>(count);
            var k=0u;
            for(var i=0; i<defs.Count; i++)
            {
                ref readonly var def = ref defs[i];
                var specs = def.PatternSpecs;
                for(var j=0; j<specs.Count; j++, k++)
                {
                    //seek(dst,k) =  new InstPattern(specs[j]);
                    seek(dst,k) = InstPattern.define(ref specs[j]);
                }
            }
            return dst.Sort();
        }
    }
}