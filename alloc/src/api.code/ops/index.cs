//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        public static Outcome index(FS.FilePath src, out Index<EncodedMember> dst)
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
    }
}