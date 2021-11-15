//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial struct Tables
    {
        public static Outcome list(FS.FilePath src, out ListItem[] dst)
        {
            dst = array<ListItem>();
            var buffer = list<ListItem>();
            using var reader = src.Utf8LineReader();
            if(reader.Next(out var line))
            {
                var header = line.Content.Split(Chars.Pipe);
                if(header.Length < 3)
                    return (false, AppMsg.FieldCountMismatch.Format(header.Length,3));

                while(reader.Next(out line))
                {
                    var result = ListItems.parse(line.Content, out var item);
                    if(result.Fail)
                        return result;
                    buffer.Add(item);
                }
            }

            dst = buffer.ToArray();
            return true;
        }
    }
}