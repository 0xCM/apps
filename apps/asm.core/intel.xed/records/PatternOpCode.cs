//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [Record(TableId)]
        public struct PatternOpCode
        {
            public const string TableId = "xed.opcodes";

            public const byte FieldCount = 11;

            public uint Seq;

            public ushort PatternId;

            public InstClass InstClass;

            public byte Index;

            public XedOpCode OpCode;

            public MachineMode Mode;

            public InstLock Lock;

            public ModKind Mod;

            public RexBit RexW;

            public InstFields Layout;

            public InstFields Expr;

            // [MethodImpl(Inline)]
            // public InstGroupSeq GroupSeq()
            // {
            //     var seq = InstGroupSeq.Empty;
            //     return seq with{
            //         PatternId = PatternId,
            //         OpCode = OpCode,
            //         Mode = Mode,
            //         InstClass = InstClass,
            //         Lock = Lock,
            //         Mod = Mod,
            //         RexW = RexW,
            //     };
            // }

            // public int CompareTo(PatternOpCode src)
            // {
            //     var result = OpCode.CompareTo(src.OpCode);

            //     if(result == 0)
            //         result = InstClass.CompareTo(src.InstClass);

            //     if(result == 0)
            //         result = Mode.CompareTo(src.Mode);

            //     if(result == 0)
            //         result = Lock.CompareTo(src.Lock);

            //     if(result == 0 && Mod.IsNonEmpty && src.Mod.IsNonEmpty)
            //         result = Mod.CompareTo(src.Mod);

            //     if(result == 0 && RexW.IsNonEmpty && src.RexW.IsNonEmpty)
            //         result = RexW.CompareTo(src.RexW);

            //     return result;
            // }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,10,18,8,26,6,6,6,6,112,1};
        }
    }
}