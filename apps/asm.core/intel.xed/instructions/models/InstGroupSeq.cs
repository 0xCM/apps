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
        [StructLayout(LayoutKind.Sequential,Pack =1), Record(TableId)]
        public record struct InstGroupSeq : IComparable<InstGroupSeq>
        {
            public const string TableId = "xed.inst.groups";

            public const byte FieldCount = 12;

            public uint Seq;

            public ushort PatternId;

            public InstClass Instruction;

            public ModIndicator Mod;

            public LockIndicator Lock;

            public MachineMode Mode;

            public BitIndicator RexW;

            public RepIndicator Rep;

            public byte Index;

            public XedOpCode OpCode;

            public AsmOcValue OpCodeBytes;

            public InstForm Form;

            public OpCodeClass OpCodeClass
            {
                [MethodImpl(Inline)]
                get => OpCode.Class;
            }

            PatternSort Sort()
                => new PatternSort(this);

            public int CompareTo(InstGroupSeq src)
                => Sort().CompareTo(src.Sort());

            public override int GetHashCode()
                => (int)PatternId | (int)Index << 16;

            public static InstGroupSeq Empty => default;

            public static ReadOnlySpan<byte> RenderWidths
                => new byte[FieldCount]{8,12,18,6, 6, 6, 6, 6, 6, 26, 22, 1};
        }
    }
}