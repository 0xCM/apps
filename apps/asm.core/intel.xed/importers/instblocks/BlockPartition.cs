//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public record struct BlockPartition
    {
        public static BlockPartition calc<W>(ByteSize size, uint count, W w = default)
            where W : unmanaged, IDataWidth
        {
            var dst = new BlockPartition();
            dst.SourceSize = (uint)size;
            dst.BlockSize = (uint)w.DataWidth/8;
            dst.BlockCount = dst.SourceSize/dst.BlockSize;
            dst.BlockRemains = dst.SourceSize%dst.BlockSize;
            dst.BlockedSize = dst.BlockCount*dst.BlockSize;
            dst.BatchCount = count;
            dst.PartCount = dst.BlockCount/dst.BatchCount;
            dst.PartRemains = dst.BlockCount%dst.BatchCount;
            return dst;
        }

        public uint SourceSize;

        public uint BlockSize;

        public uint BlockCount;

        public uint BlockedSize;

        public uint BlockRemains;

        public uint BatchCount;

        public uint PartCount;

        public uint PartRemains;
    }
}