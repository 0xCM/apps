//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AdjacentRule : IExpr
    {
        public readonly dynamic A;

        public readonly dynamic B;

        [MethodImpl(Inline)]
        public AdjacentRule(dynamic a, dynamic b)
        {
            A = a;
            B = b;
        }

        public string Format()
            => Rules.format(this);


        public override string ToString()
            => Format();
    }
}