//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFilteredArchive
    {
        Index<FS.FolderPath> Directories();

        Deferred<FS.FilePath> Files();
    }
}