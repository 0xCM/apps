//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Token
    {
        public readonly SymKey Key;

        public readonly SymClass Class;

        public readonly Identifier Type;

        public readonly Identifier Name;

        public readonly SymExpr Expr;

        public readonly SymVal Value;

        [MethodImpl(Inline)]
        public Token(SymKey key, SymClass @class, Identifier type, Identifier name, SymExpr expr, SymVal value)
        {
            Key = key;
            Class = @class;
            Type = type;
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