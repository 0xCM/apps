//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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

        public FS.FolderPath DevRoot
            => Source.DevRoot;

        public FS.FolderPath Db
            => Source.Db;

        public FS.FolderPath Control
            => Source.Control;

        public FS.FolderPath ZEnvDb
            => Source.ZEnvDb;

        public FS.FolderPath Packages
            => Source.Packages;

        public FS.FolderPath Tools
            => Source.Tools;

        public FS.FolderPath Archives
            => Source.Archives;

        public FS.FolderPath Logs
            => Source.Logs;

        public FS.FolderPath Tmp
            => Source.Tmp;

        public FS.FolderPath ZBin
            => Source.ZBin;

        public FS.FilePath CdbLogPath
            => Source.CdbLogPath;

        public FS.FolderPath SymCacheRoot
            => Source.SymCacheRoot;

        public FS.FolderPath DefaultSymbolCache
            => Source.DefaultSymbolCache;

        public FS.FolderPath CacheRoot
            => Source.CacheRoot;

        public FS.FolderPath Libs
            => Source.Libs;

        public FS.FolderPath DataRoot
            => Source.DataRoot;

        public FS.FolderPath VendorDocs
            => Source.VendorDocs;

        public FS.FolderPath CapturePacks
            => Source.CapturePacks;

        public FS.FolderPath LlvmRoot
            => Source.LlvmRoot;

        public ulong CpuCount
            => Source.CpuCount;

        public FS.FolderPath DevWs
            => Source.DevWs;

        public FS.FolderPath AsmWs
            => DevWs + FS.folder("asm");

        public FS.FolderPath ToolWs
            => DevWs + FS.folder("tools");
    }
}