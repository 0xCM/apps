//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class LabelAllocation : Allocation<Label>
    {
        internal LabelAllocation(IBufferAllocator allocator, Label[] labels)
            : base(allocator, labels)
        {
        }
    }
}