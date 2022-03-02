//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Rules;

    partial struct RuleText
    {
        public static RuleValue value(string src)
            => new RuleValue(src,false);

        public static RuleValue value(string src, bool terminal)
            => new RuleValue(src,terminal);
    }
}