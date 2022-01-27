//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class TextReplace
    {
        readonly Dictionary<string,string> Rules;

        public TextReplace(Dictionary<string,string> rules)
        {
            Rules = rules;
        }

        public string Apply(string src)
        {
            var dst = src;
            foreach(var rule in Rules)
                dst = text.replace(dst, rule.Key, rule.Value);
            return dst;
        }
    }
}