//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        public class InstPattern : IComparable<InstPattern>
        {
            public readonly InstDef InstDef;

            public readonly InstPatternSpec PatternSpec;

            public readonly Index<InstPatternOp> Operands;

            public InstPattern(InstDef inst, InstPatternSpec spec, Index<InstPatternOp> details)
            {
                InstDef = inst;
                PatternSpec = spec;
                Operands = details;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.Mode;
            }

            public ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.OpCode;
            }

            public ref readonly InstPatternBody Body
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.Body;
            }

            public ref readonly TextBlock BodyExpr
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.BodyExpr;
            }

            public ref readonly TextBlock RawBody
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.RawBody;
            }

            public ref readonly Index<OpSpec> OpSpecs
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.Ops;
            }

            public byte OpCount
            {
                [MethodImpl(Inline)]
                get => (byte)PatternSpec.Ops.Count;
            }

            [MethodImpl(Inline)]
            public ref readonly OpSpec Op(byte index)
                => ref PatternSpec.Ops[index];

            public ref readonly OpSpec this[byte index]
            {
                [MethodImpl(Inline)]
                get => ref Op(index);
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

            public ref readonly InstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref InstDef.InstClass;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref PatternSpec.InstForm;
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

            public ref readonly Index<XedFlagEffect> InstFlags
            {
                [MethodImpl(Inline)]
                get => ref InstDef.FlagEffects;
            }

            public int CompareTo(InstPattern src)
                => PatternSpec.CompareTo(src.PatternSpec);
        }
    }
}