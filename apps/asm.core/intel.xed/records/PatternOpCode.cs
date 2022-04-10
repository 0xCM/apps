//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedRules
    {
        [Record(TableId)]
        public struct PatternOpCode : IComparable<PatternOpCode>
        {
            public const string TableId = "xed.opcodes";

            public const byte FieldCount = 9;

            public uint Seq;

            public uint PatternId;

            public uint InstId;

            public MachineMode Mode;

            public OpCodeKind OcKind;

            public AsmOcValue OcValue;

            public InstClass InstClass;

            public TextBlock Layout;

            public TextBlock Pattern;

            public XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => new XedOpCode(Mode, OcKind, OcValue);
            }

            public int CompareTo(PatternOpCode src)
            {
                var result = OpCode.CompareTo(src.OpCode);
                if(result==0)
                {
                    result = Mode.CompareTo(src.Mode);
                    if(result == 0)
                    {
                        result = Layout.CompareTo(src.Layout);
                        if(result == 0)
                            result = Pattern.CompareTo(src.Pattern);
                    }

                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,10,12,8,10,20,18,80,1};
        }
    }
}