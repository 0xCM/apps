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

        DumpArchive Dumps => Wf.DumpArchive();

        public ProcAddresses EmitSegments(Timestamp ts)
            => EmitSegments(ts, ImageMemory.regions());

        public ProcAddresses EmitSegments(Timestamp ts, Index<ProcessMemoryRegion> src)
        {
            var addresses = ImageMemory.addresses(src);
            TableEmit(addresses.Segments, Dumps.Table<ProcessSegment>("segments", ts));
            return addresses;
        }

        public void EmitRegions(Timestamp ts, Index<ProcessMemoryRegion> src)
            => TableEmit(src, Dumps.Table<ProcessMemoryRegion>("regions", ts));

        public ReadOnlySpan<AddressBankEntry> LoadContextAddresses()
        {
            var worker = new RegionProcessor();
            worker.Include(LoadRegions());
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

        public void EmitContextSummary(FS.FilePath dst)
        {
            var addresses = LoadContextAddresses();
            var formatter = Tables.formatter<AddressBankEntry>(14);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            var count = addresses.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(addresses,i)));
        }

        public Index<ProcessMemoryRegion> LoadRegions()
        {
            var paths = ContextPaths.MemoryRegionPaths();
            if(paths.Length != 0)
            {
                var path = paths[paths.Length - 1];
                var result = LoadRegions(path);
                if(result)
                    return result.Data;
                else
                    Wf.Error(result.Message);
            }
            return sys.empty<ProcessMemoryRegion>();
        }

        public Outcome<Index<ProcessMemoryRegion>> LoadRegions(FS.FilePath src)
        {
            var tid = Tables.identify<ProcessMemoryRegion>();
            var flow = Wf.Running(string.Format("Reading {0} records from {1}", tid, src.ToUri()));
            if(!src.Exists)
                return (false, FS.Msg.DoesNotExist.Format(src));
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            if(count == 0)
            {
                return (false,"No data");
            }

            ref readonly var header = ref lines.First;
            var cells = header.Split(Chars.Pipe);
            if(cells.Length != ProcessMemoryRegion.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(cells.Length, ProcessMemoryRegion.FieldCount));

            var data = slice(lines.View,1);
            var buffer = alloc<ProcessMemoryRegion>(data.Length);
            ref var dst = ref first(buffer);
            var counter = 0;
            for(var i=0; i<data.Length; i++)
            {
                ref readonly var line = ref skip(data,i);
                if(line.IsEmpty)
                    continue;

                var result = ProcessMemory.parse(line.Content, out seek(dst,i));
                if(!result)
                    return result;

                counter++;
            }
            Wf.Ran(flow, string.Format("Read {0} {1} records from {2}", counter, tid, src.ToUri()));
            return (true,buffer);
        }

        public Index<ProcessPartition> EmitPartitions(Process process, FS.FilePath dst)
        {
            var summaries = ImageMemory.partitions(ImageMemory.images(process));
            EmitPartitions(summaries, dst);
            return summaries;
        }

        public Index<ProcessPartition> EmitPartitions(Process process, Timestamp ts)
        {
            var memory = ImageMemory.images(process);
            var summaries = ImageMemory.partitions(memory);
            var dst = ContextPaths.ProcessPartitionPath(process, ts);
            EmitPartitions(summaries, dst);
            return summaries;
        }

        public Index<ProcessPartition> EmitPartitions(Process process, Timestamp ts, FS.FolderPath dir)
        {
            var memory = ImageMemory.images(process);
            var summaries = ImageMemory.partitions(ImageMemory.images(process));
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

        public static void load(FS.FilePath src)
            => HexCsv.read(src);

        [Op]
        public static MemoryAddress @base(Assembly src)
            => @base(Path.GetFileNameWithoutExtension(src.Location));

        [MethodImpl(Inline), Op]
        public static MemoryAddress @base(Name procname)
        {
            var match =  procname.Content;
            var module = ImageMemory.modules(Process.GetCurrentProcess()).Where(m => Path.GetFileNameWithoutExtension(m.ImagePath.Name) == match).First();
            return module.BaseAddress;
        }

        public static Outcome parse(string src, out ProcessMemoryRegion dst)
        {
            dst = default;
            if(text.empty(src))
                return false;

            var count = ProcessMemoryRegion.FieldCount;
            var parts = text.split(src,Chars.Pipe);
            if(parts.Length != ProcessMemoryRegion.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(parts.Length, count));

            var buffer = alloc<Outcome>(count);
            ref var outcomes = ref first(buffer);

            var i=0;
            var j=0;
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.Index);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.Identity);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.StartAddress);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.EndAddress);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.Size);
            seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.Type);
            seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.Protection);
            seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.State);
            seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.FullIdentity);
            return true;
        }

        [Op]
        public static Index<ProcessPartition> emit(Index<LocatedImageInfo> src, FS.FilePath dst)
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

        [MethodImpl(Inline), Op]
        public static ref ProcessSegment segment(in ProcessMemoryRegion src, ref ProcessSegment dst)
        {
            dst.Index = src.Index;
            dst.Selector = src.StartAddress.Quadrant(n2);
            dst.Base = src.StartAddress.Lo;
            dst.Size = src.Size;
            dst.PageCount = src.Size/PageSize;
            dst.Range = (src.StartAddress, src.EndAddress);
            dst.Type = src.Type;
            dst.Protection = src.Protection;
            dst.Label = src.Identity.Format();
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ProcessModuleRow fill(ProcessModule src, ref ProcessModuleRow dst)
        {
            dst.ImageName = src.ModuleName;
            dst.BaseAddress = src.BaseAddress;
            dst.EntryAddress = src.EntryPointAddress;
            dst.ImagePath = FS.path(src.FileName);
            dst.MemorySize = src.ModuleMemorySize;
            dst.Version = ((uint)src.FileVersionInfo.FileMajorPart, (uint)src.FileVersionInfo.FileMinorPart);
            return ref dst;
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

        public static void EmitHashes(in ProcessContext src, FS.FolderPath dir)
        {
            ProcessTargets dst = dir;
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
