//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    partial class ApiComments
    {
        static Fence<string> SummaryFence = RenderFence.define("<summary>", "</summary>");

        public readonly struct Summary
        {
            public static bool parse(string src, out Summary dst)
            {
                var result = false;
                dst = Empty;
                if(text.fenced(src, SummaryFence))
                {
                    var data = text.unfence(src, SummaryFence);
                    if(nonempty(data))
                    {
                        var content = text.trim(text.unfence(src, SummaryFence));
                        iter(Replacements, kvp => content = text.replace(content, kvp.Key, kvp.Value));
                        dst = new (map(content.Lines(), x=> x.Content).Concat(Chars.Eol));
                        result = true;
                    }
                }
                return result;
            }

            public readonly string Content;

            [MethodImpl(Inline)]
            public Summary(string content)
            {
                Content = content;
            }

            public string Format()
                => Content;

            public override string ToString()
                => Content;

            public static Summary Empty => new Summary(EmptyString);
        }
    }
}