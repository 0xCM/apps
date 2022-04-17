//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedDocs
    {
        public class InstDocPart
        {
            readonly InstPattern Inst;

            public InstDocPart(InstPattern src)
            {
                Inst = src;
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

            public InstClass Classifier
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

            public ref readonly InstFields Layout
            {
                [MethodImpl(Inline)]
                get => ref Inst.Layout;
            }

            public ref readonly InstFields Expr
            {
                [MethodImpl(Inline)]
                get => ref Inst.Expr;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref Inst.Mode;
            }
        }
    }
}