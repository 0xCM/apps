//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellDef : IEquatable<CellDef>
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly CellType Type;

            public readonly CellValue Value;

            public readonly asci64 Source;

            [MethodImpl(Inline)]
            public CellDef(FieldKind field, RuleOperator op, CellType type, CellValue value, string src)
            {
                Type = type;
                Field = field;
                Operator = op;
                Value = value;
                Source = src;
            }

            [MethodImpl(Inline)]
            public CellDef(RuleOperator op)
            {
                Type = CellType.@operator(op);
                Field = Type.Field;
                Operator = op;
                Value = CellValue.Empty;
                Source = asci64.Null;
            }

            public CellClass Class
            {
                [MethodImpl(Inline)]
                get => Type.Class;
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

            [MethodImpl(Inline)]
            public bool Equals(CellDef src)
                => Field == src.Field && Operator == src.Operator && Value == src.Value;

            public override int GetHashCode()
                => (int)alg.hash.marvin(Format());

            public override bool Equals(object src)
                => src is CellDef x && Equals(x);

            public string Format()
            {
                var dst = EmptyString;
                if(Class.IsExpr)
                {
                    dst = string.Format("{0}{1}{2}", XedRender.format(Field), Operator.Format(), Value);
                }
                else
                {
                    if(Class.IsSeg)
                        dst = string.Format("{0}[{1}]", XedRender.format(Field), Value);
                    else if(Class.IsNonterm || Class.IsValue)
                        dst = Value.Format();
                    else if(Class.IsOperator)
                        dst = Operator.Format();
                    else
                        Errors.Throw(string.Format("Unhandled case:{0}", Class));
                }

                return dst;
            }

            public override string ToString()
                => Format();

            public static CellDef Empty => default;
        }
    }
}