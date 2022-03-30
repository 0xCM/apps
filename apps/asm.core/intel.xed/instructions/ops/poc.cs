//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedPatterns
    {
        public static void poc(InstPattern src, out PatternOpCode dst)
        {
            dst = default;
            (var fields, var _ly) = split(src.Body);
            dst.PatternId = src.PatternId;
            dst.InstId = src.InstId;
            dst.OcKind = src.OpCode.Kind;
            dst.OcValue = src.OpCode.Value;
            dst.InstClass = src.InstClass;
            dst.Pattern = src.BodyExpr;
            dst.Mode = mode(src.Body);
            InstPatternBody _layout = layout(src);
            dst.Layout = _layout.Format();
        }

        public static Index<PatternOpCode> poc(Index<InstPattern> src)
        {
            var count = src.Count;
            var buffer = alloc<PatternOpCode>(count);
            for(var i=0; i<count; i++)
                XedPatterns.poc(src[i], out seek(buffer,i));
            return buffer.Sort();
        }
    }
}