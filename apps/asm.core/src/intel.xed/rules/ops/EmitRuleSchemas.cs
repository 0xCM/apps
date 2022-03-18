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
        public void EmitRuleSchemas()
            => EmitRuleSchemas(PllExec);

        Index<RuleSchema> CalcRuleSchemas(ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> src)
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

        ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> CalcRuleSchemas(bool pll)
        {
            var dst = cdict<RuleSig,Index<RuleCellSpec>>();
            exec(pll,
                () => CaclRuleSchemas(RuleTableKind.Enc,dst),
                () => CaclRuleSchemas(RuleTableKind.Dec,dst),
                () => CaclRuleSchemas(RuleTableKind.EncDec,dst)
            );
            return dst;
        }

        void CaclRuleSchemas(RuleTableKind kind, ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> dst)
        {
            var tables = RuleTables.CalcTableDefs(kind);
            var sigs = tables.Keys;
            for(var i=0; i<sigs.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                var table = tables[sig];
                var rows = XedRules.rows(table).Data;
                var count = rows.Count;
                var pFields = hashset<RuleCellSpec>();
                var cFields = hashset<RuleCellSpec>();
                for(var j=0; j<count; j++)
                {
                    ref readonly var row = ref rows[j];
                    row.FieldSpecs('P', pFields);
                    row.FieldSpecs('C', cFields);
                }

                var fields = list<RuleCellSpec>();
                fields.AddRange(pFields);
                fields.AddRange(cFields);
                dst[sig] = fields.ToArray().Sort();
            }
        }

        void EmitRuleSchemas(bool pll)
            => TableEmit(CalcRuleSchemas(CalcRuleSchemas(pll)).View, RuleSchema.RenderWidths, AppDb.XedPath("rules.tables", "xed.rules.schemas", FileKind.Csv));
    }
}