//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;
    using static XedDisasmModels;

    partial class XedDisasmSvc
    {
        public void EmitFieldReport(FileFlowContext context, Document src)
            => EmitFieldReport(context, src.Detail);

        void EmitFieldReport(FileFlowContext context, Detail src)
        {
            var emitter = new FieldEmitter();
            var dst = text.emitter();
            var count = emitter.EmitFields(src, dst);
            FileEmit(dst.Emit(), count, XedPaths.DisasmFieldsPath(context.Project.Id, src.Source));
        }
    }
}