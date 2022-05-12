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
            => AppSvc.TableEmit(Xed.Views.TypeTableRows, Paths.DbTable<TypeTableRow>());
    }
}