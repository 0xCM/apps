//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ILiteralSeq<T> : ISeq<Literal<T>>
        where T : IEquatable<T>, IComparable<T>
    {
        Identifier Name {get;}
    }
}