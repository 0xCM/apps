//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using Windows;

    using static core;

    public unsafe class ProcessSegments
    {
        MemoryAddress ProcessBase;

        FS.FolderPath OutDir;

        public ProcessSegments(FS.FolderPath dst)
        {
            OutDir = dst;
            ProcessBase = process().Handle.ToPointer();
        }

        public ProcessSegments(MemoryAddress @base, FS.FolderPath dst)
        {
            OutDir = dst;
            ProcessBase = @base;
        }

        public ByteSize Traverse(ReadOnlySpan<ProcessSegment> src)
        {
            var count = src.Length;
            var total = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                ref readonly var segment = ref skip(src,i);
                using var writer = path(OutDir, segment.Range.Min).BinaryWriter();
                total += emit(segment, writer);
            }

            return total;
        }

        public ByteSize Traverse(ReadOnlySpan<ProcessMemoryRegion> src)
        {
            var count = src.Length;
            var accessible = 0u;
            var total = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                ref readonly var region = ref skip(src,i);
                var @base = region.StartAddress;
                if(@base < ProcessBase)
                    continue;

                if(CanRead(region))
                {
                    accessible++;
                    using var writer = path(OutDir, @base).BinaryWriter();
                    total += emit(region, writer);
                }
            }

            return total;
         }

        [Op]
        static ByteSize emit(in ProcessSegment src, BinaryWriter dst)
        {
            var storage = z8;
            var total = ByteSize.Zero;
            var @base = src.Range.Min;
            var reader = MemoryReader.create(@base.Pointer<byte>(), src.Size);
            while(reader.Read(ref storage))
            {
                dst.Write(storage);
                total++;
            }
            return total;
        }

        static ByteSize emit(in ProcessMemoryRegion src, BinaryWriter dst)
        {
            var storage = z8;
            var total = ByteSize.Zero;
            var @base = src.StartAddress;
            var reader = MemoryReader.create(@base.Pointer<byte>(), src.Size);
            while(reader.Read(ref storage))
            {
                dst.Write(storage);
                total++;
            }
            return total;
        }

        static FS.FilePath path(FS.FolderPath dir, MemoryAddress @base)
            => dir + FS.file(string.Format("x{0}", @base.Format()), FS.Bin);

        [MethodImpl(Inline)]
        static bool CanRead(PageProtection src, MemState state)
            => (src == PageProtection.Readonly
            || src == PageProtection.ExecuteRead
            || src == PageProtection.ExecuteReadWrite
            || src == PageProtection.ReadWrite) && state == MemState.Committed;

        [MethodImpl(Inline)]
        static bool CanRead(in ProcessMemoryRegion src)
            => CanRead(src.Protection, src.State);
    }
}