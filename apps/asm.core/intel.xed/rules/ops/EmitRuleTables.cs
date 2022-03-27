//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public void EmitRuleTables()
        {
            XedPaths.Service.RuleTargets().Clear();
            var cells = cdict<RuleSig,Index<RuleCellSpec>>();
            exec(PllExec,
                () => EmitTables(RuleTableKind.Enc, cells),
                () => EmitTables(RuleTableKind.Dec, cells),
                () => EmitTables(RuleTableKind.EncDec, cells),
                EmitRuleSeq
                );

            var sigrows = XedRules.CalcSigRows(cells.Keys.Array().Sort());
            exec(PllExec,
                () => EmitRuleSigs(sigrows),
                () => EmitSchemas(XedRules.CalcSchemas(cells))
            );
        }

        void EmitRuleSeq()
        {
            var src = XedRules.CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitRuleSigs(Index<RuleSigRow> src)
            => TableEmit(src.View, RuleSigRow.RenderWidths, XedPaths.Service.RuleTable<RuleSigRow>());

        Index<RuleTableRow> EmitTables(RuleTableKind kind, ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> cells)
        {
            var buffer = bag<RuleTableRow>();
            var defs = XedRules.CalcTableDefs(kind);
            void EmitDef(RuleTable def)
            {
                if(def.IsNonEmpty)
                {
                    var rows = XedRules.CalcCells(def, cells);
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

        void EmitSchemas(Index<RuleSchema> src)
            => TableEmit(src.View, RuleSchema.RenderWidths, XedPaths.Service.RuleSchemas());

        void EmitTableDef(in RuleTable table, Index<RuleTableRow> src)
        {
            ref readonly var sig = ref table.Sig;
            Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];
            CalcRenderWidths(sig, src, widths);
            var path = XedPaths.Service.TableDef(sig);
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
                    CalcRenderWidths(tsig, slice(src.View,offset,length), widths);
                else if(row.TableName != name)
                {
                    if(row.TableName != name)
                    {
                        CalcRenderWidths(tsig, slice(src.View,offset,length), widths);
                        kind = row.TableKind;
                        name = row.TableName;
                        tsig = XedRules.sig(kind,name);
                        length = 0;
                        offset = i;
                    }
                    length++;
                }
            }

            TableEmit(src.View, widths, XedPaths.Service.TableDef(kind));
        }

        static void CalcRenderWidths(RuleSig sig, ReadOnlySpan<RuleTableRow> data, Span<byte> dst)
        {
            seek(dst, 0) = 12;
            if(skip(dst,1) != 0)
                seek(dst, 1) = max((byte)(sig.Name.Length + 1), skip(dst,1));
            else
                seek(dst, 1) = max((byte)(sig.Name.Length + 1), (byte)12);
            seek(dst, 2) = 12;
            CalcRenderWidths(data, dst);
        }

        static void CalcRenderWidths(ReadOnlySpan<RuleTableRow> src, Span<byte> dst)
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

    }
}