//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmObjects
    {
        public static Index<ObjBlock> blocks(FS.FilePath path)
        {
            var lines = path.ReadLines(true);
            var reader = lines.Reader();
            reader.Next();
            var buffer = alloc<ObjBlock>(lines.Length - 1);
            var i=0u;
            while(reader.Next(out var line))
            {
                var cells = text.split(line,Chars.Pipe);
                Require.equal(ObjBlock.FieldCount, cells.Length);
                ref var dst = ref seek(buffer,i++);
                var src = cells.Reader();
                DataParser.parse(src.Next(), out dst.Seq).Require();
                DataParser.parse(src.Next(), out dst.BlockNumber).Require();
                DataParser.parse(src.Next(), out dst.OriginId).Require();
                DataParser.parse(src.Next(), out dst.BlockName).Require();
                DataParser.parse(src.Next(), out dst.BlockAddress).Require();
                DataParser.parse(src.Next(), out dst.BlockSize).Require();
                DataParser.parse(src.Next(), out dst.Source).Require();
            }
            return buffer;
        }

        public static Index<ObjBlock> blocks(Index<ObjDumpRow> src)
        {
            src.Sort();
            var count = src.Count;
            var seq = 0u;
            var docid = 0u;
            var docname = EmptyString;
            var blockname = EmptyString;
            var @base = MemoryAddress.Zero;
            var dst = list<ObjBlock>();
            var size = 0u;
            var number = 0u;
            var source = FS.FileUri.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref src[i];
                if(i==0)
                {
                    docid = row.OriginId;
                    blockname = row.BlockName;
                    source = row.Source;
                    docname = row.Source.Path.FileName.Format();
                    @base = row.BlockAddress;
                }

                if(row.BlockName != blockname)
                {
                    var block = new ObjBlock();
                    block.Seq = seq++;
                    block.OriginId = docid;
                    block.BlockAddress = @base;
                    block.BlockName = blockname;
                    block.BlockNumber = number++;
                    block.BlockSize = size;
                    block.Source = source;
                    dst.Add(block);
                    size = 0;
                    source = row.Source;
                }

                if(row.OriginId != docid)
                    number = 0;

                docid = row.OriginId;
                blockname = row.BlockName;
                docname = row.Source.Path.FileName.Format();
                @base = row.BlockAddress;
                size += row.Size;

                if(i==count-1)
                {
                    var block = new ObjBlock();
                    block.Seq = seq++;
                    block.OriginId = docid;
                    block.BlockName = blockname;
                    block.BlockAddress = @base;
                    block.BlockNumber = number++;
                    block.Source = source;
                    block.BlockSize = size;
                    dst.Add(block);
                }
            }

            return dst.ToArray();
        }
    }
}