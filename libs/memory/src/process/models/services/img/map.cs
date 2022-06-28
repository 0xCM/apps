//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ImageMemory
    {
        [Op]
        public static ProcessImageMap map(Process src)
        {
            var images = ImageMemory.images(src);
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
        static ref ProcessMemoryState fill(Process src, ref ProcessMemoryState dst)
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
    }
}