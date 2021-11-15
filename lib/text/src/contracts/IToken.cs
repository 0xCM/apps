//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IToken : ITextual, INullity
    {
        Type TokenType {get;}

        uint Index {get;}

        Identifier Identifier {get;}

        TextBlock SymbolText {get;}
    }

    [Free]
    public interface IToken<K> : IToken
        where K : unmanaged
    {
        K Kind {get;}

        Type IToken.TokenType
            => typeof(K);
    }
}