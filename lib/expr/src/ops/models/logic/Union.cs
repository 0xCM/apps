//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Union : IExpr
    {
        public Index<IExpr> Terms {get;}

        [MethodImpl(Inline)]
        public Union(Index<IExpr> choices)
            => Terms = choices;

        public uint N
        {
            [MethodImpl(Inline)]
            get => Terms.Count;
        }

        public Label Name => "union";

        public string Format()
            => logic.format(this);

        public override string ToString()
            => Format();
    }
}