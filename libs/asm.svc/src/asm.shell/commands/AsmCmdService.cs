//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public sealed partial class AsmCmdService : AppCmdService<AsmCmdService>
    {
        AsmRegSets RegSets => Service(AsmRegSets.create);

        AsmTables AsmTables => Service(Wf.AsmTables);

        IPolyrand Random;

        protected override void Initialized()
        {
            Random = Rng.wyhash64();
        }

        [CmdOp("asm/refs/import")]
        void ImportAsmRefs()
        {
            ImportNasmCatalog();
            ImportCultData();
        }

        [CmdOp("asm/nasm/import")]
        void ImportNasmCatalog()
            => Wf.NasmCatalog().ImportInstructions();

        [CmdOp("asm/cult/import")]
        void ImportCultData()
            => Wf.CultProcessor().RunEtl();

        Outcome BuildAsmExe(string SrcId, FS.FilePath script)
        {
            const string ScriptId = "build-exe";
            var result = Outcome.Success;
            var vars = CmdVars.load(("SrcId", SrcId));
            var cmd = new CmdLine(script.Format(PathSeparator.BS));
            return OmniScript.Run(cmd, vars, out var response);
        }
    }
}