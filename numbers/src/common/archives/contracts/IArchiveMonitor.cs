//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate void FileChanged(FileChange description);

    [Free]
    public interface IArchiveMonitor : IMonitor<FS.FolderPath>
    {
        FS.FolderPath Root {get;}

        FS.FolderPath IMonitor<FS.FolderPath>.Subject
            => Root;
    }
}