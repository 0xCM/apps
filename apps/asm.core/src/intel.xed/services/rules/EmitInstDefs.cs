//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        FS.FilePath EmitInstDefs(ReadOnlySpan<InstDef> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0u; i<src.Length; i++)
            {
                ref readonly var def = ref skip(src,i);
                if(def.PatternOps.IsEmpty)
                    continue;

                writer.WriteLine(RP.PageBreak120);
                writer.WriteLine(string.Format("{0}:{1}", "Seq", i));
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Class), def.Class));
                if(def.Form.IsNonEmpty)
                    writer.WriteLine(string.Format("{0}:{1}", nameof(def.Form), def.Form));
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Category), def.Category));
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Extension), def.Extension));
                if(def.Isa != 0)
                    writer.WriteLine(string.Format("{0}:{1}", nameof(def.Isa), def.Isa));
                if(def.Attributes.IsNonEmpty)
                    writer.WriteLine(string.Format("{0}:{1}", nameof(def.Attributes), def.Attributes.Delimit(fence:RenderFence.Embraced)));
                if(def.Flags.IsNonEmpty)
                    writer.WriteLine(string.Format("{0}:{1}", nameof(def.Flags), def.Flags.Delimit(fence:RenderFence.Embraced)));
                iter(def.PatternOps, p => {
                    writer.WriteLine(string.Format("{0}:{1}", "Pattern", p.Expr));
                    if(p.Operands.Count != 0)
                        iter(p.Operands, o => writer.WriteLine(o));
                });
                writer.WriteLine();
            }
            EmittedFile(emitting,src.Length);
            return dst;
        }
    }
}