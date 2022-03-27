//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedPatterns;
    using System.IO;
    using static core;
    using System.Linq;

    partial class XedCmdProvider
    {
        [MethodImpl(Inline)]
        public static bits<T> load<T>(T src)
            where T : unmanaged
                => src;

        [MethodImpl(Inline)]
        public static bits<T> load<T>(byte n, T src)
            where T : unmanaged
                => (n,src);

        [CmdOp("xed/check/bits")]
        Outcome CheckBits(CmdArgs args)
        {
            Span<char> buffer = stackalloc char[84];
            ulong input = 0xF0CCAADD33;
            uint n = 24;
            ulong match = 0b1010_1010_1101_1101_0011_0011;
            var output = BitRender.render4x4(Chars.Underscore, n,input,buffer);
            Write(string.Format("{0} | {1}",  "1010_1010_1101_1101_0011_0011", text.format(output)));

            return true;
        }

        static byte _format(InstPattern pattern, Span<string> dst)
        {
            ref readonly var ops = ref pattern.Ops;

            var j=z8;
            seek(dst,j++) = string.Format("{0,-20} | {1,-4} | {2}", pattern.InstClass.Name, pattern.Mode, pattern.BodyExpr);
            seek(dst,j++) = string.Format("{0,-20} | {1}", pattern.OpCode, pattern.InstForm);

            for(var i=0; i<ops.Count; i++)
            {
                ref readonly var op = ref ops[i];
                seek(dst,j++) = string.Format("{0,20} | {1}", string.Format("{0} {1}", op.Index, XedRender.format(op.Name)), XedRender.format(op.Attribs));
            }
            return j;
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

        [CmdOp("xed/check/patterns")]
        Outcome CheckPatterns(CmdArgs args)
        {


            return true;
        }

        static uint IsaOutCount;

        static FS.FolderName instfolder(InstIsa isa)
            => isa.IsNonEmpty ? FS.folder(isa.Format()) : FS.folder("other");

        void EmitIsaPages()
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var patternLU = patterns.GroupBy(x => x.Isa.Kind).Map(x => (x.Key, x.ToArray())).ToConcurrentDictionary();
            var outdir = AppDb.Logs() + FS.folder("xed.inst");
            outdir.Delete();
            iter(patternLU.Keys, isa => EmitDescriptions(patternLU[isa], outdir + instfolder(isa)),true);
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

        void CheckPatterns(N0 n)
        {
            var forms = Symbols.index<IFormType>().Kinds.Map(x => (x,x)).ToConcurrentDictionary();
            var blocks = cdict<uint,string[]>();
            var patterns = cdict<uint,InstPattern>();
            var traversals = XedPatterns.traversals()
                                        .WithPreHandler(PatternTraversal);

            XedPatterns.traverser(traversals).TraversePatterns(Xed.Rules.CalcInstPatterns());

            void PatternTraversal(InstPattern pattern)
            {
                Require.invariant(patterns.TryAdd(pattern.PatternId,pattern));
                ref readonly var ops = ref pattern.Ops;
                var dst = alloc<string>(2 + ops.Count);
                _format(pattern, dst);
                blocks.TryAdd(pattern.PatternId, dst);
                if(pattern.InstForm.IsNonEmpty)
                    forms.TryRemove(pattern.InstForm);
            }

            var path = AppDb.Api() + FS.file("xed.inst.patterns.opinfo", FS.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            var counter = 0u;

            var sorted = patterns.Values.Array().Sort();
            var opcode = XedOpCode.Empty;
            for(var i=0; i<sorted.Length; i++)
            {
                ref readonly var pattern = ref skip(sorted,i);
                if(pattern.OpCode != opcode)
                {
                    writer.WriteLine(RP.PageBreak120);
                    opcode = pattern.OpCode;
                }

                var lines = blocks[pattern.PatternId];
                for(var j=0; j<lines.Length; j++, counter++)
                    writer.WriteLine(skip(lines,j));
            }
            EmittedFile(emitting,counter);
            iter(forms.Values, f => Write(f.ToString()));

        }
    }

    partial class XTend
    {
        public static Index<T> Sort<T,C>(this Index<T> src, C comparer)
            where C : IComparer<T>
        {
            System.Array.Sort(src,comparer);
            return src;
        }
    }
}