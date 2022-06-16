//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsCmdRunner : AppCmdService<WsCmdRunner,CmdShellState>, IWsCmdRunner<WsCmdRunner>
    {
        IWsProject _Project;

        public new WsCatalog ProjectFiles {get; private set;}

        public void Project(IWsProject ws)
        {
            _Project = Require.notnull(ws);
            ProjectFiles = WsCatalog.load(ws);
        }

        public IWsProject Project()
            => Require.notnull(_Project);

        public void LoadProject(CmdArgs args)
            => LoadProjectSources(AppDb.LlvmModel(arg(args,0).Value));

        bool LoadProjectSources(IWsProject ws)
        {
            if(ws == null)
            {
                Error("Project unspecified");
                return false;
            }

            Project(ws);
            Status(LoadingSources.Format(ws.Project, ws.Home()));

            var dir = ws.Home();
            if(dir.Exists)
                Files(ws.SrcFiles());
            else
            {
                Error(FS.missing(ws.Home()));
                return false;
            }
            return true;
        }


        static MsgPattern<ProjectId> ProjectUndefined
            => "Project {0} undefined";

        static MsgPattern<ProjectId,FS.FolderPath> LoadingSources
            => "Loading {0} sources from {1}";
    }
}