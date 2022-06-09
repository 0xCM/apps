//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public sealed partial class AsmCmdService : AppCmdService<AsmCmdService,CmdShellState>
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
            State.Init(Wf, Ws);
        }

        protected override void Error<T>(T content)
        {
            Write(content, FlairKind.Error);
        }

        FS.FolderPath GetToolOut(ToolId tool)
            => Ws.Output().Subdir(tool.Format());

        FS.FolderPath OutDir(string id)
            => OutWs.Subdir(id);

        public FS.FolderPath OutRoot()
            => OutWs.Root;

        Outcome BuildAsmExe(string id)
        {
            const string ScriptId = "build-exe";
            var result = Outcome.Success;
            var script = (AsmWs as IWorkspace).Script(ScriptId);
            var vars = Cmd.vars(
                ("SrcId", id)
                );
            var cmd = AppCmd.cmdline(script.Format(PathSeparator.BS));
            return OmniScript.Run(cmd, vars, out var response);
        }
    }
}