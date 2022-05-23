//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Owns a sequence of <see cref='SourceText'/> allocations
    /// </summary>
    public sealed class SourceAllocation : Allocation<SourceText>
    {
        public SourceAllocation(IBufferAllocator allocator, SourceText[] allocated)
            : base(allocator, allocated)
        {
        }
    }
}