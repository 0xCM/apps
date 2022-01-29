//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Rules
    {
        public static ListExprRule<T> list<T>(T[] src)
            where T : IRuleExpr
                => new ListExprRule<T>(src);
    }
}