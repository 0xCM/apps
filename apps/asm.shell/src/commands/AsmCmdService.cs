//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public sealed partial class AsmCmdService : AppCmdService<AsmCmdService,CmdShellState>
    {
        IWorkspace AsmWs;

        IntelSdm Sdm => Service(Wf.IntelSdm);

        AsmRegSets RegSets => Service(Wf.AsmRegSets);

        AsmTables AsmTables => Service(Wf.AsmTables);

        ApiPacks ApiPacks => Service(Wf.ApiPacks);

        ApiPackArchive ApiPackArchive => Service(ApiPacks.Archive);

        ApiCatalogs ApiCatalogs => Service(Wf.ApiCatalogs);

        AppModules AppModules => Service(Wf.AppModules);

        PdbIndexBuilder PdbIndexBuilder => Service(Wf.PdbIndexBuilder);

        WsProjects WsProjects => Service(Wf.WsProjects);

        CliMemoryMap ResPack;

        IPolyrand Random;

        IWorkspace OutWs;

        public AsmCmdService()
        {
            ResPack = CliMemoryMap.Empty;
        }

        protected override void Initialized()
        {
            AsmWs = Ws.Asm();
            Random = Rng.wyhash64();
            OutWs = Ws.Output();
            State.Init(Wf, Ws);
        }

        protected override void Disposing()
        {
            ResPack.Dispose();
        }

        protected override void Error<T>(T content)
        {
            Write(content, FlairKind.Error);
        }

        CliMemoryMap OpenResPack()
        {
            if(ResPack.IsEmpty)
                ResPack = CliMemoryMap.create(Db.Package("respack") + FS.file("z0.respack", FS.Dll));
            return ResPack;
        }

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
            var cmd = Cmd.cmdline(script.Format(PathSeparator.BS));
            return OmniScript.Run(cmd, vars, out var response);
        }
    }
}