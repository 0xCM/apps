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
    using static XedImport;
    using I = XedViewKind;

    public partial class XedRuntime : AppService<XedRuntime>
    {
        bool Started = false;

        object StartLocker = new();

        public bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.get().PllExec();
        }

        public IAllocProvider Alloc => _Alloc;

        public WsProjects Projects => Wf.WsProjects();

        public new XedPaths Paths => XedPaths.Service;

        public XedDocs Docs => Wf.XedDocs(this);

        public XedDb XedDb => Wf.XedDb(this);

        public XedRules Rules => Wf.XedRules(this);

        public XedImport Import => Wf.XedImport(this);

        public AppDb AppDb => Wf.AppDb();

        public new WsCmdRunner CmdRunner => Wf.WsCmdRunner();

        AppSvcOps AppSvc => Wf.AppSvc();

        ConcurrentDictionary<uint,IMachine> Machines = new();

        public bool Machine(uint id, out IMachine dst)
            => Machines.TryGetValue(id, out dst);

        public IMachine Machine()
        {
            var m =  XedOperands.machine(this);
            Machines.TryAdd(m.Id,m);
            return m;
        }

        Alloc _Alloc;

        XedViews _Views;

        AsmCmdRt CmdRt;

        public ref readonly XedViews Views
        {
            [MethodImpl(Inline)]
            get => ref _Views;
        }

        protected override void Initialized()
        {
            _Views = new(this, Wf.AppSvc);
        }

        public XedRuntime()
        {
            _Alloc = Z0.Alloc.create();
        }

        void CalcCpuIdImports()
        {
            Import.CalcCpuIdImports(data => {
                Views.Store(I.CpuIdImport, data.CpuIdRecords);
                Views.Store(I.IsaImport, data.IsaRecords);
            });
        }

        static RuleTables CalcRuleTables()
        {
            var tables = new RuleTables();
            var dst = new RuleBuffers();
            exec(AppData.get().PllExec(),
                () => dst.Target.TryAdd(RuleTableKind.ENC, RuleSpecs.criteria(RuleTableKind.ENC)),
                () => dst.Target.TryAdd(RuleTableKind.DEC, RuleSpecs.criteria(RuleTableKind.DEC))
                );
            return XedRules.tables(dst);
        }

        void CalcTypeTables()
        {
            Views.Store(I.TypeTables, MemDb.typetables(Alloc, typeof(XedDb).Assembly,"xed"));
            Views.Store(I.TypeTableRows, MemDb.rows(Views.TypeTables));
        }

        void RunCalcs()
        {
            var defs = sys.empty<InstDef>();
            var blocks = InstImportBlocks.Empty;
            var forms = sys.empty<FormImport>();
            var chips = ChipMap.Empty;
            exec(PllExec,
                CalcTypeTables,
                CalcCpuIdImports,
                () => defs = InstDefParser.parse(Paths.DocSource(XedDocKind.EncInstDef)),
                //() => Views.Store(I.InstDefs, InstDefParser.parse(Paths.DocSource(XedDocKind.EncInstDef))),
                () => Views.Store(I.AsmBroadcastDefs, Import.CalcBroadcastDefs()),
                () => Views.Store(I.OpWidths, Import.CalcOpWidths()),
                () => Import.CalcInstImports(data => blocks = data),
                //() => Import.CalcInstImports(data => Views.Store(I.InstImports, data)),
                () => Import.CalcFormImports(data => forms = data),
                //() => Import.CalcFormImports(data => Views.Store(I.FormImports, data)),
                () => XedRules.CalcChipMap(data =>  chips = data)
                //() => XedRules.CalcChipMap(data =>  Views.Store(I.ChipMap, data))
                );

            Views.Store(I.InstDefs, defs);
            Views.Store(I.InstImports, blocks);
            Views.Store(I.FormImports, forms);
            Views.Store(I.ChipMap, chips);

            var tables = RuleTables.Empty;
            var patterns = sys.empty<InstPattern>();
            exec(PllExec,
                //() => Views.Store(I.RuleTables, CalcRuleTables()),
                () => tables = CalcRuleTables(),
                () => patterns = InstPattern.load(defs),
                //() => Views.Store(I.InstPattern, InstPattern.load(Views.InstDefs)),
                () => Views.Store(I.OpWidthLookup, Import.CalcOpWidthLookup(Views.OpWidths))
                );

            Views.Store(I.RuleTables, tables);
            Views.Store(I.InstPattern, patterns);

            exec(PllExec,
                () => Views.Store(I.OpCodes, XedOpCodes.poc(patterns)),
                () => Views.Store(I.InstFields, XedPatterns.fieldrows(patterns))
                );

            Views.Store(I.CellDatasets, RuleTables.datasets(tables));
            Views.Store(I.CellTables, CellTables.from(Views.CellDatasets));
            Views.Store(I.RuleExpr, Rules.CalcRuleExpr(Views.CellTables));
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

        public new bool Running
        {
            [MethodImpl(Inline)]
            get => Started;
        }

        protected override void Disposing()
        {
            _Alloc?.Dispose();
        }

        public void EmitCatalog()
        {
            Paths.Output().Delete();
            var tables = Views.RuleTables;
            var patterns = Views.Patterns;
            Emit(XedFields.Defs.Positioned);
            exec(PllExec,
                () => Import.Run(),
                () => EmitRegmaps(),
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
            iter(formatter.GroupFormats(src), x => Emit(x), PllExec);
        }

        void Emit(in InstIsaFormat src)
        {
            var dst = Paths.InstPagePath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }

        void Emit(ReadOnlySpan<FieldDef> src)
            => AppSvc.TableEmit(src, Paths.Table<FieldDef>());

        void EmitRegmaps()
        {
            AppSvc.TableEmit(XedRegMap.Service.REntries, Paths.Table<RegMapEntry>("rmap"));
            AppSvc.TableEmit(XedRegMap.Service.XEntries, Paths.Table<RegMapEntry>("xmap"));
        }
    }
}