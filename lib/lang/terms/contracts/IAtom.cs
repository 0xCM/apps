//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAtom : ITerminalExpr, ITerm
    {
        uint Key {get;}
    }

    public interface IAtom<K> : IAtom, ITerminalExpr<K>, ITerm<K>
        where K : unmanaged
    {

    }
}