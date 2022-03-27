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
        void EmitTableDefs(RuleTableKind kind, RuleTableSet tables)
            => EmitTableDefs(tables.Rows(kind), XedPaths.Service.TableDef(kind));

        void EmitTableDefs(Index<RuleTableRow> src, FS.FilePath dst)
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
                        tsig = XedRules.sig(row.TableKind, name);
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
                        tsig = XedRules.sig(row.TableKind,name);
                        length = 0;
                        offset = i;
                    }
                    length++;
                }
            }

            TableEmit(src.View, widths, dst);
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