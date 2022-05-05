//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
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

        public new XedDb Db => Service(Wf.XedDb);

        [MethodImpl(Inline)]
        ref readonly Index<InstPattern> _Patterns()
        {
            Start();
            return ref PatternData;
        }

        [MethodImpl(Inline)]
        ref readonly RuleTables _RuleTables()
        {
            Start();
            return ref RuleTableData;
        }

        Index<InstPattern> PatternData;

        RuleTables RuleTableData;

        InstLayouts LayoutData;

        bool Started = false;

        object StartLocker = new();

        public ref readonly RuleTables RuleTables
        {
            [MethodImpl(Inline)]
            get => ref _RuleTables();
        }

        public ref readonly Index<InstPattern> Patterns
        {
            [MethodImpl(Inline)]
            get => ref _Patterns();
        }

        public ref readonly InstLayouts InstLayouts
        {
            [MethodImpl(Inline)]
            get => ref LayoutData;
        }

        void StartDirect()
        {
            PatternData = Rules.CalcPatterns();
            LayoutData = LayoutCalcs.layouts(PatternData);
            RuleTableData = Rules.CalcRuleTables();
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
            Start();
            Paths.Targets().Delete();
            Main.Emit(XedFields.Defs.Positioned);
            exec(PllExec,
                () => Main.EmitChipMap(),
                () => Main.ImportForms(),
                () => Main.EmitRegmaps(),
                () => Main.EmitBroadcastDefs(),
                () => Rules.EmitCatalog(Patterns,RuleTables),
                () => EmitInstLayouts()
                );

            Db.EmitArtifacts();
        }

        void Emit(in InstLayouts src)
        {
            FileEmit(src.Format(), 0, Paths.Target("xed.inst.layouts.test", FS.Txt));
            TableEmit(src.Records.View, InstLayoutRecord.RenderWidths, Paths.Table<InstLayoutRecord>());
        }

        public void EmitInstLayouts()
        {
            Emit(InstLayouts);
        }

        protected override void Disposing()
        {
            LayoutData?.Dispose();
        }
    }
}