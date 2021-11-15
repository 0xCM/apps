//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// A rule is, by definition, a name bound to a term
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Rule<T> : IExpr
        where T : IExpr
    {
        public Label Name {get;}

        public T Expr {get;}

        [MethodImpl(Inline)]
        public Rule(Label name, T term)
        {
            Name = name;
            Expr = term;
        }

        public string Format()
            => rules.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Rule<T>((Label name, T term) src)
            => new Rule<T>(src.name, src.term);
    }
}