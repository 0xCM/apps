//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmRecordEtl
    {
        public Outcome EmitLinedRecords(ReadOnlySpan<TextLine> src, string id)
        {
            var result = Outcome.Success;
            var dst = LlvmPaths.RecordImport(id, FS.Txt);
            EmitLines(src, dst, TextEncodingKind.Asci);
            return result;
        }
    }
}