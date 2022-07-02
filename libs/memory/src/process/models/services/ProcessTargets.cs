//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ProcessTargets
    {
        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public ProcessTargets(FS.FolderPath root)
        {
            Root = root;
        }

        [MethodImpl(Inline)]
        public static implicit operator ProcessTargets(FS.FolderPath root)
            => new ProcessTargets(root);

        public FS.FileName ProcessPartitionHashFile(string process, Timestamp ts, Identifier subject)
            => FS.file(string.Format("{0}.{1}.{2}.hashes", "image.process.partitions", process, ts.Format()), FS.Csv);

        public FS.FilePath ProcessPartitionHashPath(string process, Timestamp ts, Identifier subject)
            => Root + ProcessPartitionHashFile(process, ts, subject);

        public FS.FileName ProcessPartitionFile(Process process, Timestamp ts)
            => FS.file(string.Format("{0}.{1}.{2}", "image.process.partitions", process.ProcessName, ts.Format()), FS.Csv);

        public FS.FilePath ProcessPartitionPath(Process process, Timestamp ts)
            => Root + ProcessPartitionFile(process,ts);

        public FS.FilePath ProcessPartitionPath(FS.FolderPath dir, Process process, Timestamp ts)
            => dir + ProcessPartitionFile(process,ts);

        public FS.FileName MemoryRegionHashFile(string process, Timestamp ts, Identifier subject)
            => FS.file(string.Format("memory.hash.detail.{0}.{1}", process, ts.Format()), FS.Csv);

        public FS.FileName MemoryRegionFile(Process process, Timestamp ts)
            => FS.file(string.Format("{0}.{1}.{2}", "image.memory.regions", process.ProcessName, ts.Format()), FS.Csv);

        public FS.FilePath MemoryRegionPath(Process process, Timestamp ts)
            => Root + MemoryRegionFile(process, ts);

        public FS.FilePath MemoryRegionPath(Process process, Timestamp ts, FS.FolderPath dir)
            => dir + MemoryRegionFile(process, ts);

        public FS.FilePath MemoryRegionHashPath(string process, Timestamp ts, Identifier subject)
            => Root + MemoryRegionHashFile(process, ts, subject);

        public FS.Files MemoryRegionPaths()
            => Root.AllFiles.Where(f => f.FileName.Contains("image.memory.regions")).Storage.Sort();
    }
}