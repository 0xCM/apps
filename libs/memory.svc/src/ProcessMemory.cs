//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using System.Linq;

    public partial class ProcessMemory : WfSvc<ProcessMemory>
    {
        public ProcessTargets ContextPaths {get; private set;}

        protected override void OnInit()
        {
            ContextPaths = new ProcessTargets(AppDb.DbCapture().Root);
        }

        ImageRegions Regions => Wf.ImageRegions();

        public ReadOnlySpan<AddressBankEntry> LoadContextAddresses()
        {
            var worker = new RegionProcessor();
            worker.Include(Regions.LoadRegions());
            var product = worker.Complete();
            var count = product.SelectorCount;
            var dst = list<AddressBankEntry>();
            var total = 0ul;
            for(ushort i=0; i<count; i++)
            {
                var bases = product.Bases(i);
                var selector = product.Selector(i);
                for(ushort j=0; j<bases.Length; j++)
                {
                    (var @base, var size) = skip(bases, j);
                    total += size;

                    var record = new AddressBankEntry();
                    record.Index = (i,j);
                    record.Selector = selector;
                    record.Base = @base;
                    record.Size = size;
                    record.Target = ((ulong)@base | (ulong)selector << 32);
                    record.TotalSize = total;
                    dst.Add(record);
                }
            }
            return dst.ViewDeposited();
        }

        public void Emit(ReadOnlySpan<AddressBankEntry> src, FS.FilePath dst)
            => TableEmit(src,dst);

        public Index<ProcessPartition> EmitPartitions(Process process, FS.FilePath dst)
        {
            var summaries = ImageMemory.partitions(ImageMemory.locations(process));
            EmitPartitions(summaries, dst);
            return summaries;
        }

        public Index<ProcessPartition> EmitPartitions(Process process, Timestamp ts)
        {
            var memory = ImageMemory.locations(process);
            var summaries = ImageMemory.partitions(memory);
            var dst = ContextPaths.ProcessPartitionPath(process, ts);
            EmitPartitions(summaries, dst);
            return summaries;
        }

        public Index<ProcessPartition> EmitPartitions(Process process, Timestamp ts, FS.FolderPath dir)
        {
            var memory = ImageMemory.locations(process);
            var summaries = ImageMemory.partitions(ImageMemory.locations(process));
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

        [Op]
        public static MemoryAddress @base(Assembly src)
            => @base(Path.GetFileNameWithoutExtension(src.Location));

        [MethodImpl(Inline), Op]
        public static MemoryAddress @base(string procname)
        {
            var module = ImageMemory.modules(Process.GetCurrentProcess()).Where(m => Path.GetFileNameWithoutExtension(m.ImagePath.Name) == procname).First();
            return module.BaseAddress;
        }

        [Op]
        public static Index<ProcessPartition> emit(Index<ImageLocation> src, FS.FilePath dst)
        {
            var records = ImageMemory.partitions(src);
            var target = records.Edit;
            var formatter = Tables.formatter<ProcessPartition>(16);
            var count = records.Length;
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(target,i)));
            return records;
        }

        /// <summary>
        /// Captures state information about a specified process
        /// </summary>
        /// <param name="src">The source process</param>
        [MethodImpl(Inline), Op]
        public static ProcessMemoryState state(Process src)
        {
            var dst = new ProcessMemoryState();
            fill(src, ref dst);
            return dst;
        }


        [Op]
        public static ref ProcessMemoryState fill(Process src, ref ProcessMemoryState dst)
        {
            dst.ImageName = src.ProcessName;
            dst.ProcessId = (uint)src.Id;
            dst.BaseAddress = src.MainModule.BaseAddress;
            dst.MinWorkingSet =(ulong)src.MinWorkingSet;
            dst.MaxWorkingSet = (ulong)src.MaxWorkingSet;
            dst.Affinity = (ulong)src.ProcessorAffinity;
            dst.StartTime = src.StartTime;
            dst.TotalRuntime = src.TotalProcessorTime;
            dst.UserRuntime = src.UserProcessorTime;
            dst.ImagePath = FS.path(src.MainModule.FileName);
            dst.MemorySize = src.MainModule.ModuleMemorySize;
            dst.ImageVersion = ((uint)src.MainModule.FileVersionInfo.FileMajorPart, (uint)src.MainModule.FileVersionInfo.FileMinorPart);
            dst.EntryAddress = src.MainModule.EntryPointAddress;
            dst.VirtualSize = src.VirtualMemorySize64;
            dst.MaxVirtualSize = src.PeakVirtualMemorySize64;
            return ref dst;
        }

        public static void EmitHashes(in ProcessContext src, IApiPack pack)
        {
            ProcessTargets dst = pack.Root;
            ProcessMemory.EmitHashes(MemoryStores.summarize(src).Addresses,
                dst.ProcessPartitionHashPath(src.ProcessName, src.Timestamp, src.Subject));
            ProcessMemory.EmitHashes(MemoryStores.load(src).Addresses,
                dst.MemoryRegionHashPath(src.ProcessName, src.Timestamp, src.Subject));
        }

        public static Index<AddressHash> EmitHashes(ReadOnlySpan<MemoryAddress> addresses, FS.FilePath dst)
        {
            var count = (uint)addresses.Length;
            var buffer = alloc<AddressHash>(count);
            MemoryStores.hash(addresses,buffer);
            Tables.emit(@readonly(buffer), dst);
            return buffer;
        }
    }
}
