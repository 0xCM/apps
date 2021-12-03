//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct TypeParamDescriptor
    {
        public Identifier Name;

        public Index<TypeConstraint> Constraints;
    }
}