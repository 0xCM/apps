//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;
    using System.Diagnostics;

    using static core;

    using PCK = ProcessContextFlag;

    [ApiHost]
    public readonly struct ImageMemory
    {
        [MethodImpl(Inline)]
        public static bit enabled(PCK src, PCK flag)
            => (src & flag) != 0;

        [MethodImpl(Inline)]
        public static ProcessContextFlags flags(PCK src)
        {
            var options = new ProcessContextFlags();
            options.EmitSummary = enabled(src,PCK.Summary);
            options.EmitDetail= enabled(src,PCK.Detail);
            options.EmitDump= enabled(src,PCK.Dump);
            options.EmitHashes = enabled(src,PCK.Hashes);
            return options;
        }

        public static MemorySymbols SymbolizeDetails(in ProcessContext src)
        {
            var details = src.Regions.View;
            var count = details.Length;
            var symbols = MemorySymbols.create(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref skip(details,i);
                symbols.Deposit(detail.StartAddress, detail.Size, detail.Identity.Format());
            }
            return symbols;
        }

        public static void EmitHashes(in ProcessContext src, FS.FolderPath dir)
        {
            ProcessContextPaths dst = dir;
            EmitHashes(ImageMemory.SymbolizeSummaries(src).Addresses,
                dst.ProcessPartitionHashPath(src.ProcessName, src.Timestamp, src.Subject));
            EmitHashes(ImageMemory.SymbolizeDetails(src).Addresses,
                dst.MemoryRegionHashPath(src.ProcessName, src.Timestamp, src.Subject));
        }

        public static MemorySymbols SymbolizeSummaries(in ProcessContext src)
        {
            var summaries = src.Partitions.View;
            var count = summaries.Length;
            var symbols = MemorySymbols.create(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var summary = ref skip(summaries,i);
                symbols.Deposit(summary.BaseAddress, summary.Size, summary.ImageName.Format());
            }
            return symbols;
        }

        public static Index<AddressHash> EmitHashes(ReadOnlySpan<MemoryAddress> addresses, FS.FilePath dst)
        {
            var count = (uint)addresses.Length;
            var buffer = alloc<AddressHash>(count);
            MemorySymbols.hash(addresses,buffer);
            Tables.emit(@readonly(buffer), dst);
            return buffer;
        }


        public static ProcAddresses addresses(ReadOnlySpan<ProcessMemoryRegion> src)
        {
            var processor = new RegionProcessor();
            processor.Include(src);
            return processor.Complete();
        }

        [MethodImpl(Inline), Op]
        public static ref ProcessSegment load(in ProcessMemoryRegion src, ref ProcessSegment dst)
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

        [Op]
        public static ProcessImageMap map(Process src)
        {
            var images = locate(src);
            ref readonly var image = ref images.First;
            var count = images.Count;
            Index<MemoryAddress> addresses = alloc<MemoryAddress>(count);
            ref var address = ref addresses.First;
            for(var i=0u; i<count; i++)
                seek(address, i) = skip(image, i).BaseAddress;
            var state = new ProcessMemoryState();
            fill(src, ref state);
            return new ProcessImageMap(state, images, addresses.Sort(), modules(src));
        }

        [Op]
        public static ReadOnlySpan<ProcessModuleAdapter> modules(ProcessAdapter src)
            => src.Modules.OrderBy(x => x.BaseAddress).Array();

        [Op]
        public static ReadOnlySpan<ProcessModuleAdapter> modules()
            => modules((ProcessAdapter)Process.GetCurrentProcess());

        [Op]
        public static ProcessMemoryMap map(ProcessAdapter src)
        {
            var mods = modules(src);
            var count = mods.Length;
            var buffer = core.alloc<ModuleMemory>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var mod = ref skip(mods,i);
                seek(dst,i) = new ModuleMemory(mod.Path.FileName.WithoutExtension.Format(), mod.BaseAddress, mod.ModuleMemorySize);
            }
            var main = src.MainModule;
            return new ProcessMemoryMap(src.ProcessName, (uint)src.Id, main.BaseAddress, main.ModuleMemorySize, buffer);
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
        public static Index<ProcessMemoryRegion> regions()
            => pages(MemoryNode.snapshot().Describe());

        [Op]
        public static Index<ProcessMemoryRegion> regions(int procid)
            => pages(MemoryNode.snapshot(procid).Describe());

        [Op]
        public static Index<ProcessMemoryRegion> regions(Process src)
            => pages(MemoryNode.snapshot(src.Id).Describe());

        public static Index<ProcessMemoryRegion> pages(ReadOnlySpan<MemoryRangeInfo> src)
        {
            var count = src.Length;
            var buffer = alloc<ProcessMemoryRegion>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                fill(skip(src,i), i, out seek(dst,i));
            return buffer;
        }

        public static ref ProcessMemoryRegion fill(in MemoryRangeInfo src, uint index, out ProcessMemoryRegion dst)
        {
            var identity = src.Owner;
            dst.Index = index;
            if(text.nonempty(identity))
            {
                dst.FullIdentity = identity;
                if(identity.Contains("."))
                    dst.Identity = Path.GetFileName(identity);
                else
                    dst.Identity = identity.Substring(0, min(identity.Length, 12));
            }
            else
            {
                dst.Identity = "unknown";
                dst.FullIdentity = "unknown";
            }

            dst.StartAddress = src.StartAddress;
            dst.EndAddress = src.EndAddress;
            dst.Size = src.Size;
            dst.Protection = src.Protection;
            dst.Type = src.Type;
            dst.State = src.State;
            return ref dst;
        }

        [Op]
        public static Index<LocatedImageInfo> locate(Process src)
            => src.Modules.Cast<ProcessModule>().Map(locate).OrderBy(x => x.BaseAddress);

        /// <summary>
        /// Creates a <see cref='LocatedImageInfo'/> description from the main module of the executing <see cref='Process'/>
        /// </summary>
        /// <param name="src">The source module</param>
        public static LocatedImageInfo locate()
            => locate(Process.GetCurrentProcess().MainModule);

        /// <summary>
        /// Creates a <see cref='LocatedImageInfo'/> description from a specified <see cref='ProcessModule'/>
        /// </summary>
        /// <param name="src">The source module</param>
        [Op]
        public static LocatedImageInfo locate(ProcessModule src)
        {
            var part = ApiParsers.partFromFile(src.FileName);
            var entry = (MemoryAddress)src.EntryPointAddress;
            var @base = src.BaseAddress;
            var size = (uint)src.ModuleMemorySize;
            return new LocatedImageInfo(FS.path(src.FileName), part, entry, @base, size);
        }

        [Op]
        public static Index<ProcessModuleRow> modules(Process src)
        {
            var modules = @readonly(src.Modules.Cast<ProcessModule>().Array());
            var count = modules.Length;
            var buffer = alloc<ProcessModuleRow>(count);
            fill(modules, buffer);
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static void fill(ReadOnlySpan<ProcessModule> src, Span<ProcessModuleRow> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                fill(skip(src,i), ref seek(dst,i));
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

        [Op]
        public static MemoryAddress @base(Assembly src)
            => @base(Path.GetFileNameWithoutExtension(src.Location));

        [MethodImpl(Inline), Op]
        public static MemoryAddress @base(Name procname)
        {
            var match =  procname.Content;
            var module = modules(Process.GetCurrentProcess()).Where(m => Path.GetFileNameWithoutExtension(m.ImagePath.Name) == match).First();
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
        public static Index<ProcessPartition> partitions(Index<LocatedImageInfo> src)
        {
            var count = src.Count;
            var images = src.View;
            var buffer = alloc<ProcessPartition>(count);
            var summaries = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var image = ref skip(images, i);
                ref var dst = ref seek(summaries,i);
                dst.BaseAddress = image.BaseAddress;
                dst.EndAddress = image.EndAddress;
                dst.Size = image.Size;
                dst.ImageName = image.Name;

                if(i != 0)
                {
                    ref readonly var prior = ref skip(images, i - 1);
                    var gap = (ulong)(image.BaseAddress - prior.EndAddress);
                    dst.Gap = gap;
                }
            }

            return buffer;
        }

        [Op]
        public static Index<ProcessPartition> emit(Index<LocatedImageInfo> src, FS.FilePath dst)
        {
            var records = partitions(src);
            var target = records.Edit;
            var formatter = Tables.formatter<ProcessPartition>(16);
            var count = records.Length;
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(target,i)));
            return records;
        }
    }
}