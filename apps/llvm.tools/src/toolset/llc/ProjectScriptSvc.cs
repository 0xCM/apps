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
                for (var i=0; i<length; i++)
                {
                    var srcid = files[i].FileName.WithoutExtension.Format();

                    result = OmniScript.RunProjectScript(project.Project, srcid, scriptid, true, out var flows);
                    if(result)
                    {
                        var count = flows.Length;
                        for(var j=0; j<count; j++)
                        {
                            ref readonly var flow = ref skip(flows,j);
                            cmdflows.Add(flow);
                            Status(flow.Format());
                            receiver?.Invoke(flow);
                        }
                    }
                    else
                    {
                        result = (false, result.Message);
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
    }
}
