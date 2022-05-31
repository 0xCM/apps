//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        public void EmitFieldReport(WsContext context, Document src)
            => EmitFieldReport(context, src.Detail);

        void EmitFieldReport(WsContext context, Detail src)
        {
            var emitter = new FieldEmitter();
            var dst = text.emitter();
            var count = emitter.EmitFields(src, dst);
            AppSvc.FileEmit(dst.Emit(), count, DisasmFieldsPath(context, src.Source));
        }
    }
}