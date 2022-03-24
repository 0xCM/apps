//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedPatterns
    {
        [Record(TableId)]
        public struct InstPatternInfo : IComparable<InstPatternInfo>
        {
            public const string TableId = "xed.inst.patterns";

            public const byte FieldCount = 7;

            public uint PatternId;

            public uint InstId;

            public MachineMode Mode;

            public XedOpCode OpCode;

            public InstClass InstClass;

            public InstForm InstForm;

            public TextBlock Body;

            public int CompareTo(InstPatternInfo src)
            {
                var result = OpCode.CompareTo(src.OpCode);
                if(result == 0)
                {
                    result = InstClass.CompareTo(src.InstClass);
                    if(result == 0)
                        result = Body.CompareTo(src.Body);
                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,12,20,24,52,1};

            public static InstPatternInfo Empty => default;
        }
    }
}