//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class KindConstraint : TypeConstraint, IKindConstraint
    {
        public KindConstraint(IType type, ITypeKind kind)
            : base(type)
        {
            Kind = kind;
        }

        public ITypeKind Kind {get;}
    }
}