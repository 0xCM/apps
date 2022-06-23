//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EnvData
    {
        readonly Env Source;

        [MethodImpl(Inline)]
        internal EnvData(Env src)
        {
            Source = src;
        }

        public FS.FolderPath ZDev
            => Source.ZDev;

        public FS.FolderPath Db
            => Source.Db;

        public FS.FolderPath Control
            => Source.Control;

        public FS.FolderPath Packages
            => Source.Packages;

        public FS.FolderPath Tools
            => Source.Tools;

        public FS.FolderPath Logs
            => Source.Logs;

        public FS.FolderPath CacheRoot
            => Source.CacheRoot;

        public FS.FolderPath Libs
            => Source.Libs;

        public FS.FolderPath CapturePacks
            => Source.CapturePacks;

        public FS.FolderPath LlvmRoot
            => Source.LlvmRoot;

        public FS.FolderPath DevWs
            => Source.DevWs;

        public FS.FolderPath ToolWs
            => DevWs + FS.folder("tools");
    }
}