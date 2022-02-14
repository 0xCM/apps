//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Rules
    {
        public static TextReplace replace(FS.FilePath src)
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
                if(text.fenced(target, RenderFence.SQuote))
                {
                    dst[source] = text.unfence(target, RenderFence.SQuote);
                }
                else
                {
                    dst[source] = target;
                }
            }
            return new TextReplace(dst);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReplaceRule<T> replace<T>(T src, T dst)
            where T : IEquatable<T>
                => new ReplaceRule<T>(src,dst);

        [Op, Closures(Closure)]
        public static Replacements<T> replacements<T>(params Pair<T>[] src)
            where T : IEquatable<T>
        {
            var count = src.Length;
            var buffer = sys.alloc<ReplaceRule<T>>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = new ReplaceRule<T>(skip(src,i).Left, skip(src,i).Right);
            return buffer;
        }
    }
}