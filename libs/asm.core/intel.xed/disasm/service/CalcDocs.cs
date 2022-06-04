//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        public Index<Document> CalcDocs(WsContext context)
            => Data(nameof(CalcDocs), () => XedDisasm.docs(context));
    }
}