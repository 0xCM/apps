//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    using Windows;

    using static Root;
    using static core;

    [ApiHost]
    public unsafe class SegmentTraverser : AppService<SegmentTraverser>
    {
        MemoryAddress ProcessBase;

        public SegmentTraverser()
        {
            ProcessBase = process().Handle.ToPointer();
        }

        public ByteSize Traverse(ReadOnlySpan<ProcessSegment> src, FS.FolderPath outdir)
        {
            var count = src.Length;
            var total = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                ref readonly var segment = ref skip(src,i);
                var @base = segment.Range.Min;
                var dst = BinPath(outdir, @base);
                var emitting = Wf.EmittingFile(dst);
                using var writer = dst.BinaryWriter();
                var outsize = Log(segment, writer);
                Wf.EmittedFile(emitting, (uint)outsize);
                total += outsize;
            }

            return total;
        }

        public ByteSize Traverse(ReadOnlySpan<ProcessMemoryRegion> src, FS.FolderPath outdir)
        {
            var count = src.Length;
            var accessible = 0u;
            var total = ByteSize.Zero;
            var flow = Wf.Running(Msg.TraversingSegments.Format(ProcessBase));

            for(var i=0; i<count; i++)
            {
                ref readonly var region = ref skip(src,i);
                var @base = region.StartAddress;
                if(@base < ProcessBase)
                    continue;

                if(CanRead(region))
                {
                    accessible++;
                    var dst =  BinPath(outdir, @base);
                    var emitting = Wf.EmittingFile(dst);
                    using var writer = dst.BinaryWriter();
                    var outsize = Log(region, writer);
                    Wf.EmittedFile(emitting, (uint)outsize);
                    total += outsize;
                }
            }

            Wf.Ran(flow, Msg.TraversedSegments.Format(total, accessible));
            return total;
         }

        ByteSize Log(in ProcessMemoryRegion src, BinaryWriter dst)
        {
            var description = src.Describe();
            var @base = src.StartAddress;
            var flow = Wf.Running(Msg.TraversingRegion.Format(src));
            var size = Emit(src,dst);
            Wf.Ran(flow, Msg.TraversedRegion.Format(size,src));
            return size;
        }

        ByteSize Log(in ProcessSegment src, BinaryWriter dst)
        {
            var @base = src.Range.Min;
            var flow = Wf.Running(Msg.TraversingRange.Format(src.Range));
            var size = Emit(src,dst);
            Wf.Ran(flow, Msg.TraversedRange.Format(src.Range));
            return size;
        }

        [Op]
        ByteSize Emit(in ProcessSegment src, BinaryWriter dst)
        {
            var @base = src.Range.Min;
            var reader = MemoryReader.create(@base.Pointer<byte>(), src.Size);
            var storage = z8;
            var total = ByteSize.Zero;
            while(reader.Read(ref storage))
            {
                dst.Write(storage);
                total++;
            }
            return total;
        }

        [Op]
        ByteSize Emit(in ProcessMemoryRegion src, BinaryWriter dst)
        {
            var @base = src.StartAddress;
            var reader = MemoryReader.create(@base.Pointer<byte>(), src.Size);
            var storage = z8;
            var total = ByteSize.Zero;
            while(reader.Read(ref storage))
            {
                dst.Write(storage);
                total++;
            }
            return total;
        }

        FS.FileName BinFile(MemoryAddress @base)
            => FS.file(string.Format("x{0}", @base.Format()), FS.Bin);

        FS.FilePath BinPath(FS.FolderPath dir, MemoryAddress @base)
            => dir + BinFile(@base);

        [MethodImpl(Inline), Op]
        bool CanRead(PageProtection src, MemState state)
            => (src == PageProtection.Readonly
            || src == PageProtection.ExecuteRead
            || src == PageProtection.ExecuteReadWrite
            || src == PageProtection.ReadWrite) && state == MemState.Committed;

        [MethodImpl(Inline), Op]
        bool CanRead(in ProcessMemoryRegion src)
            => CanRead(src.Protection, src.State);
    }
}