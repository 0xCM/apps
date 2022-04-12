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
        [StructLayout(LayoutKind.Sequential,Pack =1)]
        public record struct InstGroupSeq : IComparable<InstGroupSeq>
        {
            public byte Index;

            public ushort PatternId;

            public InstClass InstClass;

            public XedOpCode OpCode;

            public MachineMode Mode;

            public InstLock Lock;

            public ModKind Mod;

            public RexBit RexW;

            PatternSort Sort()
                => new PatternSort(this);

            public int CompareTo(InstGroupSeq src)
                => Sort().CompareTo(src.Sort());

            public static InstGroupSeq Empty => default;
        }
    }
}