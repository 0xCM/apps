//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Rules;

    public readonly struct RuleText
    {
        public static RuleValue value(string src, bool terminal = false)
            => new RuleValue(src, terminal);
    }
}