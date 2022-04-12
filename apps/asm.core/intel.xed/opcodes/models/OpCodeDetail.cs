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
        public struct OpCodeDetail : IComparable<OpCodeDetail>
        {
            public ushort PatternId;

            public InstClass InstClass;

            public MachineMode Mode;

            public XedOpCode OpCode;

            public InstLock Lock;

            public ModKind Mod;

            public RexBit RexW;

            public InstFields Layout;

            public InstFields Expr;

            [MethodImpl(Inline)]
            public InstGroupSeq GroupSeq()
            {
                var seq = InstGroupSeq.Empty;
                return seq with{
                    PatternId = PatternId,
                    OpCode = OpCode,
                    Mode = Mode,
                    InstClass = InstClass,
                    Lock = Lock,
                    Mod = Mod,
                    RexW = RexW,
                };
            }

            public int CompareTo(OpCodeDetail src)
                => GroupSeq().CompareTo(src.GroupSeq());
        }
    }
}