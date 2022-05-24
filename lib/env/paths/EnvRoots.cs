//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        ICilPaths CilPaths
            => new CilPaths(Env);

        IImmArchive ImmArchive()
            => new ImmArchive(ImmCaptureRoot());

        FS.FolderPath DevWs()
            => Env.DevWs;

        FS.FolderPath CacheRoot()
            => Env.CacheRoot;

        FS.FolderPath EtlRoot()
            => Env.Db + FS.folder(etl);

        FS.FolderPath DbRoot()
            => Env.Db;

        FS.FolderPath ProcessContextRoot()
            => Env.CacheRoot + FS.folder(context);

        FS.FolderPath RuntimeRoot()
            => Env.ZBin;

        FS.FolderPath DbTableRoot()
            => Env.Db + FS.folder(tables);

        FS.FolderPath LibRoot()
            => Env.Libs;

        FS.FolderPath PackageRoot()
            => Env.Packages;

        FS.FolderPath DbDocRoot()
            => Env.Db + FS.folder(docs);

        FS.FolderPath JobRoot()
            => Env.Db + FS.folder(jobs);

        FS.FolderPath JobQueue()
            => JobRoot() + FS.folder(queue);

        FS.FolderPath ControlScripts()
            => Env.Control + FS.folder(".cmd");

        FS.FolderPath IndexRoot()
            => Env.Db + FS.folder(tables) + FS.folder(indices);

        FS.FolderPath LogRoot()
            => Env.Db + FS.folder(logs);

        FS.FolderPath ListRoot()
            => Env.Db + FS.folder(lists);

        FS.FolderPath BuildArchiveRoot()
            => Env.Db + FS.folder(bin) + FS.folder(builds);

        FS.FolderPath CaseRoot()
            => Env.Db + FS.folder(cases);

        FS.FolderPath AppLogRoot()
            => Env.Db + FS.folder(logs) + FS.folder(apps) + FS.folder(AppName);

        FS.FolderPath CmdLogRoot()
            => Env.Db + FS.folder(logs) + FS.folder(commands);

        FS.FolderPath BuildLogRoot()
            => Env.Db + FS.folder(logs) + FS.folder(dotbuild);

        FS.FolderPath DevRoot()
            => Env.DevRoot;

        FS.FolderPath ZRoot()
            => DevRoot(z0);

        FS.FolderPath CilDataRoot()
            => Env.Db + FS.folder(capture) + FS.folder(cildata);
    }
}