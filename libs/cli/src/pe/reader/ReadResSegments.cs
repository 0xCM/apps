//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class PeReader
    {
        public ReadOnlySeq<CliString> ReadSystemStringDetail()
        {
            var reader = MD;
            int size = reader.GetHeapSize(HeapIndex.String);
            if (size == 0)
                return array<CliString>();

            var values = list<CliString>();
            var handle = MetadataTokens.StringHandle(0);
            var i=0;
            do
            {
                values.Add(new CliString(seq: i++, size, (Address32)reader.GetHeapOffset(handle), reader.GetString(handle)));
                handle = reader.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return values.ToArray();
        }

        [Op]
        public unsafe ReadOnlySeq<ResSeg> ReadResSegments()
        {
            var resources = CliReader().ReadResInfo();
            var count = resources.Length;
            var dst = sys.alloc<ResSeg>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var res = ref resources[i];
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