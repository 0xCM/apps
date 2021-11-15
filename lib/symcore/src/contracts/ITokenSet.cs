//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITokenSet
    {
        Type[] Types();

        string Name {get;}

        ReadOnlySpan<Token> View {get;}
    }
}