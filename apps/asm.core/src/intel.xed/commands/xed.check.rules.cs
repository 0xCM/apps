//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Asm;
    using static core;
    using static XedRules;
    using static XedPatterns;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            var traverser = XedPatterns.traverser(Wf);
            traverser.Traverse();
            var patterns = traverser.Patterns();
            var defs = traverser.Defs();
            var oplookup = traverser.Ops().GroupBy(x => x.PatternId).Select(x => (x.Key, (Index<OpSpec>)x.ToArray())).ToDictionary();
            var count = patterns.Count;
            var missing = list<InstPatternSpec>();
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var body = ref pattern.Body;
                if(!oplookup.TryGetValue(pattern.PatternId, out _))
                    Require.invariant(pattern.Ops.Count == 0);
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                }
            }

            EmitEffects(defs);
            return true;
        }

        void EmitEffects(Index<InstDef> src)
        {
            var path = XedPaths.Targets() + FS.file("xed.inst.flags", FS.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            writer.WriteLine(RFlags.RenderPattern, RFlags.FlagNames);
            var buffer = text.buffer();
            var counter = 0u;
            //var flags = Symbols.kinds<RFlagBits>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var def = ref src[i];
                ref readonly var effects = ref def.FlagEffects;
                var count = effects.Count;
                if(count != 0)
                {
                    RFlagBits bits = RFlagBits.None;
                    for(var j=0; j<count; j++)
                    {
                        FlagEffect effect = effects[j];
                        bits |= effect.Flag;
                    }



                    writer.WriteLine(buffer.Emit());

                    counter++;

                }
            }
            EmittedFile(emitting,counter);
        }
    }
}