//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        public static Index<Document> docs(WsContext context, bool pll = true)
        {
            var dst = bag<Document>();
            iter(sources(context), src =>
            {
                var s = summary(context,datafile(context,src));
                dst.Add(new Document(s, detail(s)));
            },
            pll);
            return dst.Index();
        }
    }
}