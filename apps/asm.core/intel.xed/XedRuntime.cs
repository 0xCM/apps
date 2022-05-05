//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedOperands;
    using static core;

    public class XedRuntime : AppService<XedRuntime>
    {
        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        public IntelXed Main => Service(Wf.IntelXed);

        public XedDocs Docs => Service(Wf.XedDocs);

        public new XedPaths Paths => Service(Wf.XedPaths);

        public XedRules Rules => Service(Wf.XedRules);

        public XedDisasmSvc Disasm => Service(Wf.XedDisasm);

        ConcurrentDictionary<uint,IMachine> Machines = new();

        public IMachine Machine()
        {
            var m =  machine(Rules);
            Machines.TryAdd(m.Id,m);
            return m;
        }

        public bool Machine(uint id, out IMachine dst)
            => Machines.TryGetValue(id, out dst);

        public new XedDb Db => Service(Wf.XedDb);

        bool Started = false;

        object StartLocker = new();

        enum StoreIndex : byte
        {
            InstPattern,

            RuleTables,

            InstLayouts,
        }

        public ref readonly Index<InstPattern> Patterns
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstPattern>>(StoreIndex.InstPattern);
        }

        public ref readonly RuleTables RuleTables
        {
            [MethodImpl(Inline)]
            get => ref Load<RuleTables>(StoreIndex.RuleTables);
        }

        public ref readonly InstLayouts InstLayouts
        {
            [MethodImpl(Inline)]
            get => ref Load<InstLayouts>(StoreIndex.InstLayouts);
        }

        Index<object> DataStores = alloc<object>(24);

        [MethodImpl(Inline)]
        ref readonly T Load<T>(StoreIndex index)
            => ref core.@as<object,T>(DataStores[(byte)index]);

        [MethodImpl(Inline)]
        void Store<T>(StoreIndex index, Func<T> f)
            => core.@as<object,T>(DataStores[(byte)index]) = f();

        InstLayouts CalcLayouts(Index<InstPattern> patterns) => Data(nameof(CalcLayouts), () => LayoutCalcs.layouts(patterns));

        void StartDirect()
        {
            var patterns = Rules.CalcPatterns();
            Store(StoreIndex.InstPattern,Rules.CalcPatterns);
            Store(StoreIndex.RuleTables,Rules.CalcRuleTables);
            Store(StoreIndex.InstLayouts, () => CalcLayouts(patterns));
            Started = true;
        }

        [MethodImpl(Inline)]
        public void Start()
        {
            lock(StartLocker)
            {
                if(!Started)
                    StartDirect();
            }
        }

        public void EmitCatalog()
        {
            Paths.Targets().Delete();
            Main.Emit(XedFields.Defs.Positioned);
            exec(PllExec,
                () => Main.EmitChipMap(),
                () => Main.ImportForms(),
                () => Main.EmitRegmaps(),
                () => Main.EmitBroadcastDefs(),
                () => Rules.EmitCatalog(Patterns,RuleTables),
                () => Emit(InstLayouts)
                );

            Db.EmitArtifacts();
        }

        void Emit(in InstLayouts src)
        {
            FileEmit(src.Format(), 0, Paths.Target("xed.inst.layouts.vectors", FS.Csv));
            TableEmit(src.Records.View, InstLayoutRecord.RenderWidths, Paths.Table<InstLayoutRecord>());
        }

        protected override void Disposing()
        {
            InstLayouts?.Dispose();
        }
    }
}