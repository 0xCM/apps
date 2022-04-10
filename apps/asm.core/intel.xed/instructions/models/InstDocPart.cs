//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedRules;
    using static XedModels;

    partial class XedDocs
    {
        public class InstDocPart
        {
            readonly InstPattern Inst;

            public readonly OpCodeMap OcMap;

            public InstDocPart(InstPattern src)
            {
                Inst = src;
                OcMap = XedPatterns.ocmap(src.OpCode.Kind);
            }

            public ref readonly FieldSet FieldDeps
            {
                [MethodImpl(Inline)]
                get => ref Inst.FieldDeps;
            }

            public ref readonly Index<OpName> OpNames
            {
                [MethodImpl(Inline)]
                get => ref Inst.OpNames;
            }

            public ref readonly PatternOps Ops
            {
                [MethodImpl(Inline)]
                get => ref Inst.Ops;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Inst.InstForm;
            }

            public string Classifier
            {
                [MethodImpl(Inline)]
                get => Inst.Classifier;
            }

            public ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref Inst.OpCode;
            }

            public ref readonly uint PatternId
            {
                [MethodImpl(Inline)]
                get => ref Inst.PatternId;
            }

            public ReadOnlySpan<InstField> Layout
            {
                [MethodImpl(Inline)]
                get => Inst.Layout;
            }

            public ReadOnlySpan<InstField> Expr
            {
                [MethodImpl(Inline)]
                get =>Inst.Expr;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref Inst.Mode;
            }
        }
    }
}