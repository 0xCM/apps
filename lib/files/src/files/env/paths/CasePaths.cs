//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath CaseDir<T>(T subject)
            => CaseRoot() + FS.folder(string.Format("{0}", subject));

        FS.FolderPath CaseDir<T,D>(T subject, D discriminator)
            => CaseDir(subject) + FS.folder(string.Format("{0}", discriminator));

        FS.FolderPath TestLogRoot()
            => LogRoot() + FS.folder(tests);

        FS.FolderPath TestLogDir(PartId id)
            => TestLogRoot() + FS.folder(id.Format());

        FS.FolderPath TestAppLogRoot(Type t)
            => TestLogDir(t.Assembly.Id());

        FS.FolderPath TestAppLogRoot<T>()
            => TestAppLogRoot(typeof(T));

        FS.FolderPath TestLogSummaryRoot()
            => TestLogRoot();

        FS.FilePath CaseLogSummary()
            => TestLogSummaryRoot() + FS.file(AppName, FS.Csv);
    }
}