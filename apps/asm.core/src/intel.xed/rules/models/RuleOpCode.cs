//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using Asm;

    partial class XedRules
    {
        [Record(TableId)]
        public struct RuleOpCode : IComparable<RuleOpCode>
        {
            public const string TableId = "xed.rules.opcodes";

            public const byte FieldCount = 6;

            public uint Seq;

            public OpCodeKind Kind;

            public byte Index;

            public AsmOcValue Value;

            public IClass Class;

            public TextBlock Source;

            public int CompareTo(RuleOpCode src)
            {
                var result = Index.CompareTo(src.Index);
                if(result == 0)
                {
                    result = Value.CompareTo(src.Value);
                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,8,12,24,1};
        }
    }
}