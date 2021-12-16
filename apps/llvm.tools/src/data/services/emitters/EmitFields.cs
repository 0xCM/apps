//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static LlvmNames;

    partial class LlvmDataEmitter
    {
        public FS.FilePath EmitDefFields(ReadOnlySpan<RecordField> src)
            => EmitFields(src, Datasets.X86DefFields);

        public FS.FilePath EmitClassFields(ReadOnlySpan<RecordField> src)
            => EmitFields(src, Datasets.X86ClassFields);

        FS.FilePath EmitFields(ReadOnlySpan<RecordField> src, string dstid)
        {
            var count = src.Length;
            var dst = LlvmPaths.Table(dstid);
            TableEmit(src, RecordField.RenderWidths, TextEncodingKind.Asci, dst);
            return dst;
        }
    }
}