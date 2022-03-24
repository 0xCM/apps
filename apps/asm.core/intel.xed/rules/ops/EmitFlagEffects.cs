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
            var log = hashset<IClass>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var def = ref src[i];
                if(def.FlagEffects.Count != 0)
                {
                    if(log.Contains(def.InstClass))
                        continue;

                    log.Add(def.InstClass);
                    for(var j=0; j<def.FlagEffects.Count; j++)
                    {
                        var e = def.FlagEffects[j];
                        writer.AppendLineFormat(RenderPattern,
                            XedRender.format(def.InstClass),
                            e.Flag.ToString().ToLower(),
                            XedRender.format(e.Effect)
                            );
                    }

                    counter++;

                }
            }
            EmittedFile(emitting,counter);
        }
    }
}