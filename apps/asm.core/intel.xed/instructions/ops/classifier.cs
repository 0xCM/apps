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
        public static string classifier(InstClass src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = XedRender.format(src.Kind);
            if(text.ends(dst,"_LOCK"))
                dst = text.remove(dst,"_LOCK");

            return dst;
        }
    }
}