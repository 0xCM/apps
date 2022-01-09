//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    [Tool(ToolId)]
    public class ClangSvc : ToolService<ClangSvc>
    {
        public const string ToolId = ToolNames.clang;

        ProjectScriptSvc ScriptSvc => Service(Wf.ProjectScriptSvc);

        BuildResponseHandler ResponseHandler => Service(() => BuildResponseHandler.create(Wf));

        public ClangSvc()
            : base(ToolId)
        {

        }

        public Outcome<Index<ToolCmdFlow>> CBuild(IProjectWs project, bool runexe = false)
            => ScriptSvc.RunScript(project, "c-build", "c", flow => ResponseHandler.HandleBuildResponse(flow,runexe));

        public Outcome<Index<ToolCmdFlow>> CppBuild(IProjectWs project, bool runexe = false)
            => ScriptSvc.RunScript(project, "cpp-build", "cpp", flow => ResponseHandler.HandleBuildResponse(flow,runexe));
    }
}