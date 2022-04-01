//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static string normalize(string src)
        {
            var dst = EmptyString;
            var i = text.index(src, Chars.Hash);
            if(i>0)
                dst = text.despace(text.trim(text.left(src, i)));
            else
                dst = text.despace(text.trim(src));
            if(dst == "otherwise")
                return "else";
            else if(dst == "nothing")
                return "null";
            else
                return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
        }
    }
}