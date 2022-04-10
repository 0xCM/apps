//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedPatterns
    {
        public static InstClass normalize(InstClass src)
        {
            if(src.IsEmpty)
                return InstClass.Empty;

            var name = XedRender.format(src.Kind);
            if(text.ends(name,"_LOCK"))
                name = text.remove(name,"_LOCK");

            XedParsers.parse(name, out InstClass dst);
            return dst;
        }
    }
}