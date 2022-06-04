//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Owns a sequence of <see cref='StringRef'/> allocations
    /// </summary>
    public sealed class StringAllocation : Allocation<StringRef>
    {
        public StringAllocation(IBufferAllocator allocator, StringRef[] allocated)
            : base(allocator, allocated)
        {
        }
    }
}