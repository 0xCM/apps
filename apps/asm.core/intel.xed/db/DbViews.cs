//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedGrids;
    using static MemDb;

    partial class XedDb
    {
        public readonly struct DbViews
        {
            readonly XedDb Db;

            [MethodImpl(Inline)]
            public DbViews(XedDb src)
            {
                Db = src;
            }

            public ReadOnlySpan<LocatedField> LocatedFields
                => Db.CalcLocatedFields(Db.RuleCells);

            public ReadOnlySpan<RuleGrid> Grids
                => Db.CalcGrids(Db.RuleCells);

            public ref readonly Index<TypeTable> TypeTables
            {
                [MethodImpl(Inline)]
                get => ref Db.Services.Objects.TypeTables;
            }
        }
    }
}