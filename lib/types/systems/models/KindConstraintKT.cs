//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class KindConstraint<K,T> : KindConstraint<K>
        where T : IType
        where K : ITypeKind
    {
        public KindConstraint(T type, K kind)
            : base(type, kind)
        {
            Kind = kind;
        }

        public new K Kind {get;}
    }
}