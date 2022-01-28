//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Rules
    {
        public static SeqExpr<T> seq<T>(T[] src)
            where T : IRuleExpr
                => new SeqExpr<T>(src);
    }
}