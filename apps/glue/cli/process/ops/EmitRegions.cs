//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;

    partial class ProcessContextPipe
    {
        public Index<ProcessMemoryRegion> EmitRegions(Process process, FS.FilePath dst)
        {
            var regions = ImageMemory.regions(process);
            EmitRegions(regions,dst);
            return regions;
        }

        public Index<ProcessMemoryRegion> EmitRegions(Process process, Timestamp ts)
        {
            var regions = ImageMemory.regions(process);
            var dst = ContextPaths.MemoryRegionPath(process,ts);
            EmitRegions(regions,dst);
            return regions;
        }

        public Index<ProcessMemoryRegion> EmitRegions(Process process, Timestamp ts, FS.FolderPath dir)
        {
            var regions = ImageMemory.regions(process);
            var dst = ContextPaths.MemoryRegionPath(process, ts, dir);
            EmitRegions(regions,dst);
            return regions;
        }

        public Index<ProcessMemoryRegion> EmitRegions(FS.FilePath dst)
        {
            var regions = ImageMemory.regions();
            EmitRegions(regions,dst);
            return regions;
        }

        public Count EmitRegions(Index<ProcessMemoryRegion> src, FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<ProcessMemoryRegion>(dst);
            var count = Tables.emit(src.View,dst);
            Wf.EmittedTable(flow,count);
            return count;
        }
    }
}