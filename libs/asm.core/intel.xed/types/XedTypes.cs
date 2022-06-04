//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    public partial class XedTypes : AppService<XedTypes>
    {
        static Index<PrimalKind,PrimalType> _Primitives;

        static Index<PrimalKind,LiteralType> _IntrinsicLiterals;

        static Index<TypeKind,TypeKey> _Keys;

        static Index<PrimalKind,Type> _RuntimePrimitives;

        static Index<TypeKind,Type> _RuntimeTypes;

        static Index<NumericKind,NumericType> _IntrinsicNumeric;

        static ref Index<TypeKind,Type> init(out Index<TypeKind,Type> dst)
        {
            var types = Symbols.index<TypeKind>();
            dst = alloc<Type>(types.Count);
            for(var i=0; i<types.Count; i++)
            {
                ref var type = ref dst[types[i].Kind];
                switch(types[i].Kind)
                {
                    case TypeKind.Primitive:
                        type = typeof(PrimalType);
                    break;

                    case TypeKind.Numeric:
                        type = typeof(NumericType);
                    break;

                    case TypeKind.Literal:
                        type = typeof(LiteralType);
                    break;

                    case TypeKind.Cell:
                        type = typeof(CellType);
                    break;

                    case TypeKind.TypedLiteral:
                        type = typeof(TypedLiteral);
                    break;

                    case TypeKind.Field:
                        type = typeof(FieldType);
                    break;

                    case TypeKind.Operator:
                        type = typeof(OperatorType);
                    break;

                    case TypeKind.Expression:
                        type = typeof(ExpressionType);
                    break;

                    case TypeKind.FieldSeg:
                        type = typeof(FieldSegType);
                    break;

                    case TypeKind.SegVal:
                        type = typeof(SegVarType);
                    break;

                    case TypeKind.SegVar:
                        type = typeof(SegVarType);
                    break;

                    case TypeKind.Rule:
                        type = typeof(RuleName);
                    break;

                    case TypeKind.None:
                        type = typeof(void);
                    break;

                    default:
                        type = typeof(void);
                        //Errors.Throw(AppMsg.UnhandledCase.Format(types[i]));
                    break;
                }
            }
            return ref dst;
        }

        static void init(out Index<TypeKind,TypeKey> dst)
        {
            var kinds = Symbols.index<TypeKind>();
            dst = alloc<TypeKey>(kinds.Count);
            for(var i=0; i<kinds.Count; i++)
                dst[kinds[i].Kind] = TypeKey.Empty;
        }


        static XedTypes()
        {
            init(out _Keys);
            init(out _RuntimeTypes);

            _Primitives = PrimalType.Intrinsic.Types;
            _RuntimePrimitives = LiteralType.Intrinsic.ClrIntrinsic;
            _IntrinsicLiterals = LiteralType.Intrinsic.Types;
            _IntrinsicNumeric = NumericType.Intrinsic.Types;
        }

        public static ref readonly Index<PrimalKind,LiteralType> IntrinsicLiterals
        {
            [MethodImpl(Inline), Op]
            get => ref _IntrinsicLiterals;
        }

        public static ref readonly Index<NumericKind,NumericType> Numeric
        {
            [MethodImpl(Inline), Op]
            get => ref _IntrinsicNumeric;
        }

        public static ref readonly Index<PrimalKind,PrimalType> Primitives
        {
            [MethodImpl(Inline), Op]
            get  => ref _Primitives;
        }

        public static ref readonly Index<PrimalKind,Type> RuntimePrimitives
        {
            [MethodImpl(Inline), Op]
            get  => ref _RuntimePrimitives;
        }

        public XedTypes()
        {

        }

        [MethodImpl(Inline), Op]
        public static CellType cell(TypeKey key, asci64 name, TypeKey @base, DataSize size)
            => new CellType(key, name, @base, size);

        [MethodImpl(Inline), Op]
        public static CellType cell(TypeKey key, asci64 name, PrimalType @base, DataSize size)
            => cell(key, name, @base.Key, size);

        [MethodImpl(Inline), Op]
        public static OperatorType op(RuleOperator op, DataSize size)
            => new OperatorType(op);

        [MethodImpl(Inline), Op]
        public static FieldType field(FieldKind field, CellType cell, DataSize size)
            => new FieldType(field, cell);

        [MethodImpl(Inline), Op]
        public static ExpressionType expr(FieldType field, OperatorType op, DataSize size)
            => new ExpressionType(field,op, size);

        [MethodImpl(Inline), Op]
        public static FieldSegType seg(FieldType field, DataSize size)
            => new FieldSegType(field, size);

        [MethodImpl(Inline), Op]
        public static SegValType segval(FieldSeg seg, TypeKey type)
            => new SegValType(seg,type);

        [MethodImpl(Inline), Op]
        public static SegValType segval(FieldSeg seg, CellType type, DataSize size)
            => segval(seg,type.Key);
    }
}