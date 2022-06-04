//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    using static core;

    using PCK = ProcessContextFlag;

    public partial class Runtime : AppService<Runtime>
    {
        DumpArchive Dumps => Wf.DumpArchive();

        AppSvcOps AppSvc => Wf.AppSvc();

        public Timestamp EmitContext()
        {
            var ts = core.timestamp();
            var archive = Dumps;
            var process = Process.GetCurrentProcess();
            var summaries = EmitPartitions(process, ts);
            var details = EmitRegions(process, ts);
            EmitDump(process, archive.DumpPath(process, ts));
            return ts;
        }

        public void EmitRegions(Timestamp ts, Index<ProcessMemoryRegion> src)
            => AppSvc.TableEmit(src, Dumps.Table<ProcessMemoryRegion>("regions", ts));

        public ProcAddresses EmitSegments(Timestamp ts)
            => EmitSegments(ts, ImageMemory.regions());

        public ProcAddresses EmitSegments(Timestamp ts, Index<ProcessMemoryRegion> src)
        {
            var addresses = ImageMemory.addresses(src);
            AppSvc.TableEmit(addresses.Segments, Dumps.Table<ProcessSegment>("segments", ts));
            return addresses;
        }

        public ProcessTargets ContextPaths {get; private set;}

        protected override void OnInit()
        {
            ContextPaths = Db.CaptureContextRoot();
        }

        public ProcessContext Emit(FS.FolderPath dst, Timestamp ts, Identifier subject = default, PCK flag = PCK.All)
        {
            ContextPaths = dst;

            var selection = ImageMemory.flags(flag);
            if(selection.IsEmpty)
            {
                Wf.Warn("No options have been specified");
                return default;
            }

            var flow = Wf.Running(string.Format("Emitting process context with options {0}", flag));
            var context = new ProcessContext();
            var process = Process.GetCurrentProcess();
            var name = process.ProcessName;
            subject = text.ifempty(subject,"none");
            context.ProcessId = process.Id;
            context.ProcessName = process.ProcessName;
            context.Timestamp = ts;
            context.Subject = subject;
            if(selection.EmitSummary)
            {
                context.PartitionPath = ContextPaths.ProcessPartitionPath(process, ts);
                context.Partitions = EmitPartitions(process, context.PartitionPath);
            }
            if(selection.EmitDetail)
            {
                context.RegionPath = ContextPaths.MemoryRegionPath(process, ts);
                context.Regions = EmitRegions(process, context.RegionPath);
            }
            if(selection.EmitDump)
            {
                context.DumpPath = Dumps.DumpPath(process, ts);
                EmitDump(process, context.DumpPath);
            }
            if(selection.EmitHashes)
            {
                ContextPaths = dst;
                ImageMemory.EmitHashes(context, dst);
            }

            Wf.Ran(flow,"Emitted process context");
            return context;
        }

        public void EmitProcessContext(IApiPack pack)
        {
            var flow = Wf.Running("Emitting process context");
            var ts = pack.Timestamp;
            if(!ts.IsNonZero)
                ts = now();

            var dir = pack.Archive().ContextRoot();
            var process = Process.GetCurrentProcess();
            var procparts = EmitPartitions(process, ts, dir);
            var regions = EmitRegions(process, ts, dir);
            EmitDump(process, pack.ProcDumpPath(process, ts));
            Wf.Ran(flow);
        }

        public Count EmitDump(Process process, FS.FilePath dst)
        {
            var dumping = Wf.EmittingFile(dst.CreateParentIfMissing());
            DumpEmitter.emit(process, dst.Format(PathSeparator.BS), DumpTypeOption.Full);
            Wf.EmittedFile(dumping,1);
            return 1;
        }

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
   }
}