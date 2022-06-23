//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public sealed partial class AsmCmdService : AppCmdService<AsmCmdService>
    {
        IWorkspace AsmWs;

        AsmRegSets RegSets => Service(AsmRegSets.create);

        AsmTables AsmTables => Service(Wf.AsmTables);

        IPolyrand Random;

        IWorkspace OutWs;

        protected override void Initialized()
        {
            AsmWs = Ws.Asm();
            Random = Rng.wyhash64();
            OutWs = Ws.Output();
        }

        public FS.FolderPath OutRoot()
            => OutWs.Root;

        Outcome BuildAsmExe(string id)
        {
            const string ScriptId = "build-exe";
            var result = Outcome.Success;
            var script = (AsmWs as IWorkspace).Script(ScriptId);
            var vars = CmdVars.load(
                ("SrcId", id)
                );
            var cmd = CmdScripts.cmdline(script.Format(PathSeparator.BS));
            return OmniScript.Run(cmd, vars, out var response);
        }
    }
}