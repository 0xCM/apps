//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial interface IEnvPaths
    {
        FS.FolderPath LibDir(string name)
            => LibRoot() + FS.folder(name);

        FS.FolderPath LibDir(PartId part, string framework)
            => LibDir("z0." + part.Format()) + FS.folder(framework);

        FS.FilePath LibPath(PartId part, string framework)
            => LibDir("z0." + part.Format()) + FS.folder(framework) + FS.file("z0." + part.Format(), FS.Dll);

        FS.FilePath AppDataFile(FS.FileName file)
            => AppLogRoot() + file;
    }
}