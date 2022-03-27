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
        XedPaths XedPaths => Service(Wf.XedPaths);

        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        public Index<RuleSeq> CalcRuleSeq()
            => XedParsers.ruleseq(XedPaths.DocSource(XedDocKind.RuleSeq));

        public Index<RuleTableSpec> CalcRuleSpecs(RuleTableKind kind)
            => Data(string.Format("{0}/{1}", nameof(CalcRuleSpecs), kind), () => CalcTableSpecs(XedPaths.RuleSource(kind)));

        public Index<RuleTable> CalcTableDefs(RuleTableKind kind)
            => Data(string.Format("{0}/{1}", nameof(CalcTableDefs), kind), () => XedRules.reify(CalcRuleSpecs(kind)));

        public void EmitTables()
        {
            XedPaths.RuleTargets().Clear();
            var cells = cdict<RuleSig,Index<RuleCellSpec>>();
            exec(PllExec,
                () => EmitTables(RuleTableKind.Enc, cells),
                () => EmitTables(RuleTableKind.Dec, cells),
                () => EmitTables(RuleTableKind.EncDec, cells),
                EmitRuleSeq
                );

            var sigrows = CalcSigRows(cells.Keys.Array().Sort());
            exec(PllExec,
                () => EmitRuleSigs(sigrows),
                () => EmitSchemas(CalcSchemas(cells))
            );
        }

        public RuleTableSet CalcTableSet()
        {
            var tables = new RuleTableSet();
            var buffers = tables.CreateBuffers();
            exec(PllExec,
                () => CalcDefCells(RuleTableKind.Enc),
                () => CalcDefCells(RuleTableKind.Dec),
                () => CalcDefCells(RuleTableKind.EncDec)
                );

            exec(PllExec,
                () => buffers.Sigs = CalcSigRows(buffers.Cells.Keys.Array().Sort()),
                () => buffers.Schema = CalcSchemas(buffers.Cells)
                );

            return tables.Seal(buffers);

            void CalcDefCells(RuleTableKind kind)
            {
                var defs = CalcTableDefs(kind);
                buffers.Defs.TryAdd(kind, defs);
                iter(defs, def => buffers.Rows.TryAdd(def.Sig, CalcTableCells(def, buffers.Cells)), PllExec);
            }
        }

        void EmitRuleSeq()
        {
            var src = CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitRuleSigs(Index<RuleSigRow> src)
            => TableEmit(src.View, RuleSigRow.RenderWidths, XedPaths.RuleTable<RuleSigRow>());

        Index<RuleTableRow> CalcTableCells(in RuleTable def, ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> cells)
        {
            var rows = XedRules.rows(def);
            CalcCells(def, rows, cells);
            return rows;
        }

        Index<RuleTableRow> EmitTables(RuleTableKind kind, ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> cells)
        {
            var buffer = bag<RuleTableRow>();
            var defs = CalcTableDefs(kind);
            void EmitDef(RuleTable def)
            {
                if(def.IsNonEmpty)
                {
                    var rows = CalcTableCells(def, cells);
                    iter(rows, row => buffer.Add(row));
                    if(rows.Count != 0)
                        EmitTableDef(def, rows);
                }
            }

            iter(defs, EmitDef, PllExec);
            var rows = buffer.Array().Sort();
            EmitConsolidated(kind, rows);
            return rows;
        }

        Index<RuleSigRow> CalcSigRows(ReadOnlySpan<RuleSig> src)
        {
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

        static void CalcCells(in RuleTable table, Index<RuleTableRow> rows, ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> dst)
        {
            var count = rows.Count;
            var pFields = hashset<RuleCellSpec>();
            var cFields = hashset<RuleCellSpec>();
            for(var j=0; j<count; j++)
            {
                ref readonly var row = ref rows[j];
                XedRules.specs(row, 'P',pFields);
                XedRules.specs(row, 'C',cFields);
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
                        tsig = XedRules.sig(kind, name);
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
                        tsig = XedRules.sig(kind,name);
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

        static Index<RuleTableSpec> CalcTableSpecs(FS.FilePath src)
        {
            using var reader = src.Utf8LineReader();
            var counter = 0u;
            var dst = list<RuleTableSpec>();
            var tkind = XedPaths.tablekind(src.FileName);
            var statements =list<StatementSpec>();
            var name = EmptyString;
            while(reader.Next(out var line))
            {
                if(XedRules.RuleForm(line.Content) == RuleFormKind.SeqDecl)
                {
                    while(reader.Next(out line))
                        if(line.IsEmpty)
                            break;
                    continue;
                }

                var content = text.trim(text.despace(line.Content));
                if(text.empty(content) || text.begins(content, Chars.Hash))
                    continue;

                var k = text.index(content,Chars.Hash);
                if(k > 0)
                    content = text.trim(text.left(content,k));

                if(text.ends(content, "()::"))
                {
                    if(counter != 0)
                    {
                        if(!Skip.Contains(name))
                            dst.Add(new (XedRules.sig(tkind, name), statements.ToArray()));

                        statements.Clear();
                    }

                    name = text.remove(content,"()::");
                    var i = text.index(name, Chars.Space);
                    if(i > 0)
                        name = text.right(name,i);
                    counter++;
                }
                else
                {
                    if(XedRules.parse(content, out StatementSpec s))
                        statements.Add(s);
                }
            }

            return dst.ToArray().Sort();
        }

        static HashSet<string> Skip;

        static XedRuleTables()
        {
            Skip = hashset("VEXED_REX", "XED_RESET");
        }
   }
}