//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;

    using Types;

    using static Root;

    public class Branch<K,T> : IExpr
        where K : unmanaged
        where T : IExpr
    {
        readonly Index<Literal<K>> _Choices;

        readonly Index<T> _Targets;

        public Label Name {get;}

        public Branch(Label name, Literal<K>[] src, T[] terms)
        {
            Name = name;
            _Choices = src;
            _Targets = terms;
            Require.equal(src.Length, terms.Length);
        }

        public ReadOnlySpan<Literal<K>> Choices
        {
            [MethodImpl(Inline)]
            get => _Choices.Edit;
        }

        public ReadOnlySpan<T> Targets
        {
            [MethodImpl(Inline)]
            get => _Targets.View;
        }

        public string Format()
            => rules.format(this);

        public override string ToString()
            => Format();
    }
}