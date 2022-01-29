//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Rules
    {
        public static TextMap textmap(FS.FilePath src)
        {
            const string Sep = " -> ";
            var dst = dict<string,string>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var i = line.Index(Sep);
                if(i == NotFound)
                    continue;

                var source = text.left(line.Content,i);
                var target = text.right(line.Content,i + Sep.Length - 1);

                dst[source] = target;
            }
            var lu = dst.ToConstLookup();
            return new TextMap(lu, core.map(lu.Entries, e => production(e.Key, e.Value)));
        }
    }
}