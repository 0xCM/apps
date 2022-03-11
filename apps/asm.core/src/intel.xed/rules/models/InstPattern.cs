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
        public class InstPattern : IComparable<InstPattern>
        {
            public readonly InstDef Inst;

            public readonly InstPatternSpec Spec;

            public InstPattern(InstDef inst, InstPatternSpec spec)
            {
                Inst = inst;
                Spec = spec;
            }

            public ReadOnlySpan<RuleOpSpec> Operands
            {
                [MethodImpl(Inline)]
                get => Spec.Operands;
            }

            public byte OperandCount
            {
                [MethodImpl(Inline)]
                get => (byte)Spec.Operands.Count;
            }

            [MethodImpl(Inline)]
            public ref readonly RuleOpSpec Operand(byte index)
                => ref Spec.Operands[index];

            public ref readonly RuleOpSpec this[byte index]
            {
                [MethodImpl(Inline)]
                get => ref Operand(index);
            }

            public ref readonly uint InstId
            {
                [MethodImpl(Inline)]
                get => ref Spec.InstId;
            }

            public ref readonly uint PatternId
            {
                [MethodImpl(Inline)]
                get => ref Spec.PatternId;
            }

            public ref readonly IClass Class
            {
                [MethodImpl(Inline)]
                get => ref Inst.Class;
            }

            public ref readonly IForm Form
            {
                [MethodImpl(Inline)]
                get => ref Inst.Form;
            }

            public ref readonly Category Category
            {
                [MethodImpl(Inline)]
                get => ref Inst.Category;
            }

            public ref readonly Extension Extension
            {
                [MethodImpl(Inline)]
                get => ref Inst.Extension;
            }

            public ref readonly IsaKind Isa
            {
                [MethodImpl(Inline)]
                get => ref Inst.Isa;
            }

            public ReadOnlySpan<AttributeKind> InstAttribs
            {
                [MethodImpl(Inline)]
                get => Inst.Attributes;
            }

            public ReadOnlySpan<FlagAction> InstFlags
            {
                [MethodImpl(Inline)]
                get => Inst.Flags;
            }

            public int CompareTo(InstPattern src)
                => Spec.CompareTo(src.Spec);
        }
    }
}