//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public ReadOnlySpan<TextLine> DefLines(Identifier name)
        {
            if(SelectDefLookup().Mapped(name, out var interval))
                return X86RecordLines(interval);
            return default;
        }
    }
}