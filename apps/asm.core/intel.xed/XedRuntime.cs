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
    using I = XedViewIndex;

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

        static RuleTables CalcRuleTables()
        {
            var dst = new RuleTables();
            var buffers = dst.CreateBuffers();
            var pll = AppData.get().PllExec();
            exec(pll,
                () => buffers.Criteria.TryAdd(RuleTableKind.ENC, RuleSpecs.criteria(RuleTableKind.ENC)),
                () => buffers.Criteria.TryAdd(RuleTableKind.DEC, RuleSpecs.criteria(RuleTableKind.DEC))
                );

            dst.Seal(buffers, pll);
            return dst;
        }

        void RunCalcs()
        {
            Views.Store(I.InstDefs,InstDefParser.parse(Paths.DocSource(XedDocKind.EncInstDef)));

            exec(PllExec,
                () => Views.Store(I.RuleTables, CalcRuleTables()),
                () => Views.Store(I.InstPattern, InstPattern.load(Views.InstDefs))
                );

            Views.Store(I.CellDatasets, RuleTables.datasets(Views.RuleTables));
            Views.Store(I.CellTables, CellTables.from(Views.CellDatasets));
            Views.Store(I.RuleExpr, Rules.CalcRuleExpr(Views.CellTables));
            Views.Store(I.InstFields, XedPatterns.fieldrows(Views.Patterns));
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