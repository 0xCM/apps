//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Actor<K,S,T> : Actor<S,T>, IActor<K,S,T>
        where S : IType
        where T : IType
        where K : unmanaged

    {
        protected Actor(Name name, K modifier)
            : base(name)
        {
            Modifier = modifier;
        }

        public K Modifier {get;}
    }
}