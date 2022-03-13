//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        [Record(TableId)]
        public struct PatternInfo : IComparable<PatternInfo>
        {
            public const string TableId = "xed.patterns";

            public const byte FieldCount = 7;

            public uint PatternId;

            public uint InstId;

            public OpCodeKind OcKind;

            public sbyte OcIndex;

            public IClass Class;

            public AsmOcValue OpCode;

            public TextBlock Body;

            public int CompareTo(PatternInfo src)
            {
                var result = OcIndex.CompareTo(src.OcIndex);
                if(result == 0)
                {
                    result = ((ushort)Class).CompareTo((ushort)(src.Class));
                    if(result == 0)
                        result = Body.CompareTo(src.Body);
                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,16,8,24,24,1};

            public static PatternInfo Empty => default;
        }
    }
}