//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedModels;

    partial class XedRules
    {
        void EmitFlagEffects(Index<InstDef> src)
        {
            const string RenderPattern = "{0,-16} | {1,-4} | {2, -4}";
            var path = XedPaths.Targets() + FS.file("xed.inst.flags", FS.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            writer.AppendLineFormat(RenderPattern, "Instruction",  "F", "E");
            var counter = 0u;

            for(var i=0; i<src.Count; i++)
            {
                ref readonly var def = ref src[i];
                ref readonly var specs = ref def.PatternSpecs;
                for(var j=0; j<specs.Count; j++)
                {
                    ref readonly var spec = ref specs[j];
                    ref readonly var effects = ref spec.Effects;
                    for(var k=0; k<effects.Count; k++)
                    {
                        var e = effects[k];
                        writer.AppendLineFormat(RenderPattern,
                            XedRender.format(spec.InstClass),
                            e.Flag.ToString().ToLower(),
                            XedRender.format(e.Effect)
                            );
                        counter++;
                    }
                }

            }
            EmittedFile(emitting,counter);
        }
    }
}