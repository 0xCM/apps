//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static MemDb;

    partial class XedDb
    {
        public void EmitTypeTables()
        {
            var formatter = RecordFormatter.create(typeof(TypeTableRow));
            var rows = Rules.CalcTypeTables().SelectMany(x => x.Rows).Sort().Resequence();
            AppServices.TableEmit(rows, Paths.DbTable<TypeTableRow>());
        }
    }
}