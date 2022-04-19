//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IClrLiteralValue : IKinded<ClrLiteralKind>
    {

    }

    public interface IClrLiteralValue<T> : IClrLiteralValue
        where T : IEquatable<T>
    {
        T Value {get;}
    }
}