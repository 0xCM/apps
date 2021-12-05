//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITypedSeqAggregator<S,T>
        where S : ITyped
        where T : ITyped
    {
        Outcome Distill(ITypedSeq<S> src, out T dst);
    }
}