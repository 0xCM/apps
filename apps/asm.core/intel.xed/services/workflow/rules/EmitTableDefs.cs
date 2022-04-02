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
        void EmitTableDefs(Index<RuleTableRow> src, FS.FilePath dst)
        {
            var count = src.Count;
            Span<byte> widths = stackalloc byte[RuleTableRow.ColCount];
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
                        tsig = XedRules.sig(row.Kind, name);
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
                        name = row.TableName;
                        tsig = XedRules.sig(row.Kind,name);
                        length = 0;
                        offset = i;
                    }
                    length++;
                }
            }

            TableEmit(src.View, widths, dst);
        }

        void EmitTableDefs(RuleTables tables)
            => EmitTableDefs(tables.Rows(), XedPaths.RuleTable<RuleTableRow>());

        static void CalcRenderWidths(RuleSig sig, ReadOnlySpan<RuleTableRow> data, Span<byte> dst)
        {
            const byte SeqIndex = 0;
            const byte NameIndex = 1;
            const byte KindIndex = 2;
            const byte RowIndex = 3;

            seek(dst, SeqIndex) = 8;
            seek(dst, KindIndex) = 8;
            if(skip(dst,NameIndex) != 0)
                seek(dst, NameIndex) = max((byte)(sig.Name.Length + 1), skip(dst,NameIndex));
            else
                seek(dst, NameIndex) = max((byte)(sig.Name.Length + 1), (byte)12);
            seek(dst, RowIndex) = 8;
            CalcRenderWidths(data, dst);
        }

        static void CalcRenderWidths(ReadOnlySpan<RuleTableRow> src, Span<byte> dst)
        {
            const byte Offset = RuleTableRow.LeadCount;
            const byte FieldCount = RuleTableRow.ColCount;

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