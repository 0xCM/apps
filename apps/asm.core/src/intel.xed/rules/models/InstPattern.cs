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
            public readonly InstDef InstDef;

            public readonly InstPatternSpec PatternSpec;

            public readonly Index<PatternOpDetail> OpDetails;

            public InstPattern(InstDef inst, InstPatternSpec spec, Index<PatternOpDetail> details)
            {
                InstDef = inst;
                PatternSpec = spec;
                OpDetails = details;
            }

            public ref readonly InstPatternBody Body
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.Body;
            }

            public ref readonly TextBlock RawBody
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.RawBody;
            }

            public ref readonly TextBlock BodyExpr
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.BodyExpr;
            }

            public ref readonly Index<RuleOpSpec> Operands
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.Operands;
            }

            public byte OperandCount
            {
                [MethodImpl(Inline)]
                get => (byte)PatternSpec.Operands.Count;
            }

            [MethodImpl(Inline)]
            public ref readonly RuleOpSpec Operand(byte index)
                => ref PatternSpec.Operands[index];

            public ref readonly RuleOpSpec this[byte index]
            {
                [MethodImpl(Inline)]
                get => ref Operand(index);
            }

            public ref readonly uint InstId
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.InstId;
            }

            public ref readonly uint PatternId
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.PatternId;
            }

            public ref readonly IClass Class
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Class;
            }

            public ref readonly IForm Form
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Form;
            }

            public ref readonly Category Category
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Category;
            }

            public ref readonly Extension Extension
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Extension;
            }

            public ref readonly IsaKind Isa
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Isa;
            }

            public ref readonly Index<AttributeKind> InstAttribs
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Attributes;
            }

            public ref readonly Index<FlagAction> InstFlags
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Flags;
            }

            public int CompareTo(InstPattern src)
                => PatternSpec.CompareTo(src.PatternSpec);
        }
    }
}