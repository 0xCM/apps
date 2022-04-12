//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedOpCodes
    {
        public static Index<OpCodeCounts> counts(Index<InstPattern> patterns)
        {
            var counter = 0u;
            var buffer = alloc<OpCodeCounts>(patterns.Count);
            for(var i=0u; i<patterns.Count; i++)
            {
                ref var dst = ref buffer[i];
                ref var src = ref patterns[i];
                ref readonly var @class = ref src.OcInst;
                dst.PatternId = src.PatternId;
                dst.InstClass = @class.InstClass.Classifier;
                dst.OpCode = @class.OpCode;
                dst.Mode = src.Mode;
                dst.Lock = src.Lock;
                dst.PatternBody = src.Body;
                dst.Sort = src.Sort();
            }

            buffer.Sort();
            return buffer;
        }
    }
}