//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ILiteralSeq<T> : IReadOnlySeq<Literal<T>>
        where T : IEquatable<T>, IComparable<T>
    {
        Identifier Name {get;}
    }
}