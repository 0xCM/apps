//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataEmitter
    {
        public void EmitDefFields(ReadOnlySpan<RecordField> src)
            => EmitFields(src, Datasets.X86DefFields);

        public void EmitClassFields(ReadOnlySpan<RecordField> src)
            => EmitFields(src, Datasets.X86ClassFields);

        void EmitFields(ReadOnlySpan<RecordField> src, string id)
            => AppSvc.TableEmit<RecordField>(src, RecordField.RenderWidths, LlvmPaths.Table(id));
    }
}