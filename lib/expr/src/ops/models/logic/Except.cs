//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a sequence of dynamically-typed terms c0 | c1 | .. | cN-1
    /// </summary>
    public readonly struct Except : IExpr
    {
        Index<IExpr> _Terms {get;}

        [MethodImpl(Inline)]
        public Except(Index<IExpr> choices)
            => _Terms = choices;

        public ReadOnlySpan<IExpr> Terms
        {
            [MethodImpl(Inline)]
            get => _Terms.View;
        }

        public Label Name => "exclude";

        public string Format()
            => logic.format(this);

        public override string ToString()
            => Format();
    }
}