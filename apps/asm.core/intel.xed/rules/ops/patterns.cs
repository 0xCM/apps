//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

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
                    seek(dst,k) = pattern(ref specs[j]);
            }
            return dst.Sort();
        }

        public static InstPattern pattern(ref InstPatternSpec spec)
        {
            var fields = XedFields.sort(spec.Body.Fields);
            var usage = XedFields.usage(fields);
            spec.Body = new (fields);
            return new InstPattern(spec, usage);
        }
    }
}