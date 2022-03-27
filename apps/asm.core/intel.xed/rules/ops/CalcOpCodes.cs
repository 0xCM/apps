//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        public Index<XedOpCode> CalcOpCodes(Index<InstPattern> src)
            => Data(nameof(CalcOpCodes), () => src.Map(x => x.Spec.OpCode).Sort());

        public Index<PatternOpCode> CalcOpCodeDetails()
            => Data(nameof(CalcOpCodeDetails), () => CalcOpCodeDetails(CalcInstPatterns()));

        Index<PatternOpCode> CalcOpCodeDetails(Index<InstPattern> src)
        {
            var count = src.Count;
            var buffer = alloc<PatternOpCode>(count);
            for(var i=0; i<count; i++)
                XedPatterns.poc(src[i], out seek(buffer,i));
            return buffer.Sort();
        }
    }
}