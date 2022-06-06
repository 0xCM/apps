//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedRules;

    public partial class AsmCoreCmd : WsCmdService<AsmCoreCmd>
    {
        // public static AsmCoreCmd commands(IWfRuntime wf, Index<ICmdProvider> providers, bool start)
        //     => Create(wf, providers, start);

        // public static AsmCoreCmd commands(IWfRuntime wf, params ICmdProvider[] providers)
        //     => Create(wf, providers, false);

        static XedRuntime Xed;

        //static new Index<ICmdProvider> Providers;

        //static AsmCoreCmd Instance;

        // static AsmCoreCmd Create(IWfRuntime wf, Index<ICmdProvider> providers, bool start)
        // {
        //     Xed = XedRuntime.create(wf);
        //     Providers = providers;
        //     Instance = create(wf);
        //     if(start)
        //         Xed.Start();
        //     return Instance;
        // }

        CoffServices Coff => Wf.CoffServices();

        XedPaths XedPaths => Xed.Paths;

        XedDb XedDb => Xed.XedDb;

        CsLang CsLang => Wf.CsLang();

        AsmCodeGen AsmCodeGen => Wf.AsmCodeGen();

        IntelSdm Sdm => Wf.IntelSdm();

        AsmRegSets Regs => Service(AsmRegSets.create);

        ApiCode ApiCode => Wf.ApiCode();

        ApiCodeFiles CodeFiles => Wf.ApiCodeFiles();

        protected override IWsCmdRunner CmdRunner
            => Xed.CmdRunner;

        IProjectWs Project()
            => CmdRunner.Project();

        [CmdOp("asm/codegen")]
        void GenAmsCode()
        {
            AsmCodeGen.Emit();
        }

        [CmdOp("asm/nasm/import")]
        Outcome EmitNasmCatalog(CmdArgs args)
        {
            Wf.NasmCatalog().ImportInstructions();
            return true;
        }

        // [CmdOp("checks/run")]
        // void ChecksExec()
        //     => CheckRunner.Run();

        // [CmdOp("checks/list")]
        // void ChecksList()
        //     => CheckRunner.ListChecks();

        ref readonly Index<InstPattern> Patterns
            => ref Xed.Views.Patterns;

        protected override void Initialized()
        {
            ProjectLoad("canonical");
        }

        // protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
        //     => Providers + core.array((ICmdProvider)this);
    }
}