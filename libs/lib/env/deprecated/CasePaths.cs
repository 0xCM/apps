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
            => Env.Db + FS.folder(cases) + FS.folder(string.Format("{0}", subject));

        FS.FolderPath CaseDir<T,D>(T subject, D discriminator)
            => CaseDir(subject) + FS.folder(string.Format("{0}", discriminator));

    }
}