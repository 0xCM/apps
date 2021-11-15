//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IRuntimeLiteral : ILiteralValue
    {
        StringAddress Source {get;}

        StringAddress Name {get;}
    }

    public interface IRuntimeLiteral<T> : IRuntimeLiteral, ILiteralValue<T>
        where T : IEquatable<T>
    {

    }
}