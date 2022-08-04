//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ImageMemory
    {
        [Op]
        public static ReadOnlySeq<ProcessModuleRow> modules(ProcessAdapter process)
        {
            var modules = process.Modules;
            var count = modules.Count;
            var buffer = Seq.alloc<ProcessModuleRow>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var src = ref modules[i];
                ref var dst = ref buffer[i];
                dst.Seq = i;
                dst.ImageName = src.ModuleName;
                dst.BaseAddress = src.BaseAddress;
                dst.EntryAddress = src.EntryPointAddress;
                dst.MaxAddress = dst.BaseAddress + src.ModuleMemorySize;
                dst.MemorySize = src.ModuleMemorySize;
                dst.Version = ((uint)src.FileVersionInfo.FileMajorPart, (uint)src.FileVersionInfo.FileMinorPart);
                dst.ImagePath = src.Path;
            }
            return buffer.Sort().Resequence();
        }
    }
}