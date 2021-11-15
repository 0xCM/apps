//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ILiteralValue
    {
        LiteralKind Kind {get;}
    }

    /// <summary>
    /// Characterizes a kinded literal value
    /// </summary>
    /// <typeparam name="L">The literal type</typeparam>
    public interface ILiteralValue<T> : ILiteralValue
        where T : IEquatable<T>
    {
        T Data {get;}
    }
}