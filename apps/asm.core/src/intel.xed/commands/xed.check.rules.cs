//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            var rows = Xed.Rules.Tables.CalcTableRows(RuleTableKind.Enc);
            var count = rows.Count;
            Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];

            var kind = rows.First.TableKind;
            var name = rows.First.TableName;
            var sig = XedRules.sig(kind,name);
            var length = 0u;
            var offset = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var row = ref rows[i];

                if(i == count - 1)
                    RuleTableRow.RenderWidths(sig, slice(rows.View,offset,length), widths);
                else if(row.TableName != name)
                {
                    if(row.TableName != name)
                    {
                        RuleTableRow.RenderWidths(sig, slice(rows.View,offset,length), widths);
                        kind = row.TableKind;
                        name = row.TableName;
                        sig = XedRules.sig(kind,name);
                        length = 0;
                        offset = i;
                    }
                    length++;
                }
            }

            TableEmit(rows.View, widths, AppDb.XedTable<RuleTableRow>("rules.tables", kind.ToString().ToLower()));

            return true;
        }

        void EmitConsolidated(Index<RuleTableRow> rows)
        {
            var count = rows.Count;
            Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];

            var kind = rows.First.TableKind;
            var name = rows.First.TableName;
            var sig = XedRules.sig(kind,name);
            var length = 0u;
            var offset = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var row = ref rows[i];

                if(i == count - 1)
                    RuleTableRow.RenderWidths(sig, slice(rows.View,offset,length), widths);
                else if(row.TableName != name)
                {
                    if(row.TableName != name)
                    {
                        RuleTableRow.RenderWidths(sig, slice(rows.View,offset,length), widths);
                        kind = row.TableKind;
                        name = row.TableName;
                        sig = XedRules.sig(kind,name);
                        length = 0;
                        offset = i;
                    }
                    length++;
                }
            }

            TableEmit(rows.View, widths, AppDb.XedTable<RuleTableRow>("rules.tables", kind.ToString().ToLower()));
        }
    }
}