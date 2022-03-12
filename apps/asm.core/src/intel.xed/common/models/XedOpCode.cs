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
        public struct XedOpCode : IComparable<XedOpCode>
        {
            public const string TableId = "xed.opcodes";

            public const byte FieldCount = 7;

            public uint Seq;

            public uint InstId;

            public OpCodeKind Kind;

            public byte Index;

            public AsmOcValue Value;

            public IClass Class;

            public TextBlock Pattern;

            public int CompareTo(XedOpCode src)
            {
                var result = Index.CompareTo(src.Index);
                if(result == 0)
                {
                    result = ((ushort)Class).CompareTo((ushort)(src.Class));
                    if(result == 0)
                        result = Pattern.CompareTo(src.Pattern);
                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,12,8,12,24,1};

            public static XedOpCode Empty => default;
        }
    }
}