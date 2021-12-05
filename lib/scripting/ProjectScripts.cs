//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using static Root;
    using static core;

    public class ProjectScripts : AppService<ProjectScripts>
    {
        OmniScript OmniScript;

        protected override void Initialized()
        {
            OmniScript = Wf.OmniScript();
        }


        public Outcome RunScript(IProjectWs project, string srcid, ScriptId script, Subject? scope = null)
            => RunScript(project.Project, srcid, script, scope);

        public Outcome RunScript(ProjectId project, string srcid, ScriptId script, Subject? scope = null)
        {
            var result = Outcome.Success;
            if(nonempty(srcid))
            {
                result = OmniScript.RunProjectScript(project, srcid, script, false, out _);
                return result;
            }

            var src = ProjectFiles(project, scope).View;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                RunScript(project, path, script);
            }

            return result;
        }

        FS.Files ProjectFiles(ProjectId id, Subject? scope)
        {
            if(scope != null)
                return Ws.Project(id).SrcFiles(scope.Value.Format());
            else
                return Ws.Project(id).SrcFiles();
        }

        Outcome RunScript(ProjectId project, FS.FilePath path, ScriptId script)
        {
            var srcid = path.FileName.WithoutExtension.Format();
            OmniScript.RunProjectScript(project, srcid, script, true, out var flows);
            for(var j=0; j<flows.Length; j++)
            {
                ref readonly var flow = ref skip(flows, j);
                Write(flow.Format());
            }
            return true;
        }
    }
}