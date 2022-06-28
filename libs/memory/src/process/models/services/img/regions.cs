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
        public static Index<ProcessMemoryRegion> regions()
            => pages(MemoryNode.snapshot().Describe());

        [Op]
        public static Index<ProcessMemoryRegion> regions(int procid)
            => pages(MemoryNode.snapshot(procid).Describe());

        [Op]
        public static Index<ProcessMemoryRegion> regions(Process src)
            => pages(MemoryNode.snapshot(src.Id).Describe());
    }
}