//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static MemDb;
    using static core;

    public class XedViews
    {
        [MethodImpl(Inline)]
        public ref readonly T Load<T>(XedViewKind index)
            => ref core.@as<object,T>(DataStores[(byte)index]);

        // [MethodImpl(Inline)]
        // internal void Store<T>(XedViewKind index, Func<T> f)
        //     => core.@as<object,T>(DataStores[(byte)index]) = f();

        [MethodImpl(Inline)]
        internal void Store<T>(XedViewKind kind, T data)
        {
            core.@as<object,T>(DataStores[(byte)kind]) = data;
            AppSvc.Status(FlairKind.StatusData, $"Computed {kind}");
        }

        readonly Index<object> DataStores;

        readonly Func<AppServices> _AppSvc;

        readonly XedRuntime Xed;

        readonly AppServices AppSvc;

        internal XedViews(XedRuntime xed, Func<AppServices> svc)
        {
            _AppSvc = svc;
            //Status = status;
            AppSvc = svc();
            Xed = xed;
            DataStores =  alloc<object>(32);
        }

        public ref readonly Index<InstPattern> Patterns
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstPattern>>(XedViewKind.InstPattern);
        }

        public ref readonly RuleTables RuleTables
        {
            [MethodImpl(Inline)]
            get => ref Load<RuleTables>(XedViewKind.RuleTables);
        }

        public ref readonly Index<InstFieldRow> InstFields
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstFieldRow>>(XedViewKind.InstFields);
        }

        public ref readonly CellTables CellTables
        {
            [MethodImpl(Inline)]
            get => ref Load<CellTables>(XedViewKind.CellTables);
        }

        public ref readonly Index<RuleExpr> RuleExpr
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<RuleExpr>>(XedViewKind.RuleExpr);
        }

        public ref readonly CellDatasets CellDatasets
        {
            [MethodImpl(Inline)]
            get => ref Load<CellDatasets>(XedViewKind.CellDatasets);
        }

        public ref readonly Index<InstDef> InstDefs
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstDef>>(XedViewKind.InstDefs);
        }

        public ref readonly Index<InstOpCode> OpCodes
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstOpCode>>(XedViewKind.OpCodes);
        }

        public ref readonly Index<IsaImport> IsaImport
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<IsaImport>>(XedViewKind.IsaImport);
        }

        public ref readonly Index<CpuIdImport> CpuIdImport
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<CpuIdImport>>(XedViewKind.CpuIdImport);
        }

        public ref readonly Index<TypeTable> TypeTables
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<TypeTable>>(XedViewKind.TypeTables);
        }

        public ref readonly Index<TypeTableRow> TypeTableRows
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<TypeTableRow>>(XedViewKind.TypeTableRows);
        }
    }
}