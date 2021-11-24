//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Token
    {
        public readonly SymKey Key;

        public readonly Label Type;

        public readonly Label Name;

        public readonly Label Expr;

        public readonly SymVal Value;

        [MethodImpl(Inline)]
        public Token(uint key, Label @class, Label name, Label expr, SymVal value)
        {
            Key = key;
            Type = @class;
            Name = name;
            Expr = expr;
            Value = value;
        }

        public string Format()
            => string.Format("{0,-5} | {1,-36} | {2,-64} | {3,-64} | {4}", Key, Type, Name, RP.squote(Expr), Value);

        public override string ToString()
            => Format();
    }
}