//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class XedDisasm
    {
        public static Index<Document> docs(WsContext context)
            => details(summaries(context)).Entries.Map(x => new Document(x.Key,x.Value)).ToArray();

        static ConstLookup<Summary,Detail> details(Index<Summary> src, bool pll = true)
        {
            var dst = cdict<Summary,Detail>();
            iter(src, doc => dst.TryAdd(doc, new Detail(doc.File, blocks(doc))), pll);
            return dst;
        }
    }
}