//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        void EmitTableDefs(RuleTables rules)
        {
            var sigs = rules.Sigs();
            var tables = rules.Tables();
            var buffer = text.buffer();
            var rows = rules.DefRows();
            buffer.AppendLine(TableDefRow.Header);
            for(var i=0; i<rows.Count; i++)
                render(rows[i],buffer);
            FileEmit(buffer.Emit(), rows.Count, XedPaths.TableDefs(), TextEncodingKind.Asci);
        }

        public static void render(in TableDefRow src, ITextBuffer dst)
        {
            dst.AppendFormat("{0,-8} | ", src.Seq);
            dst.AppendFormat("{0,-8} | ", src.TableId);
            dst.AppendFormat("{0,-8} | ", src.Index);
            dst.AppendFormat("{0,-8} | ", src.Sig.TableKind);
            dst.AppendFormat("{0,-32} | ", src.Sig.ShortName);
            dst.Append(src.Cells.Join(Chars.Space));
            dst.AppendLine();
        }
    }
}