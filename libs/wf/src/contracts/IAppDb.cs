//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbSettings
    {
        IDbSources Settings();

        FS.FilePath SettingsPath(string name, FileKind kind);

        FS.FilePath SettingsPath<S>(FileKind kind);
    }

    public interface IDbEtl
    {
        IProjectWorkspace EtlSource(ProjectId src);

        IDbTargets EtlTargets(ProjectId src);

        FS.FilePath EtlTable<T>(ProjectId project)
            where T : struct;
    }

    public interface IAppDb : IDbSettings, IDbEtl
    {
        IDbSources DbIn();

        IDbArchive DbArchive(FS.FolderPath home);

        IDbArchive DbArchive(IRootedArchive home);

        IDbSources DbRoot();

        IDbSources DbIn(string scope);

        IDbTargets DbOut();

        IDbTargets DbOut(string scope);

        IDbTargets Logs();

        IDbTargets Logs(string scope);
    }
}