//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ProcessContext
    {
        public int ProcessId;

        public string ProcessName;

        public Identifier Subject;

        public Timestamp Timestamp;

        public ReadOnlySeq<ProcessPartition> Partitions;

        public FS.FilePath PartitionPath;

        public ReadOnlySeq<ProcessMemoryRegion> Regions;

        public FS.FilePath RegionPath;

        public FS.FilePath DumpPath;
    }
}