//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedPatterns;
    using static XedModels;
    using static core;
    using static XedOperands;

    public partial class XedRuntime : AppService<XedRuntime>
    {
        bool Started = false;

        object StartLocker = new();

        public bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.get().PllExec();
        }

        public IAllocProvider Allocator => _Alloc;

        public WsProjects Projects => Service(Wf.WsProjects);

        public new XedPaths Paths => Service(Wf.XedPaths);

        public IntelXed Main => Service(() => Wf.IntelXed().With(this));

        public XedDocs Docs => Service(() => Wf.XedDocs().With(this));

        public XedDb XedDb => Service(() => Wf.XedDb().With(this));

        public XedRules Rules => Service(() => Wf.XedRules().With(this));

        public XedDisasmSvc XedDisasm => Service(() => Wf.XedDisasm().With(this));

        public AppDb AppDb => Service(Wf.AppDb);

        public AppServices AppServices => Service(Wf.AppServices);

        ConcurrentDictionary<uint,IMachine> Machines = new();

        public bool Machine(uint id, out IMachine dst)
            => Machines.TryGetValue(id, out dst);

        public IMachine Machine()
        {
            var m =  machine(Rules);
            Machines.TryAdd(m.Id,m);
            return m;
        }


        Alloc _Alloc;

        XedViews _Views;


        public ref readonly XedViews Views
        {
            [MethodImpl(Inline)]
            get => ref _Views;
        }

        public XedRuntime()
        {
            _Alloc = Alloc.allocate();
            _Views = new(this);
        }

        void RunCalcs()
        {
            var patterns = Rules.CalcPatterns();
            var rules = Rules.CalcRuleTables();
            exec(PllExec,
                () => rules = Rules.CalcRuleTables(),
                () => patterns = Rules.CalcPatterns()
                );

            Views.Store(XedViewIndex.InstPattern, () => patterns);
            Views.Store(XedViewIndex.RuleTables, () => rules);

            var datasets = RuleTables.datasets(rules);
            Views.Store(XedViewIndex.CellDatasets, () => datasets);

            var tables = CellTables.from(datasets);
            Views.Store(XedViewIndex.CellTables, () => tables);

            Index<RuleExpr> expr = sys.empty<RuleExpr>();
            Index<InstFieldRow> fields = sys.empty<InstFieldRow>();
            exec(PllExec,
                () => fields = Rules.CalcInstFields(patterns)
            );

            exec(PllExec, () => expr = Rules.CalcRuleExpr(tables));

            Views.Store(XedViewIndex.InstFields, () => fields);
            Views.Store(XedViewIndex.RuleExpr, () => expr);

            Started = true;
        }

        [MethodImpl(Inline)]
        public void Start()
        {
            lock(StartLocker)
            {
                if(!Started)
                    RunCalcs();
            }
        }

        protected override void Disposing()
        {
            _Alloc?.Dispose();
        }

        public void EmitCatalog()
        {
            Paths.Targets().Delete();
            var tables = Views.RuleTables;
            var patterns = Views.Patterns;
            Emit(XedFields.Defs.Positioned);
            exec(PllExec,
                () => Main.EmitChipMap(),
                () => Main.ImportForms(),
                () => EmitRegmaps(),
                () => EmitBroadcastDefs(),
                () => Rules.EmitCatalog(patterns, tables)
                );

        // Rules.CalcRuleCells(RuleTables)

            EmitInstPages(patterns);
            EmitDocs();
            XedDb.EmitArtifacts();
        }

        void EmitDocs()
            => Docs.Emit();

        void EmitInstPages(Index<InstPattern> src)
        {
            src.Sort();
            var formatter = InstPageFormatter.create();
            Paths.InstPageRoot().Delete();
            iter(formatter.GroupFormats(src), x =>  Emit(x), PllExec);
        }

        void Emit(in InstIsaFormat src)
        {
            var dst = Paths.InstPagePath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }

        void EmitBroadcastDefs()
            => TableEmit(XedOperands.Views.BroadcastDefs, BroadcastDef.RenderWidths, Paths.Table<BroadcastDef>());

        void Emit(ReadOnlySpan<FieldDef> src)
            => TableEmit(src, FieldDef.RenderWidths, Paths.Table<FieldDef>());

        void EmitRegmaps()
        {
            TableEmit(XedRegMap.Service.REntries, RegMapEntry.RenderWidths, Paths.Table<RegMapEntry>("rmap"));
            TableEmit(XedRegMap.Service.XEntries, RegMapEntry.RenderWidths, Paths.Table<RegMapEntry>("xmap"));
        }
    }
}