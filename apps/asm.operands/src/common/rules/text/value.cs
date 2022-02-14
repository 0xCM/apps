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

    partial struct RuleText
    {
        public static RuleValue value(string src)
            => new RuleValue(src,false);

        public static RuleValue value(string src, bool terminal)
            => new RuleValue(src,terminal);
    }
}