//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedPatterns
    {
        public static string uri(InstPattern src)
            => string.Format("{0}/{1}", src.Isa, src.Classifier);
    }
}