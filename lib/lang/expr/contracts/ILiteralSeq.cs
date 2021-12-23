//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITypedLiterals
    {
        Identifier Name {get;}
    }

    public interface ILiteralSeq<T> : ITypedLiterals, ISeq<Literal<T>>
        where T : IEquatable<T>, IComparable<T>
    {

    }
}