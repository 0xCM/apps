//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    using static Bitfields;

    partial class XTend
    {
        public static PolyBits PolyBits(this IWfRuntime wf)
            => Z0.PolyBits.create(wf);
    }


    public partial class PolyBits : AppService<PolyBits>
    {
        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Service(Wf.AppDb);

        public void RunChecks()
        {
            BitCheckers.run();
            var dst = text.emitter();
            CheckBitConverters();
            GenBitfield(dst);
        }

        public Index<BitPattern> CalcBitPatterns()
            => new BitPattern[]{
                pattern(origin<ModRm>(), ModRm.PatternSpec),
                pattern(origin<RexPrefix>(), RexPrefix.PatternSpec),
                pattern(origin<Sib>(), Sib.PatternSpec),
                pattern(origin<VexPrefixC4>(), VexPrefixC4.PatternSpec),
                pattern(origin<VexPrefixC5>(),VexPrefixC5.PatternSpec),
            };

        public void EmitBitPatters()
            => Emit(CalcBitPatterns());

        public void Emit(ReadOnlySpan<BitPattern> src)
        {
            var dst = text.emitter();
            for(var i=0u; i<src.Length; i++)
                describe(skip(src,i), i, dst);

            AppSvc.FileEmit(dst.Emit(), 12, AppDb.Targets("polybits").Path("bitpatterns",FileKind.Txt));
        }

        static void render(ReadOnlySpan<BitfieldSegModel> src, ITextEmitter dst, bool header = true)
        {
            var formatter = Tables.formatter<BitfieldSegModel>();
            if(header)
                dst.AppendLine(formatter.FormatHeader());
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(formatter.Format(skip(src,i)));
        }

        static void describe(BitPattern src, uint seq, ITextEmitter dst)
        {
            const string RenderPattern = "{0,-12} | {1}";
            dst.WriteLine();
            dst.AppendLineFormat(RenderPattern, "BitPattern", seq.ToString("D2"));
            dst.WriteLine(RP.PageBreak120);
            dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.Origin), src.Origin);
            dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.Name), src.Name);
            dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.Content), src.Content);
            dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.DataWidth), src.DataWidth);
            dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.MinSize), src.MinSize);
            dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.DataType), src.DataType.DisplayName());
            dst.AppendLineFormat(RenderPattern,  nameof(BitPattern.Descriptor), src.Descriptor);
            dst.AppendLineFormat(RenderPattern, "Segments", EmptyString);
            dst.AppendLine(RP.PageBreak120);
            render(src.Segments, dst);
        }


        static void GenBitfield(ITextEmitter dst)
        {
            var seq = 0u;
            var modrm = pattern(origin<ModRm>(), ModRm.PatternSpec);
            describe(modrm, seq++, dst);

            var rex = pattern(origin<RexPrefix>(), RexPrefix.PatternSpec);
            describe(rex, seq++, dst);

            var vexC4 = pattern(origin<VexPrefixC4>(), VexPrefixC4.PatternSpec);
            describe(vexC4, seq++, dst);

            var vexC5 = pattern(origin<VexPrefixC5>(),VexPrefixC5.PatternSpec);
            describe(vexC5, seq++, dst);

            var sib = pattern(origin<Sib>(), Sib.PatternSpec);
            describe(sib, seq++, dst);

            byte data = 0b10_110_011;
            var bs = bitstring(sib, data);
        }

        void CheckBitConverters()
        {
            var n = n8;
            var count = num.count(n);
            var convert = BitConverters.converter(n);
            for(var i=0; i<count; i++)
            {
                ref readonly var hex = ref convert.Chars(base16, (ushort)i);
                ref readonly var bin = ref convert.Chars(base2, (ushort)i);
                Write(string.Format("{0,-3} | {1,-3} | {2,-3}", i, hex, bin));
            }

            var checks = Classifiers.Checks(Wf);
            checks.Run();
        }


        public Index<BitfieldModel> BvEmit(DbSources sources, string filter, FS.FolderPath dst)
            => BvEmit(BvCalc(sources.Files(FileKind.Csv).Where(f => f.FileName.StartsWith(filter))), dst);

        public Index<BitfieldModel> BvCalc(FS.Files lists)
            => bvmodels(lists);

        public Index<BitfieldModel> BvEmit(Index<BitfieldModel> src, FS.FolderPath dst)
        {
            dst.Clear();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var bv = ref src[i];
                ref readonly var name = ref bv.Name;
                var target = dst + FS.file(name, FS.ext("bv"));
                var msg = string.Format("{0} -> {1}", bv.Origin, target.ToUri());
                AppSvc.FileEmit(bv, msg, target);
            }
            return src;
        }
    }
}