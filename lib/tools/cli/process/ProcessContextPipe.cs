//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using PCK = ProcessContextFlag;

    public partial class ProcessContextPipe : AppService<ProcessContextPipe>
    {
        public ProcessContextPaths ContextPaths {get; private set;}

        protected override void OnInit()
        {
            ContextPaths = Db.CaptureContextRoot();
        }

        public MemorySymbols SymbolizeDetails(in ProcessContext src)
        {
            var details = src.Regions.View;
            var count = details.Length;
            var symbols = MemorySymbols.alloc(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref skip(details,i);
                symbols.Deposit(detail.StartAddress, detail.Size, detail.Identity.Format());
            }
            return symbols;
        }

        public MemorySymbols SymbolizeSummaries(in ProcessContext src)
        {
            var summaries = src.Partitions.View;
            var count = summaries.Length;
            var symbols = MemorySymbols.alloc(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var summary = ref skip(summaries,i);
                symbols.Deposit(summary.BaseAddress, summary.Size, summary.ImageName.Format());
            }
            return symbols;
        }

        public void EmitHashes(in ProcessContext src, FS.FolderPath dst)
        {
            ContextPaths = dst;
            var summaries = SymbolizeSummaries(src);
            var summarypath = ContextPaths.ProcessPartitionHashPath(src.ProcessName, src.Timestamp, src.Subject);
            EmitHashes(summaries.Addresses, summarypath);

            var details = SymbolizeDetails(src);
            var detailpath = ContextPaths.MemoryRegionHashPath(src.ProcessName, src.Timestamp, src.Subject);
            EmitHashes(details.Addresses, detailpath);
        }

        public Index<AddressHash> EmitHashes(ReadOnlySpan<MemoryAddress> addresses, FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<AddressHash>(dst);
            var count = (uint)addresses.Length;
            var buffer = alloc<AddressHash>(count);
            MemorySymbols.hash(addresses,buffer);
            Tables.emit(@readonly(buffer), dst);
            Wf.EmittedTable(flow, count);
            return buffer;
        }

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

        public ProcessContext Emit(FS.FolderPath dst, Timestamp ts, Identifier subject = default, PCK flag = PCK.All)
        {
            ContextPaths = dst;

            var selection = flags(flag);
            if(selection.IsEmpty)
            {
                Wf.Warn("No options have been specified");
                return default;
            }

            var flow = Wf.Running(string.Format("Emitting process context with options {0}", flag));
            var context = new ProcessContext();
            var process = Runtime.CurrentProcess;
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
                context.DumpPath = Db.DumpPath(dst, process, ts);
                EmitDump(process, context.DumpPath);
            }
            if(selection.EmitHashes)
            {
                EmitHashes(context, dst);
            }

            Wf.Ran(flow,"Emitted process context");
            return context;
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
            var regions = LoadRegions();
            var worker = Wf.RegionProcessor();
            worker.Submit(regions);
            ref readonly var product = ref worker.Bank;
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
            {
                ref readonly var region = ref skip(addresses,i);
                writer.WriteLine(formatter.Format(region));
            }
        }
   }
}