//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public sealed partial class LlvmCmd : AppCmdService<LlvmCmd,CmdShellState>
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        AppServices AppSvc => Service(Wf.AppServices);

        public LlvmQuery Query => DataEmitter.Query;

        IProjectWs Data;

        public void EmitInstAlias()
            => AppSvc.TableEmit(DataProvider.InstAliases(), LlvmPaths.Table<LlvmInstAlias>());

        protected override void Initialized()
        {
            Data = Ws.Project(ProjectNames.LlvmData);
            State.Init(Wf, Ws);
            State.Project(Data);
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => array<ICmdProvider>(this, this, LlvmCmdProvider.create(wf, this));

        Outcome Flow(string query, FS.Files src)
        {
            Files(src);
            Query.FileEmit(query, @readonly(src.View.Map(x => x.ToUri())));
            return true;
        }
    }
}