//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataEmitter
    {
        public FS.FilePath EmitFields(ReadOnlySpan<RecordField> src, string dstid)
        {
            var fields = src;
            var count = fields.Length;
            var dst = LlvmPaths.Table(dstid);
            TableEmit(src, RecordField.RenderWidths, TextEncodingKind.Asci, dst);
            return dst;
        }
    }
}