//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using CK = XedRules.CellRole;

    partial class XedRules
    {
        public readonly struct CellDef : IEquatable<CellDef>
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly CellType CellType;

            public readonly CellValue Value;

            public readonly asci64 Source;

            [MethodImpl(Inline)]
            public CellDef(FieldKind field, RuleOperator op, CellType type, CellValue value, string src)
            {
                CellType = type;
                Field = field;
                Operator = op;
                Value = value;
                Source = src;
            }

            public CellRole Role
            {
                [MethodImpl(Inline)]
                get => CellType.Role;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0 && Operator.IsEmpty && (Value.IsEmpty || Value.IsEmpty);
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0 || Operator.IsNonEmpty || (Value.IsNonEmpty && !Value.IsEmpty);
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
                var dst = string.Format("{0}{1}{2}", XedRender.format(Field), Operator.Format(), Value);
                switch(CellType.Role)
                {
                    case CK.Seg:
                    case CK.DispSeg:
                    case CK.ImmSeg:
                        dst = string.Format("{0}[{1}]", XedRender.format(Field), Value);
                    break;
                    case CK.NontermCall:
                        dst = Value.Format();
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            public static CellDef Empty => default;
        }
    }
}