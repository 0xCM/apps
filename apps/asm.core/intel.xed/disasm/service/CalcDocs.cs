//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;
    using static XedDisasmModels;

    partial class XedDisasmSvc
    {
        public Document CalcDoc(WsContext context, in FileRef src)
            => XedDisasm.doc(context, src);

        public Index<Document> CalcDocs(WsContext context)
            => Data(nameof(CalcDocs), () => XedDisasm.docs(context));
    }
}