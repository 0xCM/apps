//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static Root;

    public class ProjectScriptSvc : AppService<ProjectScriptSvc>
    {
        public Outcome<Index<ToolCmdFlow>> RunScript(IProjectWs project, ScriptId scriptid, Subject? scope, Action<ToolCmdFlow> receiver = null)
        {
            var result = Outcome<Index<ToolCmdFlow>>.Success;
            var cmdflows = list<ToolCmdFlow>();
            if(nonempty(scriptid))
            {
                var files = ProjectFiles(project, scope);
                int length = files.Length;
                for(var i=0; i<length; i++)
                {
                    var path = files[i];
                    var srcid = path.FileName.WithoutExtension.Format();
                    result = RunScript(project.Project, scriptid, srcid);
                    if(result)
                    {
                        cmdflows.AddRange(result.Data);
                        foreach(var flow in result.Data)
                        {
                            Status(flow.Format());
                            receiver?.Invoke(flow);
                        }
                    }
                }
            }
            else
                result = (false, "Script specification unknown");

            if(cmdflows.Count != 0)
            {
                var dst = ProjectDb.Logs() + FS.folder("flows") + Tables.filename<ToolCmdFlow>(scriptid);
                Index<ToolCmdFlow> records = cmdflows.ToArray();
                TableEmit(records.View, ToolCmdFlow.RenderWidths, dst);
                result = (true,records);
            }

            return result;
        }

        Outcome<Index<ToolCmdFlow>> RunScript(ProjectId project, ScriptId script, string srcid)
        {
            var cmdflows = list<ToolCmdFlow>();
            var result = OmniScript.RunProjectScript(project, srcid, script, true, out var flows);
            if(result)
            {
                var count = flows.Length;
                for(var j=0; j<count; j++)
                    cmdflows.Add(skip(flows,j));
                return (true, cmdflows.ToArray());
            }

            return result;
        }
    }
}