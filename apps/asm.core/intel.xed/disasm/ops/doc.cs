//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public static Index<Document> docs(WsContext context)
            => details(summaries(context)).Entries.Map(x => new Document(x.Key,x.Value)).ToArray();
    }
}