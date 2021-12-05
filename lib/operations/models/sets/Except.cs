//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public readonly struct Except : IExpr
    {
        HashSet<IExpr> _Terms {get;}

        [MethodImpl(Inline)]
        public Except(IExpr[] choices)
            => _Terms = core.hashset(choices);

        public IReadOnlyCollection<IExpr> Terms
        {
            [MethodImpl(Inline)]
            get => _Terms;
        }

        public Label Name => "exclude";

        public string Format()
            => OpFormatters.Except().Format(this);

        public override string ToString()
            => Format();
    }
}