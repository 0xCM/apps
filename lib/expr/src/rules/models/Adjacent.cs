//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Adjacent : IExpr
    {
        public readonly dynamic A;

        public readonly dynamic B;

        [MethodImpl(Inline)]
        public Adjacent(dynamic a, dynamic b)
        {
            A = a;
            B = b;
        }

        public string Format()
            => rules.format(this);


        public override string ToString()
            => Format();
    }    
}