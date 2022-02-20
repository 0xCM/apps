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

        WsProjects WsProjects => Service(Wf.WsProjects);

        public ClangSvc()
            : base(ToolId)
        {

        }

        public Outcome<Index<ToolCmdFlow>> CBuild(IProjectWs project, bool runexe = false)
            => WsProjects.RunScripts(project, "c-build", "c", flow => WsProjects.HandleBuildResponse(flow,runexe));

        public Outcome<Index<ToolCmdFlow>> CppBuild(IProjectWs project, bool runexe = false)
            => WsProjects.RunScripts(project, "cpp-build", "cpp", flow => WsProjects.HandleBuildResponse(flow,runexe));
    }
}