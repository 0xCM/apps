//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISeqAggregator<S,T>
        where S : IType
        where T : IType
    {
        Outcome Distill(ISeq<S> src, out T dst);
    }
}