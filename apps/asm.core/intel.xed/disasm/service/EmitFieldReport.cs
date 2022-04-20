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
            var dst = DisasmFieldsPath(context, src.Source);
            var emitting = EmittingFile(dst);
            var emitter = new FieldEmitter(dst);
            var count = emitter.EmitFields(src);
            EmittedFile(emitting,count);
        }
    }
}