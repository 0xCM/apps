//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    using Asm;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct CellValueExpr
        {
            public readonly CellType Type;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            public CellValueExpr(RuleOperator op)
            {
                Type = CellType.@operator(op);
                Data = (byte)op;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(CellType type, bit data)
            {
                Type = type;
                Data = (byte)data;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(CellType type, byte data)
            {
                Type = type;
                Data = (byte)data;
            }

            [MethodImpl(Inline)]
            public CellValueExpr(CellType type, ushort data)
            {
                Type = type;
                Data = (byte)data;
            }

            public RuleOperator Operator
            {
                [MethodImpl(Inline)]
                get => Type.Operator;
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Type.Field;
            }
        }
    }
}