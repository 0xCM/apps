//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        Index<XedOpCode> CalcOpCodes(Index<InstPattern> patterns)
        {
            var parser = XedOpCodeParser.create();
            var count = patterns.Count;
            var buffer = alloc<XedOpCode>(count);
            for(var i=0; i<count;i++)
                seek(buffer,i) = parser.Parse(patterns[i]);
            return buffer.Sort();
        }
    }
}