//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static Index<Document> docs(WsContext context, bool pll = true)
        {
            var dst = bag<Document>();
            iter(sources(context), src => dst.Add(doc(context,src)), pll);
            return dst.Index();
        }

        public static Document doc(WsContext context, in FileRef src)
        {
            var summary = XedDisasm.summary(context, datafile(context, src));
            return new Document(summary, detail(summary));
        }
    }
}