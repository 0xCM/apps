//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRelation
    {
        dynamic Kind {get;}

        dynamic Source {get;}

        dynamic Target {get;}
    }

    public interface IRelation<K,S,T> : IRelation
        where K : unmanaged
        where S : unmanaged
        where T : unmanaged
    {
        new K Kind {get;}


        new S Source {get;}

        new T Target {get;}

        dynamic IRelation.Kind
            => Kind;

        dynamic IRelation.Source
            => Source;

        dynamic IRelation.Target
            => Target;
    }
}