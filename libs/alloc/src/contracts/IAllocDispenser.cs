//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAllocDispenser : IDisposable
    {
        AllocationKind DispensedKind {get;}
    }

    public interface IAllocDispenser<D> : IAllocDispenser
        where D : IAllocDispenser<D>
    {

    }
}