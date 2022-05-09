//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    public class XedViews
    {
        [MethodImpl(Inline)]
        public ref readonly T Load<T>(XedViewIndex index)
            => ref core.@as<object,T>(DataStores[(byte)index]);

        [MethodImpl(Inline)]
        internal void Store<T>(XedViewIndex index, Func<T> f)
            => core.@as<object,T>(DataStores[(byte)index]) = f();

        readonly Index<object> DataStores;

        readonly XedRuntime Xed;

        internal XedViews(XedRuntime xed)
        {
            Xed = xed;
            DataStores =  alloc<object>(32);
        }

        public ref readonly Index<InstPattern> Patterns
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstPattern>>(XedViewIndex.InstPattern);
        }

        public ref readonly RuleTables RuleTables
        {
            [MethodImpl(Inline)]
            get => ref Load<RuleTables>(XedViewIndex.RuleTables);
        }

        public ref readonly Index<InstFieldRow> InstFields
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstFieldRow>>(XedViewIndex.InstFields);
        }

        public ref readonly CellTables CellTables
        {
            [MethodImpl(Inline)]
            get => ref Load<CellTables>(XedViewIndex.CellTables);
        }

        public ref readonly Index<RuleExpr> RuleExpr
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<RuleExpr>>(XedViewIndex.RuleExpr);
        }

        public ref readonly CellDatasets CellDatasets
        {
            [MethodImpl(Inline)]
            get => ref Load<CellDatasets>(XedViewIndex.CellDatasets);
        }

    }
}