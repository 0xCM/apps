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
        public static Index<RuleSchema> CalcSchemas(ConcurrentDictionary<RuleTableKind,Index<RuleTable>> src)
        {
            var dst = bag<RuleSchema>();
            iter(src[RuleTableKind.Enc], table => CalcSchema(table,dst), AppData.PllExec());
            iter(src[RuleTableKind.Dec], table => CalcSchema(table,dst), AppData.PllExec());

            var schema = dst.Array().Sort();
            for(var i=0u; i<schema.Length; i++)
                seek(schema,i).Seq = i;
            return schema;
        }

        static void CalcSchema(in RuleTable src, ConcurrentBag<RuleSchema> buffer)
        {
            ref readonly var sig = ref src.Sig;
            var path = XedPaths.Service.TableDef(sig);
            var cellix = XedRules.cells(src);
            for(var i=0; i<cellix.Count; i++)
            {
                ref readonly var cells = ref cellix[i];
                for(var j=0; j<cells.Count; j++)
                {
                    var cell = cells[j];
                    var dst = new RuleSchema();
                    dst.TableKind = src.TableKind;
                    dst.TableName = src.Sig.ShortName;
                    dst.Logic = cell.IsPremise ? 'P' : 'C';
                    dst.Index = cell.Index;
                    dst.Field = cell.Criterion.Field;
                    dst.DataKind = cell.Criterion.DataKind;
                    dst.TableDef = path;
                    buffer.Add(dst);
                }
            }
        }
    }
}