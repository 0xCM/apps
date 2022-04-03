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
        // void EmitTableDefs(Index<RuleTableRow> src, FS.FilePath dst)
        // {
        //     var count = src.Count;
        //     Span<byte> widths = stackalloc byte[RuleTableRow.ColCount];
        //     var name = EmptyString;
        //     var sig = RuleSig.Empty;
        //     var length = 0u;
        //     var offset = 0u;
        //     for(var i=0u; i<count; i++)
        //     {
        //         ref readonly var row = ref src[i];
        //         if(empty(name))
        //         {
        //             if(nonempty(row.TableName))
        //             {
        //                 name = row.TableName;
        //                 sig = XedRules.sig(row.Kind, name);
        //             }
        //         }

        //         if(empty(name))
        //             continue;

        //         if(i == count - 1)
        //             CalcRenderWidths(sig, slice(src.View,offset,length), widths);
        //         else if(row.TableName != name)
        //         {
        //             if(row.TableName != name)
        //             {
        //                 CalcRenderWidths(sig, slice(src.View,offset,length), widths);
        //                 name = row.TableName;
        //                 sig = XedRules.sig(row.Kind, name);
        //                 length = 0;
        //                 offset = i;
        //             }
        //             length++;
        //         }
        //     }

        //     TableEmit(src.View, widths, dst);
        // }

        void EmitTableDefs(RuleTables rules)
        {
            var sigs = rules.Sigs();
            var tables = rules.Tables();
            var buffer = text.buffer();
            var counter = 0u;
            var seq = 0u;
            buffer.AppendLineFormat("{0,-8} | {1,-8} | {2,-8} | {3,-32} | {4}", "Seq", "TableId",  "Kind", "Name", "Expression");
            for(var i=0u; i<tables.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                var table = rules.Table(sig);
                var src = XedRules.cells(table);
                var cols = src.Storage.Select(x => x.Count).Max();
                var grid = alloc<string[]>(src.Count);
                for(var j=0; j<src.Count; j++)
                {
                    var premise = true;
                    var cells = alloc<string>(src[j].Count + 1);
                    var ck=0;
                    for(var k=0; k<src[j].Count; k++)
                    {
                        var cell = src[j][k];

                        if(!cell.IsPremise)
                        {
                            if(premise)
                            {
                                premise  = false;
                                seek(cells,ck++) = "=>";
                            }
                        }

                        seek(cells,ck++) = cell.Format();

                        counter++;
                    }
                    seek(grid,j) = cells;
                }

                for(var j=0; j<grid.Length; j++)
                {
                    buffer.AppendFormat("{0,-8} | ", seq++);
                    buffer.AppendFormat("{0,-8} | ", i);
                    buffer.AppendFormat("{0,-8} | ", table.TableKind);
                    buffer.AppendFormat("{0,-32} | ", table.Sig.ShortName);
                    buffer.Append(skip(grid,j).Join(Chars.Space));
                    buffer.AppendLine();
                }
            }

            FileEmit(buffer.Emit(), counter, XedPaths.Targets("rules.tables") + FS.file("xed.rules.tables", FS.Csv), TextEncodingKind.Asci);
        }

        // static void CalcRenderWidths(in RuleSig sig, ReadOnlySpan<RuleTableRow> data, Span<byte> dst)
        // {
        //     const byte SeqIndex = 0;
        //     const byte NameIndex = 1;
        //     const byte KindIndex = 2;
        //     const byte RowIndex = 3;

        //     seek(dst, SeqIndex) = 8;
        //     seek(dst, KindIndex) = 8;
        //     if(skip(dst,NameIndex) != 0)
        //         seek(dst, NameIndex) = max((byte)(sig.ShortName.Length + 1), skip(dst,NameIndex));
        //     else
        //         seek(dst, NameIndex) = max((byte)(sig.ShortName.Length + 1), (byte)12);
        //     seek(dst, RowIndex) = 8;
        //     CalcRenderWidths(data, dst);
        // }

        // static void CalcRenderWidths(ReadOnlySpan<RuleTableRow> src, Span<byte> dst)
        // {
        //     const byte Offset = RuleTableRow.LeadCount;
        //     const byte FieldCount = RuleTableRow.ColCount;

        //     for(var i=Offset; i<FieldCount; i++)
        //         seek(dst,i) = max((byte)10, skip(dst,i));

        //     var count = src.Length;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var row = ref skip(src,i);
        //         for(byte j=0,k=Offset; j<FieldCount; j++, k++)
        //         {
        //             var cell = row[j];
        //             var width = cell.Format().Length;
        //             if(width > skip(dst,k))
        //                 seek(dst,k) = (byte)width;
        //         }
        //     }
        // }
    }
}