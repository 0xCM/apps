//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial class PeReader
    {
        [Op]
        public unsafe ReadOnlySpan<ResSeg> ReadResSegments()
        {
            var resources = CliReader().ReadResInfo();
            var count = resources.Length;
            var dst = span<ResSeg>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var res = ref skip(resources, i);
                var resdir = ReadSectionData(ResourcesDirectory);
                var blobReader = resdir.GetReader((int)res.Offset, resdir.Length - (int)res.Offset);
                var length = blobReader.ReadUInt32();
                MemoryAddress address = blobReader.CurrentPointer;
                seek(dst,i) = new ResSeg(res.Name, new MemorySeg(address,length));
            }
            return dst;
        }
    }
}