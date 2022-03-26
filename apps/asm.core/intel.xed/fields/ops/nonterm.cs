//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedFields
    {
        public static bool nonterm(OpAttrib src, out Nonterminal dst)
        {
            if(src.IsNonTerminal)
            {
                dst = src.AsNonTerm();
                return true;
            }
            else
            {
                dst = Nonterminal.Empty;
                return false;
            }
        }

        public static bool nonterm(OpAttribs src, out Nonterminal dst)
        {
            for(var i=0; i<src.Count; i++)
            {
                if(nonterm(src[i], out dst))
                    return true;
            }
            dst = Nonterminal.Empty;
            return false;
        }
    }
}