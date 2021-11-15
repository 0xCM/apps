//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    public sealed partial class AsmCmdService : AppCmdService<AsmCmdService,AsmShellState>
    {
        NativeBuffer CodeBuffer;

        ByteSize CodeSize;

        Identifier RoutineName;

        IWorkspace AsmWs;

        IApiPack ApiPack;

        IntelSdm Sdm;

        AsmRegSets RegSets;

        IntelXed Xed;

        IntelIntrinsics IntelIntrinsics;

        AsmTables AsmTables;

        ApiPacks ApiPacks;

        ApiHexPacks ApiHexPacks;

        ApiPackArchive ApiArchive;

        ApiCatalogs ApiCatalogs;

        CliMemoryMap ResPack;

        IPolyrand Random;

        AsmEtl AsmEtl;

        IWorkspace OutWs;

        byte[] _Assembled;

        public AsmCmdService()
        {
            CodeBuffer = memory.native(Pow2.T14);
            RoutineName = Identifier.Empty;
            CodeSize = 0;
            _Assembled = array<byte>();
            ResPack = CliMemoryMap.Empty;
        }

        protected override void Initialized()
        {
            AsmWs = Ws.Asm();
            ApiPacks = Wf.ApiPacks();
            ApiPack = ApiPacks.Current();
            ApiArchive = ApiPack.Archive();
            Sdm = Wf.IntelSdm();
            RegSets = Wf.AsmRegSets();
            Xed = Wf.IntelXed();
            AsmTables = Wf.AsmTables();
            Random = Rng.wyhash64();
            ApiHexPacks = Wf.ApiHexPacks();
            OutWs = Ws.Output();
            ApiCatalogs = Wf.ApiCatalogs();
            AsmEtl = Wf.AsmEtl();
            IntelIntrinsics = Wf.IntelIntrinsics();
            State.Init(Wf, Ws);
        }

        protected override void Disposing()
        {
            CodeBuffer.Dispose();
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