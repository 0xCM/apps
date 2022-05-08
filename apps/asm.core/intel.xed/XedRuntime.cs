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

    public partial class XedRuntime : AppService<XedRuntime>
    {
        public bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        public IAllocProvider Allocator => _Alloc;

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

        bool Started = false;

        object StartLocker = new();

        enum StoreIndex : byte
        {
            InstPattern,

            RuleTables,

            InstLayouts,
        }

        Index<object> DataStores = alloc<object>(24);

        [MethodImpl(Inline)]
        ref readonly T Load<T>(StoreIndex index)
            => ref core.@as<object,T>(DataStores[(byte)index]);

        [MethodImpl(Inline)]
        void Store<T>(StoreIndex index, Func<T> f)
            => core.@as<object,T>(DataStores[(byte)index]) = f();

        InstLayouts CalcLayouts(Index<InstPattern> patterns) => Data(nameof(CalcLayouts), () => LayoutCalcs.layouts(patterns));

        Alloc _Alloc;

        public XedRuntime()
        {
            _Alloc = Alloc.allocate();
        }

        void StartDirect()
        {
            var patterns = Rules.CalcPatterns();
            Store(StoreIndex.InstPattern, Rules.CalcPatterns);
            Store(StoreIndex.RuleTables, Rules.CalcRuleTables);
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

        protected override void Disposing()
        {
            InstLayouts?.Dispose();
            _Alloc?.Dispose();
        }

        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }
    }
}