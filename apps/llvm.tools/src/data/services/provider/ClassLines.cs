//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public ReadOnlySpan<TextLine> ClassLines(string name)
        {
            var lines = list<TextLine>();
            if(ClassLineLookup().Find(name, out var interval))
                return X86RecordLines(interval);
            return lines.ViewDeposited();
        }
    }
}