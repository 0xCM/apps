//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ImageMemory
    {
        static FS.FileUri Nul => FS.FolderPath.Empty +  FS.file("dev",FS.ext("null"));

        public static Index<ProcessMemoryRegion> pages(ReadOnlySpan<MemoryRangeInfo> src)
        {
            var count = src.Length;
            var buffer = alloc<ProcessMemoryRegion>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                fill(skip(src,i), i, out seek(dst,i));
            return buffer;
        }

        static ref ProcessMemoryRegion fill(in MemoryRangeInfo src, uint index, out ProcessMemoryRegion dst)
        {
            var owner = src.Owner;
            dst.Index = index;
            if(text.nonempty(owner))
            {
                dst.Path = FS.path(owner);
                if(owner.Contains("."))
                    dst.Name = Path.GetFileName(owner);
                else
                    dst.Name = owner.Substring(0, min(owner.Length, 12));
            }
            else
            {
                dst.Name = "unknown";
                dst.Path = Nul;
            }

            dst.StartAddress = src.StartAddress;
            dst.EndAddress = src.EndAddress;
            dst.Size = src.Size;
            dst.Protection = src.Protection;
            dst.Type = src.Type;
            dst.State = src.State;
            return ref dst;
        }
    }
}