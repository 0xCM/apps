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
        public readonly struct InstGroupMember : IComparable<InstGroupMember>
        {
            public readonly InstGroupSeq Seq;

            public readonly InstPattern Pattern;

            [MethodImpl(Inline)]
            public InstGroupMember(InstGroupSeq seq, InstPattern pattern)
            {
                Pattern = pattern;
                Seq = seq;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Pattern.InstForm;
            }

            public byte Index
            {
                [MethodImpl(Inline)]
                get => Seq.Index;
            }

            public ModKind Mod
            {
                [MethodImpl(Inline)]
                get => Seq.Mod;
            }

            public ushort PatternId
            {
                [MethodImpl(Inline)]
                get => Seq.PatternId;
            }

            public InstLock Lock
            {
                [MethodImpl(Inline)]
                get => Seq.Lock;
            }

            public MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => Seq.Mode;
            }

            public InstClass Class
            {
                [MethodImpl(Inline)]
                get => Seq.Class;
            }

            public XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => Seq.OpCode;
            }

            public int CompareTo(InstGroupMember src)
                => Seq.CompareTo(src.Seq);
        }
    }
}