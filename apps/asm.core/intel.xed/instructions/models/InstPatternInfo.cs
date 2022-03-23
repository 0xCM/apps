//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedPatterns
    {
        [Record(TableId)]
        public struct InstPatternInfo : IComparable<InstPatternInfo>
        {
            public const string TableId = "xed.inst.patterns";

            public const byte FieldCount = 6;

            public uint PatternId;

            public uint InstId;

            public EnumFormat<OpCodeIndex> OcIndex;

            public IClass Class;

            public AsmOcValue OpCode;

            public TextBlock Body;

            public int CompareTo(InstPatternInfo src)
            {
                var result = ((byte)OcIndex).CompareTo((byte)src.OcIndex);
                if(result == 0)
                {
                    result = ((ushort)Class).CompareTo((ushort)(src.Class));
                    if(result == 0)
                        result = Body.CompareTo(src.Body);
                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,16,24,24,1};

            public static InstPatternInfo Empty => default;
        }
    }
}