//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static string format(in CellValueExpr src)
        {
            if(src.Type.Class.IsOperator)
                return src.Operator.Format();
            return src.Data.ToString();
        }

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

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Type.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Type.IsNonEmpty;
            }

            public bool Equals(CellValueExpr src)
                => Data == src.Data && Type.Equals(src.Type);

            [MethodImpl(Inline)]
            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static CellValueExpr Empty => default;
        }
    }
}