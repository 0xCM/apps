//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        public static Outcome selector(string src, out ValueSelector dst)
        {
            var result = Outcome.Success;
            if(Parsers.Parse(src, out GroupName g))
                dst = g;
            else if(Parsers.Parse(src, out NonterminalKind nt))
                dst = nt;
            else if(Parsers.Num8(src, out byte num8))
                dst = num8;
            else if(Parsers.Parse(src, out XedRegId reg))
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