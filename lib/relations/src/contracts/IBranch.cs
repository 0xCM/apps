//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBranch : ITree
    {

    }

    [Free]
    public interface IBranch<B,L> : IBranch, ITree<B,L>
        where B : IBranch
        where L : ILeaf
    {

    }
}