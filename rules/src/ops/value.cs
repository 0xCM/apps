//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public static RuleValue<T> value<T>(T value)
            => new RuleValue<T>(value, false);

        public static RuleValue<T> value<T>(T value, bool terminal)
            => new RuleValue<T>(value, terminal);
    }
}