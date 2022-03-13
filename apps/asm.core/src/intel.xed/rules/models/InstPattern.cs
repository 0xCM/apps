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

            public readonly XedOpCode OpCode;

            public readonly Index<PatternOpDetail> OpDetails;

            public InstPattern(InstDef inst, InstPatternSpec spec, Index<PatternOpDetail> details)
            {
                InstDef = inst;
                PatternSpec = spec;
                OpCode = opcode(this);
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

            public ref readonly Index<RuleOpSpec> OpSpecs
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.OpSpecs;
            }

            public byte OperandCount
            {
                [MethodImpl(Inline)]
                get => (byte)PatternSpec.OpSpecs.Count;
            }

            [MethodImpl(Inline)]
            public ref readonly RuleOpSpec Operand(byte index)
                => ref PatternSpec.OpSpecs[index];

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

            public ref readonly InstAttribs InstAttribs
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