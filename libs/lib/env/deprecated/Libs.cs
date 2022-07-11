//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial interface IEnvPaths
    {
        FS.FilePath AppDataFile(FS.FileName file)
            => AppLogRoot() + file;
    }
}