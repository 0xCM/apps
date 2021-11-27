//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    using SP = SymbolPaths;

    partial interface IEnvPaths
    {
        ICilPaths CilPaths
            => new CilPaths(Env);

        SymbolPaths DebugSymbolPaths()
            => SP.create(Env);

        IImmArchive ImmArchive()
            => new ImmArchive(ImmCaptureRoot());

        FS.FolderPath DevWs()
            => Env.DevWs;

        FS.FolderPath CacheRoot()
            => Env.CacheRoot;

        FS.FolderPath EtlRoot()
            => DbRoot() + FS.folder(etl);

        FS.FolderPath DbRoot()
            => Env.Db;

        FS.FolderPath ProcessContextRoot()
            => CacheRoot() + FS.folder(context);

        FS.FolderPath RuntimeRoot()
            => Env.ZBin;

        FS.FolderPath DbTableRoot()
            => DbRoot() + FS.folder(tables);

        FS.FolderPath DumpRoot()
            => FS.dir("j:/dumps");

        FS.FolderPath LibRoot()
            => Env.Libs;

        FS.FolderPath PackageRoot()
            => Env.Packages;

        FS.FolderPath DbDocRoot()
            => DbRoot() + FS.folder(docs);

        FS.FolderPath JobRoot()
            => DbRoot() + FS.folder(jobs);

        FS.FolderPath JobQueue()
            => JobRoot() + FS.folder(queue);

        FS.FolderPath ControlScripts()
            => ControlRoot() + FS.folder(".cmd");

        FS.FolderPath IndexRoot()
            => DbTableRoot() + FS.folder(indices);

        FS.FolderPath LogRoot()
            => DbRoot() + FS.folder(logs);

        FS.FolderPath ListRoot()
            => DbRoot() + FS.folder(lists);

        FS.FolderPath BuildArchiveRoot()
            => BinaryRoot() + FS.folder(builds);

        FS.FolderPath CaseRoot()
            => DbRoot() + FS.folder(cases);

        FS.FolderPath AppLogRoot()
            => LogRoot() + FS.folder(apps) + FS.folder(AppName);

        FS.FolderPath CmdLogRoot()
            => LogRoot() + FS.folder(commands);

        FS.FolderPath BuildLogRoot()
            => LogRoot() + FS.folder(dotbuild);

        FS.FolderPath DevRoot()
            => Env.DevRoot;

        FS.FolderPath ZRoot()
            => DevRoot(z0);

        FS.FolderPath CilDataRoot()
            => CaptureRoot() + FS.folder(cildata);
    }
}