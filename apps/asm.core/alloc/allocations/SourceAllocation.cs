//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class SourceAllocation : Allocation<SourceText>
    {
        internal SourceAllocation(IBufferAllocator allocator, SourceText[] allocated)
            : base(allocator, allocated)
        {
        }
    }
}