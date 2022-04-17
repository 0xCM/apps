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
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct InstOpDetail : IComparable<InstOpDetail>
        {
            public uint PatternId;

            public InstClass InstClass;

            public XedOpCode OpCode;

            public MachineMode Mode;

            public InstLock Lock;

            public ModKind Mod;

            public RexBit RexW;

            public OpAttribs Attribs;

            public byte OpCount;

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public OpAction Action;

            public OpWidthCode WidthCode;

            public GprWidth GrpWidth;

            public bit Scalable;

            public ushort BitWidth;

            public ElementType ElementType;

            public ushort ElementWidth;

            public byte ElementCount;

            public BitSegType SegInfo;

            public Register RegLit;

            public OpModifier Modifier;

            public Visibility Visibility;

            public Nonterminal NonTerm;

            public asci64 SourceExpr;

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => NonTerm.IsNonEmpty;
            }

            public bool IsRegLit
            {
                [MethodImpl(Inline)]
                get => RegLit.IsNonEmpty;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(InstOpDetail src)
                => new PatternOrder().Compare(this,src);

            public static InstOpDetail Empty => default;
        }
    }
}