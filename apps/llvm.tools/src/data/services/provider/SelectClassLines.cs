//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public ReadOnlySpan<TextLine> SelectClassLines(Identifier name)
        {
            var lines = list<TextLine>();
            if(SelectClassLookup().Mapped(name, out var interval))
                return X86RecordLines(interval);
            return lines.ViewDeposited();
        }
    }
}