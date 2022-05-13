//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    public partial class AsmCoreCmd : WsCmdService<AsmCoreCmd>
    {
        XedRuntime Xed;

        XedDocs XedDocs => Xed.Docs;

        XedPaths XedPaths => Xed.Paths;

        XedRules Rules => Xed.Rules;

        XedDisasmSvc Disasm => Xed.XedDisasm;

        XedDb XedDb => Xed.XedDb;

        [MethodImpl(Inline)]
        StringRef Ref(string src)
            => Xed.Alloc.String(src);

        [MethodImpl(Inline)]
        Label Label(string src)
            => Xed.Alloc.Label(src);

        ref readonly RuleTables RuleTables
            => ref Xed.Views.RuleTables;

        ref readonly Index<InstPattern> Patterns
            => ref Xed.Views.Patterns;

        ref readonly CellTables CellTables
            => ref Xed.Views.CellTables;

        ref readonly Index<RuleExpr> RuleExpr
            => ref Xed.Views.RuleExpr;

        public AsmCoreCmd With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }

        protected override AppDb AppDb
            => Xed.AppDb;

        protected override WsProjects Projects
            => Xed.Projects;

        XedOpCodes OpCodes => Service(Wf.XedOpCodes);

        CsLang CsLang => Service(Wf.CsLang);

        BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        ApiComments ApiComments => Service(Wf.ApiComments);

        AsmDocs AsmDocs => Service(Wf.AsmDocs);

        AsmTables AsmTables => Service(Wf.AsmTables);

        AsmCodeGen AsmCodeGen => Service(Wf.AsmCodeGen);

        X86Dispatcher Jumps => Service(() => X86Dispatcher.create(Wf));

        IntelSdm Sdm => Service(Wf.IntelSdm);

        ApiCodeBanks ApiCodeBanks => Service(Wf.ApiCodeBanks);

        ApiDataPaths ApiDataPaths => Service(Wf.ApiDataPaths);

        EncodingCollector CodeCollector => Service(Wf.EncodingCollector);

        AsmObjects AsmObjects => Service(Wf.AsmObjects);

        CoffServices CoffServices => Service(Wf.CoffServices);

        AsmRegSets Regs => Service(AsmRegSets.create);

        protected override void Initialized()
        {
            LoadProject("canonical");
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => new ICmdProvider[]{
                this,
                wf.PbCmd()
            };

    }
}