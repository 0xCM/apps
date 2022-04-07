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
            public readonly CellKey Key;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly CellType Type;

            public readonly CellValueExpr Value;

            public readonly asci64 Source;

            [MethodImpl(Inline)]
            public CellDef(CellKey key, FieldKind field, RuleOperator op, in CellType type, in CellValueExpr value, string src)
            {
                Key = key;
                Type = type;
                Field = field;
                Operator = op;
                Value = value;
                Source = src;
            }

            [MethodImpl(Inline)]
            public CellDef(CellKey key, RuleOperator op)
            {
                Key = key;
                Type = CellType.@operator(op);
                Field = Type.Field;
                Operator = op;
                Value = CellValueExpr.Empty;
                Source = asci64.Null;
            }

            [MethodImpl(Inline)]
            public bool Equals(CellDef src)
                => Field == src.Field && Operator == src.Operator && Value.Equals(src.Value);

            public override int GetHashCode()
                => (int)alg.hash.marvin(Format());

            public override bool Equals(object src)
                => src is CellDef x && Equals(x);

            public string Format()
            {
                var dst = EmptyString;
                if(Type.IsOperator)
                    dst = Type.Operator.Format();
                else if(Type.IsKeyword)
                    dst = Value.Format();
                else if(Type.IsExpr)
                    dst = string.Format("{0}{1}{2}", XedRender.format(Field), Operator.Format(), Value);
                else if(Type.IsSegVar)
                    dst = string.Format("{0}[{1}]", XedRender.format(Field), SegSpecs.bitfield(Field));
                else if(Type.IsSegLiteral)
                    dst = string.Format("{0}[{1}]", XedRender.format(Field), Value);
                else if(Type.IsSegSpec)
                    dst = Value.Format();
                else if(Type.IsNonterm || Type.IsValue)
                    dst = Value.Format();
                else
                    Errors.Throw(string.Format("Unhandled case:{0}", Type.Class));
                return dst;
            }

            public override string ToString()
                => Format();

            public static CellDef Empty => default;
        }
    }
}