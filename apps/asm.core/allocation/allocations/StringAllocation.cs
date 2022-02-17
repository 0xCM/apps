//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class StringAllocation : Allocation<StringRef>
    {
        internal StringAllocation(IBufferAllocator allocator, StringRef[] allocated)
            : base(allocator, allocated)
        {
        }
    }
}