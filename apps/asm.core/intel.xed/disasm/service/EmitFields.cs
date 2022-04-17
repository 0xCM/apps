//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedDisasm;

    partial class XedDisasmSvc
    {
        public void EmitFields(WsContext context, Index<DisasmDetailDoc> src)
            => iter(src, doc => EmitFields(context,doc), PllExec);

        public void EmitFields(WsContext context, DisasmDetailDoc src)
        {
            var dst = DisasmFieldsPath(context, src.Source);
            var emitting = EmittingFile(dst);
            var emitter = new FieldEmitter(dst);
            var count = emitter.EmitFields(src);
            EmittedFile(emitting,count);
        }
    }
}