//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;
    using static XedModels;

    partial class XedPatterns
    {
        static uint IsaOutCount;

        static FS.FolderName instfolder(InstIsa isa)
        {
            var name = isa.Format();
            var dst =  isa.IsEmpty ? FS.folder("OTHER") : FS.folder(name);
            switch(isa.Kind)
            {
                case IsaKind.AVX_GFNI:
                case IsaKind.AVX_VNNI:
                    dst = FS.folder(string.Format("AVX512/{0}", name));
                break;
                case IsaKind.ADOX_ADCX:
                case IsaKind.AMX_BF16:
                case IsaKind.AMX_INT8:
                case IsaKind.AMX_TILE:
                case IsaKind.AMD:
                case IsaKind.CLDEMOTE:
                case IsaKind.CLZERO:
                case IsaKind.CLWB:
                case IsaKind.CLFSH:
                case IsaKind.CLFLUSHOPT:
                case IsaKind.F16C:
                case IsaKind.FXSAVE:
                case IsaKind.FXSAVE64:
                case IsaKind.HRESET:
                case IsaKind.INVPCID:
                case IsaKind.LAHF:
                case IsaKind.LZCNT:
                case IsaKind.MONITOR:
                case IsaKind.MONITORX:
                case IsaKind.PCLMULQDQ:
                case IsaKind.PKU:
                case IsaKind.POPCNT:
                case IsaKind.PTWRITE:
                case IsaKind.PREFETCH_NOP:
                case IsaKind.PREFETCHWT1:
                case IsaKind.RDPMC:
                case IsaKind.RDRAND:
                case IsaKind.RDSEED:
                case IsaKind.SGX:
                case IsaKind.SGX_ENCLV:
                case IsaKind.VMFUNC:
                    dst = FS.folder(string.Format("OTHER/{0}", name));
                break;
                default:
                if(text.begins(name,"AVX512"))
                    dst = FS.folder(string.Format("AVX512/{0}", name));
                break;
            }

            return dst;
        }

        public void EmitIsaPages(Index<InstPattern> src)
        {
            var lookup = src.GroupBy(x => x.Isa.Kind).Map(x => (x.Key, x.ToArray())).ToConcurrentDictionary();
            var outdir = XedPaths.Targets() + FS.folder("instructions");
            outdir.Delete();
            iter(lookup.Keys, isa => EmitDescriptions(lookup[isa], outdir + instfolder(isa)),PllExec);
        }

        void RenderIsaOp(in PatternOpInfo src, ITextBuffer dst)
        {
            var type = EmptyString;
            var width = EmptyString;
            if(src.CellType.IsNonEmpty)
                type = src.CellType.Format();
            if(empty(type) && src.NonTerminal.IsNonEmpty)
                type = src.NonTerminal.Format();

            if(src.RegLit.IsNonEmpty)
                type = src.RegLit.Format();
            if(src.BitWidth.IsNonEmpty)
                width = string.Format("w{0}", src.BitWidth);
            if(empty(width))
                width = src.OpWidth.Format();

            var desc = EmptyString;
            if(empty(type))
                desc = width;
            else
                desc = nonempty(width) ? string.Format("{0}/{1}", width, type) : type;

            dst.AppendLineFormat("{0} {1,-8} {2,-8} {3,-8} {4}", src.Index, src.Name, src.Kind, XedRender.semantic(src.Action), desc);
        }

        void RenderIsaTitle(InstPattern src, ITextBuffer dst)
        {
            var classifier = src.Classifier;
            ref readonly var cateogory = ref src.Category;
            ref readonly var isa = ref src.Isa;
            dst.AppendLineFormat("{0,-18} {1,-12} {2,-12}", classifier, src.Isa.Name, src.Category);
            dst.AppendLine(RP.PageBreak80);
        }

        void RenderIsaInfo(InstPattern src, ITextBuffer dst)
        {
            dst.AppendLineFormat("{0} {1}", XedRender.semantic(src.OpCode), src.InstForm);
        }

        void EmitDescriptions(Index<InstPattern> patterns, FS.FolderPath outdir)
        {
            var outpath = FS.FilePath.Empty;
            var classifier = EmptyString;
            var buffer = text.buffer();
            var opsLU = XedRules.CalcOpRecords(patterns).GroupBy(x => x.PatternId).Map(x => (x.Key,x.ToArray())).ToConcurrentDictionary();

            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];

                if(pattern.Classifier != classifier)
                {
                    if(i!=0)
                    {
                        using var writer = outpath.AsciWriter();

                        writer.Write(buffer.Emit());
                        var c = inc(ref IsaOutCount);
                        if(c % 100 == 0)
                            Status(string.Format("Emitted {0} instructions", c));
                    }
                    classifier = pattern.Classifier;
                    outpath = outdir + FS.file(pattern.Classifier, FS.Txt);
                    RenderIsaTitle(pattern,buffer);
                }
                else
                {
                    buffer.AppendLine(RP.PageBreak80);
                }

                RenderIsaInfo(pattern,buffer);
                var ops = sys.empty<PatternOpInfo>();
                if(opsLU.TryGetValue(pattern.PatternId, out ops))
                {
                    for(var j=0; j<ops.Length; j++)
                        RenderIsaOp(skip(ops,j), buffer);
                }

                if(i==patterns.Count - 1)
                {
                    using var writer = outpath.AsciWriter();
                    writer.Write(buffer.Emit());
                }
            }
        }
    }
}