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
        public static ReadOnlySeq<ProcessPartition> partitions(ReadOnlySeq<ImageLocation> src)
        {
            var count = src.Count;
            var buffer = alloc<ProcessPartition>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var image = ref src[i];
                ref var dst = ref seek(buffer,i);
                dst.MinAddress = image.BaseAddress;
                dst.MaxAddress = image.EndAddress;
                dst.Size = image.Size;
                dst.ImageName = image.Name;
            }

            return buffer.Sort();
        }
    }
}