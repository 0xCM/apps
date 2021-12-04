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
        public ReadOnlySpan<TextLine> SelectClassLines(Identifier name)
        {
            var lines = list<TextLine>();
            if(SelectClassLookup().Mapped(name, out var interval))
                return SelectX86RecordLines(interval);
            return lines.ViewDeposited();
        }
    }
}