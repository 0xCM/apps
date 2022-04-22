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
            var dst = InstClass.Empty;
            if(src.IsEmpty)
                return InstClass.Empty;

            var name = src.Kind.ToString();
            if(text.ends(name,"_LOCK") || text.begins(name,"_LOCK"))
            {
                name = text.remove(name,"_LOCK");
                if(text.nonempty(name))
                    XedParsers.parse(name, out dst);
            }
            return dst;
        }
    }
}