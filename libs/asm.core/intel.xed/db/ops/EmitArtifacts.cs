//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static MemDb;

    partial class XedDb
    {
        public void EmitArtifacts()
        {
            exec(PllExec,
                EmitRuleSchema,
                () => AppSvc.TableEmit(Xed.Views.TypeTableRows, Paths.DbTable<TypeTableRow>()),
                EmitLayouts
            );
        }

        public void EmitRuleSchema()
        {
            exec(PllExec,
                () => EmitRuleMetrics(CellTables),
                () => EmitTableStats(CellTables),
                () => EmitGrids(CellTables)
                );
        }
    }
}