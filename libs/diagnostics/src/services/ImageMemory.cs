//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct ImageMemory
    {
        public static ProcAddresses addresses(ReadOnlySpan<ProcessMemoryRegion> src)
        {
            var processor = new RegionProcessor();
            processor.Include(src);
            return processor.Complete();
        }

        [Op]
        public static Index<ProcessMemoryRegion> regions()
            => ProcessMemory.pages(MemoryNode.snapshot().Describe());

        [Op]
        public static Index<ProcessMemoryRegion> regions(int procid)
            => ProcessMemory.pages(MemoryNode.snapshot(procid).Describe());

        [Op]
        public static Index<ProcessMemoryRegion> regions(Process src)
            => ProcessMemory.pages(MemoryNode.snapshot(src.Id).Describe());
    }
}