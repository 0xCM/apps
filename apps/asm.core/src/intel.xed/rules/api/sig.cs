//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public static RuleSig sig(RuleTableKind kind, string name)
        {
            var @class = RuleClass.None;
            if(XedParsers.parse(name, out EncodingGroup group))
                @class = RuleClass.EncodingGroup;
            else if(XedParsers.parse(name, out NontermKind nt))
                @class = RuleClass.Nonterminal;
            else
            {
                if(text.contains(name,"_ENCODE") || text.contains(name, "_ENC"))
                    @class = RuleClass.Encoding;
            }
            return new (kind,@class,name);
        }
    }
}