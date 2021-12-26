//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Concurrent;
    using static Root;

    public sealed class TextMap
    {
        public static TextMap load(FS.FilePath src)
        {
            const string Sep = " -> ";
            var dst = new TextMap();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;
                var i = line.Index(" -> ");
                if(i == NotFound)
                    continue;

                dst.Include(text.left(line.Content,i), text.right(line.Content,i + Sep.Length - 1));
            }
            return dst;
        }

        ConcurrentDictionary<string,string> Data;

        public TextMap()
        {
            Data = new();
        }

        public bool Include(string src, string dst)
            => Data.TryAdd(src,dst);

        public string Apply(string src)
        {
            if(Data.TryGetValue(src, out var dst))
                return dst;
            else
                return src;
        }
    }
}