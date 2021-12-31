//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IConstExpr<T> : IValue<T>, ITerm<T>
    {

    }

    public interface IConstExpr<E,T> : IConstExpr<T>, ITerm<E,T>
        where E : IConstExpr<E,T>
    {

    }
}