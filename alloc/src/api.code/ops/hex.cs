//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        public static ByteSize hex(Index<CollectedEncoding> src, FS.FilePath dst)
        {
            var options = HexFormatSpecs.options();
            using var writer = dst.AsciWriter();
            var size = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var code = ref src[i].Code;
                writer.WriteLine(code.Format(options));
                size += code.Size;
            }

            return size;
        }

        public static Outcome hex(FS.FilePath src, out BinaryCode dst)
        {
            var result = Outcome.Success;
            var cells = src.ReadLines().SelectMany(x => text.split(x,Chars.Space));
            var count = cells.Count;
            var data = alloc<byte>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref cells[i];
                result = HexParser.parse8u(cell, out seek(data,i));
                if(result.Fail)
                    break;
            }
            if(result)
                dst = data;
            else
                dst = BinaryCode.Empty;
            return result;
        }
    }
}