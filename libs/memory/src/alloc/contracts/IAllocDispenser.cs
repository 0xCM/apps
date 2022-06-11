//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAllocDispenser : IDisposable
    {
        AllocationKind Kind {get;}
    }
}