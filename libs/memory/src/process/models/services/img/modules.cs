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
        public static MemoryAddress @base(Assembly src)
            => @base(Path.GetFileNameWithoutExtension(src.Location));

        [MethodImpl(Inline), Op]
        public static MemoryAddress @base(string procname)
        {
            var module = ImageMemory.modules(Process.GetCurrentProcess()).Where(m => Path.GetFileNameWithoutExtension(m.ImagePath.Name) == procname).First();
            return module.BaseAddress;
        }

        [Op]
        public static ReadOnlySeq<ProcessModuleRow> modules(Process src)
        {
            var modules = src.Modules.Cast<System.Diagnostics.ProcessModule>().Array();
            var count = modules.Length;
            var buffer = alloc<ProcessModuleRow>(count);
            fill(modules, buffer);
            return buffer.Sort().Resequence();
        }

        [MethodImpl(Inline), Op]
        static void fill(ReadOnlySpan<System.Diagnostics.ProcessModule> src, Span<ProcessModuleRow> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                fill(i,skip(src,i), ref seek(dst,i));
        }

        [MethodImpl(Inline), Op]
        static ref ProcessModuleRow fill(uint seq, System.Diagnostics.ProcessModule src, ref ProcessModuleRow dst)
        {
            dst.Seq = seq;
            dst.ImageName = src.ModuleName;
            dst.BaseAddress = src.BaseAddress;
            dst.EntryAddress = src.EntryPointAddress;
            dst.MaxAddress = dst.BaseAddress + src.ModuleMemorySize;
            dst.MemorySize = src.ModuleMemorySize;
            dst.Version = ((uint)src.FileVersionInfo.FileMajorPart, (uint)src.FileVersionInfo.FileMinorPart);
            dst.ImagePath = FS.path(src.FileName);
            return ref dst;
        }
    }
}