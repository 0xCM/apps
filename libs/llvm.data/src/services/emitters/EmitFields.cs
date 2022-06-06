//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataEmitter
    {
        public Index<RecordField> EmitDefFields(Index<RecordField> src)
            => EmitFields(src, Datasets.X86DefFields);

        public Index<RecordField> EmitClassFields(Index<RecordField> src)
            => EmitFields(src, Datasets.X86ClassFields);

        Index<RecordField> EmitFields(Index<RecordField> src, string id)
        {
            AppSvc.TableEmit<RecordField>(src, RecordField.RenderWidths, LlvmPaths.Table(id));
            return src;
        }
    }
}