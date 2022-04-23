//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static Datasets;
    using static core;

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

        [CmdOp("xed/check/seq")]
        Outcome ChecSeq(CmdArgs args)
        {
            var assets = AsmCaseAssets.create();
            var header = assets.XedFileHeader().Utf8();
            var path = FS.path(@"J:\z0\apps\asm.core\intel.xed\rules\models\RuleName.cs");
            var rules = Xed.Rules.CalcRules();
            ref readonly var specs = ref rules.Specs();

            var rulenames = specs.Keys.Select(x => x.TableName.ToString()).ToHashSet();
            //var nonterms = Symbols.index<NontermKind>().Kinds.Where(x => x != 0).Select(x => XedRender.format(x));
            //rulenames.AddRange(nonterms);
            var names = rulenames.Index().Sort();

            var dst = text.emitter();
            dst.WriteLine(header);
            dst.WriteLine("namespace Z0");
            dst.WriteLine("{");
            var indent = 4u;

            dst.IndentLine(indent,"partial class XedRules");
            dst.IndentLine(indent,"{");
            indent+=4;
            dst.IndentLine(indent,"public enum RuleName : ushort");
            dst.IndentLine(indent,"{");
            var k=0u;
            indent += 4;
            dst.IndentLineFormat(indent, "{0} = {1},", "None", k++);
            dst.WriteLine();
            for(var i=0; i<names.Count; i++, k++)
            {
                ref readonly var name = ref names[i];
                dst.IndentLineFormat(indent, "{0} = {1},", name, k);
                if(i != names.Count-1)
                    dst.WriteLine();
            }
            indent -= 4;
            dst.IndentLine(indent,"}");
            indent -=4;
            dst.IndentLine(indent,"}");
            indent -=4;
            dst.Indent(indent,"}");
            using var writer = path.Utf8Emitter();
            writer.Write(dst.Emit());

            //var nonterms = XedSeq.Defs().SelectMany(x => x.Steps).Select(x => x.Data).Distinct().Select(x => XedRender.format(x.Kind));

            // var seq = XedSeq.Defs();
            // for(var i=0; i<seq.Count; i++)
            // {
            //     ref readonly var def = ref seq[i];
            //     Write(def.Format());
            // }
            return true;
        }


        string CaclTableMetrics(RuleSig sig, Index<KeyedCell> src)
        {
            var view = src.View;
            var tid = src.IsNonEmpty ? src.First.Key.TableId : Hex12.MaxValue;
            var rix = z16;
            var rowExpr = text.emitter();
            var dst = text.emitter();
            var count = src.Count;
            dst.AppendLine(string.Format("{0:D3} {1,-32} {2}", tid,  sig.Format(), XedPaths.CheckedTableDef(sig)));
            dst.AppendLine(RP.PageBreak120);
            dst.AppendLine();
            var emit = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref src[i];
                ref readonly var key = ref cell.Key;
                emit = key.RowIndex != rix;
                if(key.RowIndex != rix)
                    rix = key.RowIndex;

                if(emit)
                {
                    dst.AppendLine(rowExpr.Emit());
                    dst.AppendLine();

                    dst.AppendLineFormat("{0:D3} {1:D3}", tid, rix);
                    dst.AppendLine(RP.PageBreak60);
                }

                var descriptor = string.Format("{0:D3} {1:D3} {2:D3} {3}", tid, rix, key.CellIndex, key.FormatSemantic());
                dst.AppendLineFormat("{0} {1,-12} | {2}", descriptor, XedRender.format(cell.Field), cell);
                rowExpr.Append(cell.Format());
                rowExpr.Append(Chars.Space);


                if(i == count - 1 )
                    dst.AppendLine(rowExpr.Emit());

            }
            return dst.Emit();
        }

        void CalcRuleMetrics(KeyedCells src)
        {
            var sigs = src.Keys;
            var dst = text.emitter();
            for(var i=0; i<sigs.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                var table = src[sig];
                dst.AppendLine(CaclTableMetrics(sig,table));
            }

            FileEmit(dst.Emit(), sigs.Length, XedPaths.RuleTargets() + FS.file("xed.rules.metrics", FS.Txt));
        }

        [CmdOp("xed/emit/metrics")]
        Outcome EmitMetrics(CmdArgs args)
        {
            CalcRuleMetrics(Rules.CalcRuleCells(CalcRules()));
            return true;
        }

        [CmdOp("xed/emit/types")]
        Outcome EmitSchema(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            var src = rules.Criteria();
            var paths = dict<RuleSig,FS.FileUri>();
            var left = dict<RuleSig,HashSet<CellType>>();
            var right = dict<RuleSig,HashSet<CellType>>();
            var sigs = hashset<RuleSig>();

            // for(var i=0; i<src.Count; i++)
            // {
            //     ref readonly var table = ref src[i];
            //     ref readonly var sig = ref table.Sig;
            //     sigs.Add(sig);

            //     var path = XedPaths.CheckedTableDef(sig);
            //     if(path.IsEmpty)
            //         continue;

            //     paths[sig] = path;
            //     left[sig] = new();
            //     right[sig] = new();
            //     for(var j=0; j<table.RowCount; j++)
            //     {
            //         ref readonly var row = ref table[j];

            //         for(var k=0; k<row.Antecedant.Count; k++)
            //         {
            //             ref readonly var logic = ref row.Antecedant[k];
            //             left[sig].Add(logic.Type);
            //         }

            //         for(var k=0; k<row.Consequent.Count; k++)
            //         {
            //             ref readonly var logic = ref row.Consequent[k];
            //             right[sig].Add(logic.Type);
            //         }
            //     }
            // }

            var dst = text.emitter();
            var sorted = sigs.Index().Sort();
            var types = hashset<CellType>();

            for(var i=0; i<sorted.Count; i++)
            {
                dst.AppendLine(RP.PageBreak120);
                ref readonly var sig = ref sorted[i];
                paths.TryGetValue(sig, out var path);
                if(path.IsNonEmpty)
                    dst.AppendLineFormat("{0,-3} | {1,-16} | {2}", sig.TableKind, sig.TableName, path);
                else
                    dst.AppendLineFormat("{0,-3} | {1,-16} | {2}", sig.TableKind, sig.TableName, "Undefined");

                if(left.TryGetValue(sig, out types))
                {
                    render(types.Index().Sort(), LogicKind.Antecedant, dst);
                }
                if(right.TryGetValue(sig, out types))
                {
                    render(types.Index().Sort(), LogicKind.Consequent, dst);
                }
            }

            FileEmit(dst.Emit(), sorted.Count, XedPaths.Targets() + FS.folder("rules.tables") + FS.file("xed.rules.tables.schemas", FS.Txt));
            return true;
        }

        static void render(in CellType type, uint i, LogicKind lk, ITextEmitter dst)
        {
            dst.AppendLine(string.Format("{0,-3} | {1,-16} | {2,-8} | {3,-12} | {4,-4} | {5}",
                i,
                (char)lk,
                type.Kind,
                type.DomainTypeName,
                type.EffectiveWidth,
                XedRender.format(type.Field))
                );
        }

        static void render(Index<CellType> src, LogicKind lk, ITextEmitter dst)
        {
            for(var i=0u; i<src.Count; i++)
                render(src[i],i,lk,dst);
        }

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
                seek(dst,j++) = string.Format("{0,20} | {1}", string.Format("{0} {1}", op.Index, op.Name), XedRender.format(op.Attribs));
            }
            return j;
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
}