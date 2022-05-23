//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Owns a sequence of <see cref='Label'/> allocations
    /// </summary>
    public sealed class LabelAllocation : Allocation<Label>
    {
        public LabelAllocation(IBufferAllocator allocator, Label[] labels)
            : base(allocator, labels)
        {
        }
    }
}