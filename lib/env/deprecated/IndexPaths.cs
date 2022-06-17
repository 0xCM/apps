//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial interface IEnvPaths
    {
        FS.FilePath IndexFile(string id)
            => IndexRoot() + FS.file(id, FS.Idx);
    }
}