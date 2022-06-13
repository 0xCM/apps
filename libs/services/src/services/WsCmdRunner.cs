//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsCmdRunner : AppCmdService<WsCmdRunner,CmdShellState>, IWsCmdRunner<WsCmdRunner>
    {
        IProjectWs _Project;

        public new WsCatalog ProjectFiles {get; private set;}

        public void Project(IProjectWs ws)
        {
            _Project = Require.notnull(ws);
            ProjectFiles = WsCatalog.load(ws);
        }

        public IProjectWs Project()
            => Require.notnull(_Project);

        public void LoadProject(CmdArgs args)
            => LoadProjectSources(Ws.Project(arg(args,0).Value));

        public FS.Files SourceFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
        }

        public Outcome RunScript(IProjectWs ws, CmdArgs args, ScriptId script, Subject? scope = null)
        {
            var result = Outcome.Success;
            if(args.Count != 0)
            {
                result = OmniScript.RunProjectScript(ws.Project, arg(args,0).Value, script, false, out _);
                return result;
            }

            var src = SourceFiles(ws, scope).View;
            if(result.Fail)
                return result;

            for(var i=0; i<src.Length; i++)
                RunProjectScript(ws, skip(src,i), script);

            return result;
        }

        public Outcome RunProjectScript(IProjectWs project, FS.FilePath path, ScriptId script)
        {
            var srcid = path.FileName.WithoutExtension.Format();
            OmniScript.RunProjectScript(project.Project, srcid, script, true, out var flows);
            for(var j=0; j<flows.Length; j++)
            {
                ref readonly var flow = ref skip(flows, j);
                Write(flow.Format());
            }
            return true;
        }

        bool LoadProjectSources(IProjectWs ws)
        {
            if(ws == null)
            {
                Error("Project unspecified");
                return false;
            }

            Project(ws);
            Status(LoadingSources.Format(ws.Project));

            var dir = ws.Home();
            if(dir.Exists)
                Files(ws.SrcFiles());
            else
            {
                Error(ProjectUndefined.Format(ws.Project));
                return false;
            }
            return true;
        }

        static MsgPattern<ProjectId> ProjectUndefined
            => "Project {0} undefined";

        static MsgPattern<ProjectId> LoadingSources
            => "Loading {0} sources";
    }
}