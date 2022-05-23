//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataCalcs
    {
        public static bool lineage(string content, out Lineage dst)
        {
            var m = SQ.index(content, Chars.FSlash, Chars.FSlash);
            if(m >= 0)
            {
                var chain = text.trim(text.right(content, m + 1)).Split(Chars.Space);
                if(chain.Length > 0)
                {
                    dst = Lineage.path(chain);
                    return true;
                }
            }
            dst = Lineage.Empty;
            return false;
        }
    }
}