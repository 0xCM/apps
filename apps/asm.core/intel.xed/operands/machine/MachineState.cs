//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    using P = XedRules.InstPattern;
    using M = XedModels;
    using R = XedRules;

    partial class XedOperands
    {
        class MachineState : IMachine
        {
            InstPattern Pattern;

            OperandState OpState;

            MachineMode MachineMode;

            InstForm Form;

            Fields Expressions;

            readonly XedRules Rules;

            readonly uint Id;

            static uint Seq;

            public MachineState(XedRules rules)
            {
                Id = core.inc(ref Seq);
                Expressions = Fields.allocate();
                Rules = rules;
                Reset();
            }

            public void Reset()
            {
                OpState = OperandState.Empty;
                Pattern = XedRules.InstPattern.Empty;
                MachineMode = default;
                Form = InstForm.Empty;
                Expressions.Clear();
            }

            void Load(in CellValue src)
            {
                ref readonly var fk = ref src.Field;
                ref readonly var ck = ref src.CellKind;

            }

            void Load(in InstSeg src)
            {

            }

            void Load(in CellExpr src)
            {

            }

            void Load(in FieldSeg src)
            {

            }

            void Load(in InstCells src)
            {
                for(var i=z8; i<src.Count; i++)
                {
                    ref readonly var cell = ref src[i];
                    if(cell.IsExpr)
                    {
                        Load(cell.ToCellExpr());
                    }
                    else if(cell.CellType.IsInstSeg)
                    {
                        Load(cell.AsInstSeg());
                    }
                    else if(cell.CellType.IsFieldSeg)
                    {
                        Load(cell.ToFieldSeg());

                    }

                    Load(cell);
                }
            }

            void Load(in LayoutCell src)
            {

            }

            void Load(in InstLayoutRecord src)
            {
                for(var i=z8; i<src.Count; i++)
                    Load(src[i]);
            }

            void Load(in PatternOp src)
            {

            }

            void Load(in PatternOps src)
            {
                for(var i=z8; i<src.Count; i++)
                    Load(src[i]);
            }

            public void Load(in FieldBuffer src)
            {
                OpState = src.State;
                Form = src.Form;
            }

            public void Load(InstPattern src)
            {
                Reset();
                Form = src.InstForm;
                //Load(LayoutCalcs.layout(src));
                //Load(src.Expr);
                Load(src.Cells);
                Load(src.Ops);
                Pattern = src;
            }

            public ref readonly InstCells Layout
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Layout;
            }

            public ref readonly InstCells Expr
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Layout;
            }

            public ref readonly uint MachineId
            {
                [MethodImpl(Inline)]
                get => ref Id;
            }

            public ref readonly OperandState Operands
            {
                [MethodImpl(Inline)]
                get => ref OpState;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Mode;
            }

            /// <summary>
            /// Specifies the current <see cref='P'/>
            /// </summary>
            public ref readonly InstPattern InstPattern
            {
                [MethodImpl(Inline)]
                get => ref Pattern;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Form;
            }

            public ref readonly InstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref View.iclass(Operands);
            }

            /// <summary>
            /// Specifies the dependency <see cref='M.OpName'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly Index<OpName> OpNames
            {
                [MethodImpl(Inline)]
                get => ref Pattern.OpNames;
            }

            public byte OpCount
            {
                [MethodImpl(Inline)]
                get => (byte)Pattern.Ops.Count;
            }

            /// <summary>
            /// Specifies the dependency <see cref='R.FieldSet'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly FieldSet FieldDeps
            {
                [MethodImpl(Inline)]
                get => ref Pattern.FieldDeps;
            }

            /// <summary>
            /// Specifies the expression-related <see cref='R.InstCells'/>  of the current <see cref='P'/>
            /// </summary>
            public ref readonly InstCells InstExpr
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Expr;
            }

            /// <summary>
            /// Specifies the <see cref='XedOpCode'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly XedOpCode OpCode
            {
                [MethodImpl(Inline)]
                get => ref Pattern.OpCode;
            }

            /// <summary>
            /// Specifies the <see cref='M.Isa'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly InstIsa Isa
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Isa;
            }

            /// <summary>
            /// Specifies the <see cref='M.InstCategory'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly InstCategory Category
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Category;
            }

            /// <summary>
            /// Specifies the <see cref='M.Extension'/> of the current <see cref='P'/>
            /// </summary>
            public ref readonly Extension Extension
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Extension;
            }

            /// <summary>
            /// Specifies the pattern Id of the<see cref='P'/>
            /// </summary>
            public ref readonly ushort PatternId
            {
                [MethodImpl(Inline)]
                get => ref @as<uint,ushort>(Pattern.PatternId);
            }

            /// <summary>
            /// Specifies layout <see cref='R.InstCells'/> associated with the current <see cref='P'/>
            /// </summary>
            public ref readonly InstCells LayoutFields
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Layout;
            }

            /// <summary>
            /// Specifies <see cref='R.PatternOps'/> associated with the current <see cref='P'/>
            /// </summary>
            public ref readonly PatternOps Ops
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Ops;
            }

            /// <summary>
            /// Specifies <see cref='R.InstOpDetail'/> associated with the current <see cref='P'/>
            /// </summary>
            public ref readonly Index<InstOpDetail> OpDetail
            {
                [MethodImpl(Inline)]
                get => ref Pattern.OpDetails;
            }

            uint IMachine.Id
                => Id;
        }
    }
}