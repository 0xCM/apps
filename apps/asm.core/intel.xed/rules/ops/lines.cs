//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static void lines(in TableCriteria src, ITextEmitter dst)
        {
            foreach(var line in src.Lines())
                dst.AppendLineFormat("# {0}", line.Content);
        }
    }
}