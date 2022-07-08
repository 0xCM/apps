//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    partial class ImageMemory
    {
        [Op]
        public static ReadOnlySpan<ProcessModule> modules()
            => modules((ProcessAdapter)Process.GetCurrentProcess());

        [Op]
        public static ReadOnlySpan<ProcessModule> modules(ProcessAdapter src)
            => src.Modules.OrderBy(x => x.BaseAddress).Array();

        public static Index<ProcessModuleRow> modules(FS.FilePath src)
        {
            using var reader = src.AsciLineReader();
            var line = AsciLineCover.Empty;
            reader.Next(out line);
            while(reader.Next(out line))
            {

            }

            return default;
        }
        [Op]
        public static ReadOnlySeq<ProcessModuleRow> modules(Process src)
        {
            var modules = src.Modules.Cast<System.Diagnostics.ProcessModule>().Array();
            var count = modules.Length;
            var buffer = alloc<ProcessModuleRow>(count);
            fill(modules, buffer);
            return buffer.Sort();
        }

        [MethodImpl(Inline), Op]
        static void fill(ReadOnlySpan<System.Diagnostics.ProcessModule> src, Span<ProcessModuleRow> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                fill(skip(src,i), ref seek(dst,i));
        }

        [MethodImpl(Inline), Op]
        static ref ProcessModuleRow fill(System.Diagnostics.ProcessModule src, ref ProcessModuleRow dst)
        {
            dst.ImageName = src.ModuleName;
            dst.BaseAddress = src.BaseAddress;
            dst.EntryAddress = src.EntryPointAddress;
            dst.ImagePath = FS.path(src.FileName);
            dst.MemorySize = src.ModuleMemorySize;
            dst.Version = ((uint)src.FileVersionInfo.FileMajorPart, (uint)src.FileVersionInfo.FileMinorPart);
            return ref dst;
        }
    }
}