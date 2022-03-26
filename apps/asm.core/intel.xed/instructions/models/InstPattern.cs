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

            public readonly InstPatternSpec Spec;

            public InstPattern(InstDef inst, InstPatternSpec spec)
            {
                InstDef = inst;
                Spec = spec;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref Spec.Mode;
            }

            public ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref Spec.OpCode;
            }

            public ref readonly InstPatternBody Body
            {
                [MethodImpl(Inline)]
                get => ref Spec.Body;
            }

            public ref readonly TextBlock BodyExpr
            {
                [MethodImpl(Inline)]
                get => ref Spec.BodyExpr;
            }

            public ref readonly TextBlock RawBody
            {
                [MethodImpl(Inline)]
                get => ref Spec.RawBody;
            }

            public ref readonly PatternOps Ops
            {
                [MethodImpl(Inline)]
                get => ref Spec.Ops;
            }

            public byte OpCount
            {
                [MethodImpl(Inline)]
                get => (byte)Spec.Ops.Count;
            }

            [MethodImpl(Inline)]
            public ref readonly PatternOp Op(byte index)
                => ref Spec.Ops[index];

            public ref readonly PatternOp this[byte index]
            {
                [MethodImpl(Inline)]
                get => ref Op(index);
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

            public ref readonly InstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref InstDef.InstClass;
            }

            public string Classifier
            {
                [MethodImpl(Inline)]
                get => InstClass.Classifier;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Spec.InstForm;
            }

            public ref readonly IsaKind Isa
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Isa;
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

            public ref readonly InstAttribs Attributes
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Attributes;
            }

            public ref readonly Index<XedFlagEffect> Effects
            {
                [MethodImpl(Inline)]
                get => ref InstDef.Effects;
            }

            public bool Locked
            {
                [MethodImpl(Inline)]
                get => InstClass.Locked;
            }

            public int CompareTo(InstPattern src)
                => Sort().CompareTo(src.Sort());

            [MethodImpl(Inline)]
            public PatternSort Sort()
                => new PatternSort(this);
        }
    }
}