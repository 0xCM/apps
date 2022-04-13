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
            public readonly InstPatternSpec Spec;

            public readonly OcInstClass OcInst;

            public readonly Index<OpName> OpNames;

            public readonly FieldSet FieldDeps;

            public readonly InstLock Lock;

            public readonly Index<InstOpDetail> OpDetails;

            public readonly InstFields Layout;

            public readonly InstFields Expr;

            public readonly bit Scalable;

            public InstPattern(in InstPatternSpec spec, in OcInstClass oc, FieldSet deps)
            {
                ref readonly var fields = ref spec.Body.Fields;
                var layout = fields.Layout;
                var expr = fields.Expr;
                Spec = spec;
                OcInst = oc;
                OpNames = spec.Ops.Names;
                FieldDeps = deps;
                Lock = XedFields.@lock(fields);
                OpDetails = XedRules.opdetails(this);
                Scalable = OpDetails.Any(x => x.Scalable);
                Layout = new InstFields(layout.ToArray(), (byte)layout.Length);
                Expr  = new InstFields(expr.ToArray(), 0);
            }

            public ref readonly InstPatternBody Body
            {
                [MethodImpl(Inline)]
                get => ref Spec.Body;
            }

            public ref readonly InstFields Fields
            {
                [MethodImpl(Inline)]
                get => ref Body.Fields;
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

            public TextBlock BodyExpr
            {
                [MethodImpl(Inline)]
                get => Spec.Body.Format();
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

            [MethodImpl(Inline)]
            public FunctionSet NontermOps()
                => Spec.Ops.Nonterms();

            [MethodImpl(Inline)]
            public uint NontermOps(ref FunctionSet dst)
                => Spec.Ops.Nonterms(ref dst);

            [MethodImpl(Inline)]
            public ref readonly PatternOp Op(byte index)
                => ref Spec.Ops[index];

            public ref readonly PatternOp this[byte index]
            {
                [MethodImpl(Inline)]
                get => ref Op(index);
            }

            public ref readonly uint PatternId
            {
                [MethodImpl(Inline)]
                get => ref Spec.PatternId;
            }

            public ref readonly InstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref Spec.InstClass;
            }

            public InstClass Classifier
            {
                [MethodImpl(Inline)]
                get => InstClass.Classifier;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Spec.InstForm;
            }

            public ref readonly InstIsa Isa
            {
                [MethodImpl(Inline)]
                get => ref Spec.Isa;
            }

            public ref readonly Category Category
            {
                [MethodImpl(Inline)]
                get => ref Spec.Category;
            }

            public ref readonly Extension Extension
            {
                [MethodImpl(Inline)]
                get => ref Spec.Extension;
            }

            public ref readonly InstAttribs Attributes
            {
                [MethodImpl(Inline)]
                get => ref Spec.Attributes;
            }

            public ref readonly Index<XedFlagEffect> Effects
            {
                [MethodImpl(Inline)]
                get => ref Spec.Effects;
            }

            public int CompareTo(InstPattern src)
                => Sort().CompareTo(src.Sort());

            [MethodImpl(Inline)]
            public PatternSort Sort()
                => new PatternSort(this);

            public static InstPattern Empty => new InstPattern(InstPatternSpec.Empty, OcInstClass.Empty, FieldSet.create());
        }
    }
}