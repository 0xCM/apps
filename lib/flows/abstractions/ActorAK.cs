//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Actor<A,K> : Actor<A>, IActor<A,K>
        where A : Actor<A,K>,new()
    {
        protected Actor(Identifier name)
            : base(name)
        {

        }

        public virtual ReadOnlySpan<K> Capabilities
            => default;
    }
}