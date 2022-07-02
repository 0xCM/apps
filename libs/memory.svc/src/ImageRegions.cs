//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static core;

    [Free]
    public class ImageRegions : WfSvc<ImageRegions>
    {
        DumpArchive Dumps => Wf.DumpArchive();

        public ProcessTargets ContextPaths {get; private set;}

        protected override void OnInit()
        {
            ContextPaths = new ProcessTargets(AppDb.DbCapture().Root);
        }

        public void EmitRegions(Timestamp ts, Index<ProcessMemoryRegion> src)
            => TableEmit(src, Dumps.Table<ProcessMemoryRegion>("regions", ts));

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
                    Error(result.Message);
            }
            return sys.empty<ProcessMemoryRegion>();
        }

        public Outcome<Index<ProcessMemoryRegion>> LoadRegions(FS.FilePath src)
        {
            var tid = Tables.identify<ProcessMemoryRegion>();
            var flow = Running(string.Format("Reading {0} records from {1}", tid, src.ToUri()));
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

                var result = ImageMemory.parse(line.Content, out seek(dst,i));
                if(!result)
                    return result;

                counter++;
            }
            Ran(flow, string.Format("Read {0} {1} records from {2}", counter, tid, src.ToUri()));
            return (true,buffer);
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

        public static ProcAddresses addresses(ReadOnlySpan<ProcessMemoryRegion> src)
        {
            var processor = new RegionProcessor();
            processor.Include(src);
            return processor.Complete();
        }

        [Op, MethodImpl(Inline)]
        public static Traverser traverser(ReadOnlySpan<ProcessMemoryRegion> src, bool live)
            => new Traverser(src, live);

        [Op, MethodImpl(Inline)]
        public static unsafe ByteSize run(Traverser traverser, delegate* unmanaged<in ProcessMemoryRegion,void> dst)
            => traverser.Traverse(dst);

        [Op]
        public static unsafe Index<ProcessMemoryRegion> filter(ReadOnlySpan<ProcessMemoryRegion> src, PageProtection protect)
        {
            var dst  = alloc<ProcessMemoryRegion>((uint)src.Length);
            var filter = new MemoryRegionFilter(dst, protect);
            var size = traverser(src,false).Traverse(filter);
            return filter.Emit();
        }

        public readonly ref struct Traverser
        {
            readonly ReadOnlySpan<ProcessMemoryRegion> Regions;

            readonly bool IsLive;

            [MethodImpl(Inline)]
            public Traverser(ReadOnlySpan<ProcessMemoryRegion> src, bool live)
            {
                Regions = src;
                IsLive = live;
            }

            [MethodImpl(Inline), Op]
            public ByteSize Traverse(IReceiver<ProcessMemoryRegion> dst)
            {
                var size = ByteSize.Zero;
                var src = Regions;
                var count = src.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var region = ref skip(src,i);
                    dst.Deposit(region);
                    size += region.Size;
                }
                return size;
            }

            [MethodImpl(Inline), Op]
            public unsafe ByteSize Traverse(delegate* unmanaged<in ProcessMemoryRegion,void> dst)
            {
                var size = ByteSize.Zero;
                var src = Regions;
                var count = src.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var region = ref skip(src,i);
                    dst(region);
                    size += region.Size;
                }
                return size;
            }
        }

        unsafe struct MemoryRegionFilter : IReceiver<ProcessMemoryRegion>
        {
            readonly Index<ProcessMemoryRegion> Accepted;

            readonly PageProtection Protection;

            uint Position;

            [MethodImpl(Inline)]
            public MemoryRegionFilter(Index<ProcessMemoryRegion> dst, PageProtection protection)
            {
                Accepted = dst;
                Protection = protection;
                Position = 0;
            }

            [MethodImpl(Inline)]
            public void Deposit(in ProcessMemoryRegion src)
            {
                if((src.Protection & Protection) != 0)
                {
                    Accepted[Position++] = src;
                }
            }

            public Index<ProcessMemoryRegion> Emit()
                => Accepted;
        }

    }
}