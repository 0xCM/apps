//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    partial class Runtime
    {
        public Index<ProcessPartition> EmitPartitions(Process process, FS.FilePath dst)
        {
            var summaries = ProcessMemory.partitions(ProcessMemory.locate(process));
            EmitPartitions(summaries, dst);
            return summaries;
        }

        public Index<ProcessPartition> EmitPartitions(Process process, Timestamp ts)
        {
            var memory = ProcessMemory.locate(process);
            var summaries = ProcessMemory.partitions(memory);
            var dst = ContextPaths.ProcessPartitionPath(process, ts);
            EmitPartitions(summaries, dst);
            return summaries;
        }

        public Index<ProcessPartition> EmitPartitions(Process process, Timestamp ts, FS.FolderPath dir)
        {
            var memory = ProcessMemory.locate(process);
            var summaries = ProcessMemory.partitions(ProcessMemory.locate(process));
            var dst = ContextPaths.ProcessPartitionPath(dir, process, ts);
            EmitPartitions(summaries, dst);
            return summaries;
        }

        public Count EmitPartitions(Index<ProcessPartition> src, FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<ProcessPartition>(dst);
            var count = Tables.emit(src.View,dst);
            Wf.EmittedTable(flow,count);
            return count;
        }
    }
}