//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XedRules
    {
        public static void lines(in TableSpec src, ITextBuffer dst)
        {
            foreach(var line in src.Lines())
                dst.AppendLineFormat("# {0}", line.Content);
        }

        public static void lines(in TableSpec src, StreamWriter dst)
        {
            foreach(var line in src.Lines())
                dst.AppendLineFormat("# {0}", line.Content);
        }
    }
}