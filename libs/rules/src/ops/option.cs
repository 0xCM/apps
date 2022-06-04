//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public static Optional<RuleValue<T>> option<T>(T src)
            => new Optional<RuleValue<T>>(src);
    }
}