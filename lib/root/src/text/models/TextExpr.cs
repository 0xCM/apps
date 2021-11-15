//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TextExpr : ITextExpr<TextExpr>
    {
        public Type ExprType {get;}

        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public TextExpr(Type type, string src)
        {
            Content = src ?? EmptyString;
            ExprType = type;
        }
    }
}