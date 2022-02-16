//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class ProjectCmdProvider
    {
        [CmdOp("asm/dw")]
        Outcome AsmDw(CmdArgs args)
        {
            //var src = ObjDump.LoadRows()
            var project = Project();
            var path = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var src = ObjDump.LoadRows(path);
            var count = src.Count;
            var collector = new AsmBlockCollector();
            for(var i=0; i<count; i++)
            {
                collector.Include(src[i]);
            }

            var blocks = collector.Emit();
            Allocate(blocks);
            return true;
        }

        void Allocate(ReadOnlySpan<AsmBlockEncoding> src)
        {
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var block = ref skip(src,i);
                ref readonly var name = ref block.BlockName;
                ref readonly var address = ref block.BlockAddress;
                var encodings = block.Encoded;
                var count = encodings.Count;
                for(var j=0; j<count; j++)
                {
                    ref readonly var encoding = ref encodings[j];
                    ref readonly var ip = ref encoding.IP;
                    ref readonly var code = ref encoding.Code;
                    ref readonly var asm = ref encoding.Asm;
                    var size = code.Size;
                    //Write(string.Format("{0,-24} | {1,-8} | {2,-8} | {3,-8} | {4,-24} | {5}", name, address, ip, size, code, asm));
                }
            }
        }
    }

    public class AsmBlockCollector
    {
        Identifier BlockName;

        MemoryAddress BlockAddress;

        List<AsmEncoding> Encodings;

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
            {
                Blocks.Clear();
            }
            return blocks;
        }

        static AsmEncoding encoding<T>(in T src)
            where T : IAsmBlockSegment
        {
            var encoding = new AsmEncoding();
            encoding.Seq = src.Seq;
            encoding.IP = src.IP;
            encoding.Asm = src.Asm;
            encoding.Code = src.Code.Bytes;
            encoding.CT = src.CT;
            return encoding;
        }
    }
}