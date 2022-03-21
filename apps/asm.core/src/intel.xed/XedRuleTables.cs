//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    public partial class XedRuleTables : AppService<XedRuleTables>
    {
        const NumericKind Closure = UnsignedInts;

        XedPaths XedPaths => Service(Wf.XedPaths);

        AppDb AppDb => Service(Wf.AppDb);

        bool PllExec = true;

        ConcurrentSet<RuleSig> TableSigs {get;} = new();

        public void EmitTables(bool pll)
        {
            PllExec = pll;
            XedPaths.RuleTargets().Clear();
            TableSigs.Clear();
            exec(PllExec,
                EmitTables,
                EmitRuleSeq
                );
            EmitRuleSigs();
        }

        public Index<RuleSeq> CalcRuleSeq()
            => XedParsers.ruleseq(XedPaths.DocSource(XedDocKind.RuleSeq));

        void EmitRuleSeq()
        {
            var src = CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitRuleSigs()
            => TableEmit(CalcSigRows().View, RuleSigRow.RenderWidths, XedPaths.RuleTable<RuleSigRow>());

        public Index<RuleTableSpec> CalcRuleSpecs(RuleTableKind kind)
            => specs(XedPaths.RuleSource(kind));

        public Index<RuleSigRow> CalcSigRows()
        {
            var src = TableSigs.Members.Array().Sort();
            var count = src.Length;
            var dst = alloc<RuleSigRow>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var sig = ref skip(src,i);
                ref var row = ref seek(dst,i);
                row.Seq = i;
                row.TableKind = sig.TableKind;
                row.TableName = sig.Name;
                row.TableDef = XedPaths.TableDef(sig).ToUri();
            }
            return dst;
        }

        void EmitTables()
        {
            var cells = cdict<RuleSig,Index<RuleCellSpec>>();
            exec(PllExec,
                () => EmitTables(RuleTableKind.Enc, cells),
                () => EmitTables(RuleTableKind.Dec, cells),
                () => EmitTables(RuleTableKind.EncDec, cells)
                );

            EmitSchemas(CalcSchemas(cells));
        }

        void EmitTables(RuleTableKind kind, ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> cells)
        {
            var buffer = bag<RuleTableRow>();
            var defs = reify(CalcRuleSpecs(kind));

            void EmitDefs()
            {
                iter(defs, EmitDef, PllExec);
            }

            void EmitDef(RuleTable def)
            {
                if(def.IsNonEmpty)
                {
                    var _rows = rows(def);
                    if(_rows.Count !=0)
                    {
                        if(TableSigs.Add(def.Sig))
                        {
                            CalcCells(def, _rows, cells);
                            EmitTableDef(def, _rows);
                            for(var i=0; i<_rows.Count; i++)
                                buffer.Add(_rows[i]);
                        }
                        else
                            Warn(string.Format("Duplicate table:{0}", def.Sig));
                    }
                }
            }

            EmitDefs();
            EmitConsolidated(kind, buffer.Array().Sort());
        }

        Index<RuleSchema> CalcSchemas(ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> src)
        {
            var sigs = src.Keys.Array().Sort();
            var count = src.Values.Map(x => x.Count).Sum();
            var buffer = alloc<RuleSchema>(count);
            var k=0u;
            for(var i=0u; i<sigs.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                var td = XedPaths.TableDef(sig).ToUri();
                var cells = src[sig];
                for(byte j=0; j<cells.Count; j++, k++)
                {
                    ref readonly var cell = ref cells[j];
                    ref var dst = ref seek(buffer,k);
                    dst.Seq = k;
                    dst.ColKind = cell.Premise ? 'P' : 'C';
                    dst.DataKind = cell.DataKind;
                    dst.Field = cell.Field;
                    dst.Index = j;
                    dst.TableDef = td;
                    dst.TableKind = cell.TableKind;
                    dst.TableName = sig.Name;
                }
            }
            return buffer;
        }

        void CalcCells(in RuleTable table, Index<RuleTableRow> rows, ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> dst)
        {
            var count = rows.Count;
            var pFields = hashset<RuleCellSpec>();
            var cFields = hashset<RuleCellSpec>();
            for(var j=0; j<count; j++)
            {
                ref readonly var row = ref rows[j];
                specs(row, 'P',pFields);
                specs(row, 'C',cFields);
            }

            var fields = list<RuleCellSpec>();
            fields.AddRange(pFields);
            fields.AddRange(cFields);
            dst[table.Sig] = fields.ToArray().Sort();
        }

        void EmitSchemas(Index<RuleSchema> src)
            => TableEmit(src.View, RuleSchema.RenderWidths, XedPaths.RuleSchemas());

        void EmitTableDef(in RuleTable table, Index<RuleTableRow> src)
        {
            ref readonly var sig = ref table.Sig;
            Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];
            RenderWidths(sig, src, widths);
            var path = XedPaths.TableDef(sig);
            var formatter = Tables.formatter<RuleTableRow>(widths);
            using var writer = path.AsciWriter();
            writer.AppendLine(formatter.FormatHeader());
            var count = src.Count;
            for(var i=0; i<count; i++)
                writer.AppendLine(formatter.Format(src[i]));

            writer.AppendLine();

            var desc = table.Format().Lines(trim:false);
            for(var i=0; i<desc.Length; i++)
                writer.AppendLineFormat("# {0}", skip(desc,i).Content);
        }

        void EmitConsolidated(RuleTableKind kind, Index<RuleTableRow> src)
        {
            var count = src.Count;
            Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];

            var name = EmptyString;
            var tsig = RuleSig.Empty;
            var length = 0u;
            var offset = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var row = ref src[i];
                if(empty(name))
                {
                    if(nonempty(row.TableName))
                    {
                        name = row.TableName;
                        tsig = sig(kind, name);
                    }
                }

                if(empty(name))
                    continue;

                if(i == count - 1)
                    RenderWidths(tsig, slice(src.View,offset,length), widths);
                else if(row.TableName != name)
                {
                    if(row.TableName != name)
                    {
                        RenderWidths(tsig, slice(src.View,offset,length), widths);
                        kind = row.TableKind;
                        name = row.TableName;
                        tsig = sig(kind,name);
                        length = 0;
                        offset = i;
                    }
                    length++;
                }
            }

            TableEmit(src.View, widths, XedPaths.TableDef(kind));
        }

        static void RenderWidths(RuleSig sig, ReadOnlySpan<RuleTableRow> data, Span<byte> dst)
        {
            seek(dst, 0) = 12;
            if(skip(dst,1) != 0)
                seek(dst, 1) = max((byte)(sig.Name.Length + 1), skip(dst,1));
            else
                seek(dst, 1) = max((byte)(sig.Name.Length + 1), (byte)12);
            seek(dst, 2) = 12;
            RenderWidths(data, dst);
        }

        static void RenderWidths(ReadOnlySpan<RuleTableRow> src, Span<byte> dst)
        {
            const byte Offset = 3;
            const byte FieldCount = RuleTableRow.FieldCount;

            for(var i=Offset; i<FieldCount; i++)
                seek(dst,i) = max((byte)10, skip(dst,i));

            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(src,i);
                for(byte j=0,k=Offset; j<FieldCount; j++, k++)
                {
                    var cell = row[j];
                    var width = cell.Format().Length;
                    if(width > skip(dst,k))
                        seek(dst,k) = (byte)width;
                }
            }
        }

        static HashSet<string> Skip;

        static XedRuleTables()
        {
            Skip = hashset("VEXED_REX", "XED_RESET");
        }
   }
}