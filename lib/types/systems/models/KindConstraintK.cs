//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class KindConstraint<K> : KindConstraint, IKindConstraint<K>
        where K : ITypeKind
    {
        public KindConstraint(IType type, K kind)
            : base(type,kind)
        {
            Kind = kind;
        }

        public new K Kind {get;}
    }
}