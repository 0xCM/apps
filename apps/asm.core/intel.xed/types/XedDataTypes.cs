//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedDataTypes : AppService<XedDataTypes>
    {
        [MethodImpl(Inline), Op]
        public static PrimalType primal(asci16 name, AlignedWidth width)
            => new PrimalType(name,width);

        [MethodImpl(Inline), Op]
        public static LiteralType literal(asci16 name, PrimalType @base, byte packed)
            => new LiteralType(name, @base, packed);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(asci32 name, LiteralType @base, byte packed)
            => new TypedLiteral(name, @base, packed);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(asci16 name, PrimalType @base, byte packed)
            => new NumericType(name,@base, packed);

        [MethodImpl(Inline), Op]
        public static CellType cell(asci16 name, PrimalType @base, byte packed)
            => new CellType(name, @base, packed);

        [MethodImpl(Inline), Op]
        public static OperatorType op(RuleOperator op)
            => new OperatorType(op);

        [MethodImpl(Inline), Op]
        public static FieldType field(FieldKind field, CellType cell)
            => new FieldType(field, cell);

        [MethodImpl(Inline), Op]
        public static ExpressionType expr(FieldType field, OperatorType op)
            => new ExpressionType(field,op);

        [MethodImpl(Inline), Op]
        public static SegFieldType seg(FieldType field)
            => new SegFieldType(field);

        [MethodImpl(Inline), Op]
        public static SegValType segval(SegField seg, CellType type)
            => new SegValType(seg,type);
    }
}