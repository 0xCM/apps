//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EnvData
    {
        public FS.FolderPath Db
            => FS.dir("d:/views/db");

        public FS.FolderPath Control
            => FS.dir("C:\\tmp");

        public FS.FolderPath Tools
            => FS.dir("C:\\tmp");

        public FS.FolderPath CacheRoot
            => FS.dir("C:\\tmp");

        public FS.FolderPath LlvmRoot
            => FS.dir("C:\\tmp");

        public FS.FolderPath DevWs
            => FS.dir("C:\\tmp");
    }
}