//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TypeConstraint : ITypeConstraint
    {
        public IType Type {get;}

        public TypeConstraint(IType type)
        {
            Type = type;
        }
    }
}