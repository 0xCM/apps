//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class BranchRule<K,T> : IExpr
        where K : unmanaged
        where T : IExpr
    {
        readonly Index<Literal<K>> _Choices;

        readonly Index<T> _Targets;

        public Label Name {get;}

        public BranchRule(Label name, Literal<K>[] src, T[] terms)
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
            => Rules.format(this);

        public override string ToString()
            => Format();
    }
}