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
        static XedRuntime Xed;

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

        ref readonly Index<InstPattern> Patterns
            => ref Xed.Views.Patterns;

        protected override void Initialized()
        {
            ProjectLoad("canonical");
        }
    }
}