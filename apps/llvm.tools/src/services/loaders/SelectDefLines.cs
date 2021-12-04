//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using System;

    partial class LlvmDataProvider
    {
        public ReadOnlySpan<TextLine> SelectDefLines(Identifier name)
        {
            if(SelectDefLookup().Mapped(name, out var interval))
                return SelectX86RecordLines(interval);
            return default;
        }
    }
}