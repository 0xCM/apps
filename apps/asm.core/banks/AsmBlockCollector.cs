//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class AsmBlockCollector
    {
        Identifier BlockName;

        MemoryAddress BlockAddress;

        List<AsmEncodingRecord> Encodings;

        List<AsmBlockEncoding> Blocks;

        public AsmBlockCollector()
        {
            BlockName = Identifier.Empty;
            BlockAddress = MemoryAddress.Zero;
            Encodings = new();
            Blocks = new();
        }

        public void Include<T>(in T src)
            where T : IAsmBlockSegment
        {
            var name = src.BlockName;
            if(BlockName.IsEmpty)
            {
                BlockName = name;
                BlockAddress = src.BlockAddress;
            }
            else
            {
                if(name == BlockName)
                    Require.equal(BlockAddress, src.BlockAddress);
                else
                {
                    Blocks.Add(new AsmBlockEncoding(BlockName, BlockAddress, Encodings.ToArray()));
                    BlockName = src.BlockName;
                    BlockAddress = src.BlockAddress;
                    Encodings.Clear();
                }
            }
            Encodings.Add(encoding(src));
        }

        void IncludeBlock(bool clear = true)
        {
            Blocks.Add(new AsmBlockEncoding(BlockName, BlockAddress, Encodings.ToArray()));
            if(clear)
            {
                BlockName = Identifier.Empty;
                BlockAddress = MemoryAddress.Zero;
                Encodings.Clear();
            }
        }

        public Index<AsmBlockEncoding> Emit(bool clear = true)
        {
            if(Encodings.Count != 0)
                IncludeBlock(clear);
            var blocks = Blocks.ToArray();
            if(clear)
                Blocks.Clear();
            return blocks;
        }

        static AsmEncodingRecord encoding<T>(in T src)
            where T : IAsmBlockSegment
        {
            var encoding = new AsmEncodingRecord();
            encoding.Seq = src.Seq;
            encoding.Id = src.Id;
            encoding.IP = src.IP;
            encoding.Encoded = src.Encoded.Bytes;
            encoding.Size = src.Size;
            encoding.Asm = src.Asm;
            return encoding;
        }
    }
}