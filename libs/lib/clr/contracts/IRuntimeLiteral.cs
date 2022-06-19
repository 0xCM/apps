//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IRuntimeLiteral : IClrLiteralValue
    {
        StringAddress Source {get;}

        StringAddress Name {get;}
    }

    public interface IRuntimeLiteral<T> : IRuntimeLiteral, IClrLiteralValue<T>
        where T : IEquatable<T>
    {

    }
}