//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IEnumMember<E> : ITextual, IEquatable<E>
        where E : unmanaged
    {
        E Literal {get;}
    }

    public interface IEnumMember<E,T> : IEnumMember<E>
        where E : unmanaged
        where T : unmanaged
    {
        T Scalar {get;}
    }

    public interface IEnumMember<F,E,T> : IEnumMember<E,T>
        where E : unmanaged
        where T : unmanaged
        where F : unmanaged, IEnumMember<F,E,T>
    {

    }
}