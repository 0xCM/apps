//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class RefinementType<K,R> : IType<K>
        where K : unmanaged
        where R : unmanaged
    {
        public Identifier Name {get;}

        public K Kind {get;}

        public R RefinedKind {get;}

        protected RefinementType(Identifier name, K kind)
        {
            Name = name;
            Kind = kind;
        }

        public string Format()
            => string.Format("{0}:{1}", Name, Kind);
    }

}