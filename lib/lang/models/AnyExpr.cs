//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AnyExpr : IExpr
    {
        public IExpr Value {get;}

        [MethodImpl(Inline)]
        public AnyExpr(IExpr value)
        {
            Value = value;
        }

        public string Format()
            => Value?.Format() ?? EmptyString;
    }
}