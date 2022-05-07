//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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

        static IProduction production(string src, string dst)
        {
            if(text.fenced(dst, RenderFence.Bracketed))
            {
                var content = text.unfence(dst, RenderFence.Bracketed);
                var terms = map(text.trim(text.split(content,Chars.Pipe)), x => RuleText.value(x));
                return new ListProduction(RuleText.value(text.trim(src)), new SeqExpr(terms));
            }
            else if(text.fenced(dst, RenderFence.Angled))
            {
                var content = text.unfence(dst, RenderFence.Angled);
                var terms = map(text.trim(text.split(content,Chars.Pipe)), x => RuleText.value(x));
                return new ListProduction(RuleText.value(text.trim(src)), new SeqExpr(terms));
            }
            else
                return new Production(RuleText.value(text.trim(src)), RuleText.value(text.trim(dst)));
        }
    }
}