//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypeConstraint
    {
        /// <summary>
        /// The constrained type
        /// </summary>
        IType Type {get;}
    }

    public interface ITypeConstraint<T> : ITypeConstraint
        where T : IType
    {
        new T Type {get;}

        IType ITypeConstraint.Type
            => Type;
    }
}