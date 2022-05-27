//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        static Outcome load(FS.FilePath src, out Index<EncodedMember> dst)
        {
            var result = Outcome.Success;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            dst = alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
            {
                result = parse(lines[i + 1], out dst[i]);
                if(result.Fail)
                    break;
            }

            return result;
        }

        static Outcome load(FS.FilePath path, out BinaryCode dst)
        {
            var result = Outcome.Success;
            var cells = path.ReadLines().SelectMany(x => text.split(x,Chars.Space));
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