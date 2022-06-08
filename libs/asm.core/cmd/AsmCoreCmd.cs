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

        XedPaths XedPaths => Xed.Paths;

        XedDb XedDb => Xed.XedDb;

        CsLang CsLang => Wf.CsLang();

        AsmCodeGen AsmCodeGen => Wf.AsmCodeGen();

        IntelSdm Sdm => Wf.IntelSdm();

        AsmRegSets Regs => Service(AsmRegSets.create);

        ApiCode ApiCode => Wf.ApiCode();

        ApiCodeFiles CodeFiles => Wf.ApiCodeFiles();

        StanfordAsmCatalog StanfordCatalog => Wf.StanfordCatalog();

        Tooling Tooling => Wf.Tooling();

        protected override void Initialized()
        {
            ProjectLoad("canonical");
        }

        IProjectWs Project()
            => CmdRunner.Project();

        Outcome LoadStanfordForms()
        {
            var rows = StanfordCatalog.LoadSource();
            var count = rows.Length;
            var forms = alloc<AsmFormInfo>(count);
            var dst = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                AsmSigInfo.parse(row.Instruction, out var sig);
                var form = new AsmFormInfo(new (row.OpCode), sig);
                seek(forms,i) = form;
                var spec = string.Format("{0,-32} | {1,-42} | {2,-42}", form.Sig.Mnemonic, form.OpCode, form.Sig);
                dst.Add(spec);
            }

            dst.Sort();
            iter(dst.ViewDeposited(), x => Wf.Row(x));

            return true;
        }

        [CmdOp("env/emit/includes")]
        void LoadToolEnv()
            => Tooling.EmitEnvIncldes();


        [CmdOp("asm/codegen")]
        void GenAmsCode()
        {
            AsmCodeGen.Emit();
        }

        [CmdOp("asm/refs/import")]
        void ImportAsmRefs()
        {
            ImportNasmCatalog();
            ImportStanfordCatalog();
            ImportCultData();
        }

        [CmdOp("asm/nasm/import")]
        void ImportNasmCatalog()
            => Wf.NasmCatalog().ImportInstructions();

        [CmdOp("asm/stanford/import")]
        void ImportStanfordCatalog()
            => StanfordCatalog.Import();

        [CmdOp("asm/cult/import")]
        void ImportCultData()
            => Wf.CultProcessor().RunEtl();

        ref readonly Index<InstPattern> Patterns
            => ref Xed.Views.Patterns;
    }
}