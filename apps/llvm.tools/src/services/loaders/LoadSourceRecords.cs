//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataLoader
    {
        public ReadOnlySpan<TextLine> LoadSourceRecords(string id)
        {
            using var reader = LlvmPaths.DataSourcePath(id).Utf8LineReader();
            return reader.ReadAll();
        }
    }
}