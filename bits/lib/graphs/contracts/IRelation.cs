//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRelation
    {
        Name Source {get;}

        Name Target {get;}
    }

    public interface IRelation<K> : IRelation
        where K : unmanaged
    {
        K Kind {get;}
    }
}