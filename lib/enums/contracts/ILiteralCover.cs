//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ILiteralCover : ITextual
    {

    }

    public interface ILiteralCover<T> : ILiteralCover
    {
        T Value {get;}

        string ITextual.Format()
            => Value.ToString();
    }
}