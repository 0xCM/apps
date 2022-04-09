//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedSeq
    {
        public readonly struct SeqDef
        {
            public readonly SeqType Type;
            public readonly Index<SeqStep> Steps;

            [MethodImpl(Inline)]
            public SeqDef(SeqType type, SeqStep[] steps)
            {
                Type = type;
                Steps = steps;
            }
        }
    }
}
