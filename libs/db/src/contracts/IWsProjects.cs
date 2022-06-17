//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public interface IWsProjects : IRootedArchive
    {
        IWsProjects Home(ProjectId project)
            => new WsProjects(Root + FS.folder(project.Format()));

        IWsProject Project(ProjectId id)
            => WsProject.load(Root, id);

        IDbSources Scripts(ProjectId project)
            => new DbSources(Home(project),scripts);

        IDbSources Scripts(ProjectId project, string scope)
            => Scripts(project).Sources(scope);

        FS.FilePath Script(ProjectId project, string scope, ScriptId script, FileKind kind)
            => Scripts(project,scope).Path(script,kind);

        FS.FilePath Script(ProjectId project, ScriptId script, FileKind kind)
            => Scripts(project).Path(script, kind);

        IWsProjects Projects(string scope)
            => new WsProjects(Root, scope);
    }
}