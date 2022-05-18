//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static BfDatasets;

    partial class PolyBits
    {
        public void PatternEmit()
        {
            var type = typeof(AsmBitPatterns);
            var prefix = "asm";
            var patterns = BfDatasets.patterns(type);
            EmitDescriptions(patterns, prefix + ".bits.patterns.info");
            EmitRecords(patterns, prefix);
        }

        void EmitDescriptions(ReadOnlySpan<BpInfo> src, string name)
        {
            var dst = text.emitter();
            for(var i=0u; i<src.Length; i++)
                PbRender.render(skip(src,i), i, dst);
            AppSvc.FileEmit(dst.Emit(), 12, Targets.Path(name, FileKind.Txt));
        }

        void EmitRecords(Index<BpInfo> patterns, string prefix)
        {
            var count = patterns.Count;
            var specs = alloc<BpSpec>(count);
            var segs = BfDatasets.segs(patterns);
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var def = ref pattern.Def;
                seek(specs,i) = pattern.Spec;
            }

            AppSvc.TableEmit(segs, Targets.Table<BpSeg>(prefix));
            AppSvc.TableEmit(specs, Targets.Table<BpSpec>(prefix));
        }
    }
}