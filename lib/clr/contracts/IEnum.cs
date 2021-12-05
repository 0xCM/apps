//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IEnum<E> : ITextual, IEquatable<E>
        where E : unmanaged, Enum
    {
        E Literal {get;}
    }
    
    public interface IEnum<E,T> : IEnum<E>
        where E : unmanaged, Enum
        where T : unmanaged
    {
        T Scalar {get;}
    }

    public interface IEnum<F,E,T> : IEnum<E,T>
        where E : unmanaged, Enum
        where T : unmanaged
        where F : unmanaged, IEnum<F,E,T>
    {

    }
}