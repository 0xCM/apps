//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Just one, neither more nor less
    /// </summary>
    public readonly struct SingleRule : IExpr
    {
        public dynamic Element {get;}

        [MethodImpl(Inline)]
        public SingleRule(dynamic src)
            => Element = src;

        public Label Name => "single";

        public string Format()
            => Element?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();
    }
}