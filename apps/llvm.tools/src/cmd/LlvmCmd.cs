//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    public sealed partial class LlvmCmd : AppCmdService<LlvmCmd,CmdShellState>
    {
        LlvmToolset Toolset => Service(Wf.LLvmToolset);

        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        LlvmRepo LlvmRepo => Service(Wf.LlvmRepo);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        IProjectWs Data;

        ToolId SelectedTool;

        public LlvmCmd()
        {
            SelectedTool = ToolId.Empty;
        }

        protected override void Initialized()
        {
            Data = Ws.Project(ProjectNames.LlvmData);
            State.Init(Wf, Ws);
            State.Project(Data);
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => array<ICmdProvider>(this, this, LlvmCmdProvider.create(wf));

        Outcome Flow(FS.Files src)
        {
            Files(src);
            return true;
        }

        Outcome Flow(string query, FS.Files src)
        {
            Files(src);
            DataEmitter.EmitQueryResults(query, @readonly(src.View.Map(x => x.ToUri())));
            return true;
        }

        Outcome Flow<T>(string query, string args, ReadOnlySpan<T> src)
        {
            DataEmitter.EmitQueryResults(query, args, src);
            return true;
        }

        Outcome Flow<T>(string query, ReadOnlySpan<T> src)
        {
            DataEmitter.EmitQueryResults(query, src);
            return true;
        }

        Outcome Flow<T>(string query, Index<T> src)
        {
            DataEmitter.EmitQueryResults(query, src.View);
            return true;
        }
    }
}