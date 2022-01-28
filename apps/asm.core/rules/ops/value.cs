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
        public static RuleValueExpr<T> value<T>(T value)
            => new RuleValueExpr<T>(value, false);

        public static RuleValueExpr<T> value<T>(T value, bool terminal)
            => new RuleValueExpr<T>(value, terminal);

        public static SeqExpr<RuleValueExpr<T>> values<T>(params T[] values)
            => values.Select(value);
    }
}