//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;
    using System;

    using static Root;
    using static core;

    public struct Dfa26State
    {
        public byte Depth;

        public Token26 Token;
    }

    [ApiHost]
    public readonly partial struct Dfa
    {
        const NumericKind Closure = UnsignedInts;

        static ReadOnlySpan<char> AsciLo => new char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

    }
}