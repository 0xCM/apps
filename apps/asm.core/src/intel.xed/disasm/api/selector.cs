//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedDisasm
    {
        public static Outcome selector(string src, out ValueSelector dst)
        {
            var result = Outcome.Success;
            if(Parsers.EncodingGroup(src, out var g))
                dst = g;
            else if(Parsers.Nonterm(src, out var nt))
                dst = nt;
            else if(Parsers.Num8(src, out var num8))
                dst = num8;
            else if(Parsers.RegLiteral(src, out var reg))
                dst = reg;
            else
            {
                dst = ValueSelector.Empty;
                result = (false,AppMsg.ParseFailure.Format(nameof(ValueSelector), src));
            }
            return result;
        }
    }
}