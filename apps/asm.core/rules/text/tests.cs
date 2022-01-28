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
        public static bool IsChoice(string src)
            => text.fenced(src,ChoiceFence);

        public static bool IsOption(string src)
            => text.fenced(src, OptionFence);

        public static bool IsProduction(string src)
            => text.split(src,YieldsSymbol).Length == 2;
    }
}