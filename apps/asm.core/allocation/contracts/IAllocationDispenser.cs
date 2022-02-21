//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAllocationDispenser : IDisposable
    {
        AllocationKind DispensedKind {get;}
    }
}