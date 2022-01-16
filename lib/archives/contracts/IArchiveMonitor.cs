//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IArchiveMonitor : IMonitor<FS.FolderPath>
    {
        FS.FolderPath Root {get;}

        FS.FolderPath IMonitor<FS.FolderPath>.Subject
            => Root;
    }
}