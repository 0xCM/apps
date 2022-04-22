//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct CellType : IEquatable<CellType>, IComparable<CellType>
        {
            [MethodImpl(Inline)]
            public static CellType @operator(RuleOperator op)
                => new CellType(0, RuleCellKind.Operator, op, asci16.Null, asci16.Null,0, 0);

            public readonly FieldKind Field;

            public readonly CellClass Class;

            public readonly RuleOperator Operator;

            public readonly asci16 DataKindName;

            public readonly asci16 DomainTypeName;

            public readonly byte DataWidth;

            public readonly byte EffectiveWidth;

            [MethodImpl(Inline)]
            public CellType(FieldKind field, CellClass @class, RuleOperator op, asci16 data, asci16 domain, byte wData, byte wDomain)
            {
                Field = field;
                Class = @class;
                Operator = op;
                DataKindName = data;
                DataWidth = wData;
                DomainTypeName = domain;
                EffectiveWidth = wDomain;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Class.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Class.IsEmpty;
            }

            public CellTypeKind Kind
            {
                [MethodImpl(Inline)]
                get => new (Class,Operator);
            }

            public string Format()
                => CellRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(CellType src)
            {
                var result = Class.CompareTo(src.Class);
                if(result == 0)
                {
                    result = XedRules.cmp(Field,src.Field);
                    if(result == 0)
                        result = Operator.CompareTo(src.Operator);
                }
                return result;
            }

            public static CellType Empty
                => new CellType(FieldKind.INVALID, CellClass.Empty, RuleOperator.None, asci16.Null,asci16.Null, 0,0);
        }
    }
}