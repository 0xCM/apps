//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    public partial class XedDataTypes : AppService<XedDataTypes>
    {
        static Index<PrimalKind,PrimalType> _Primitives;

        static Index<PrimalKind,LiteralType> _IntrinsicLiterals;

        static Index<TypeKind> _TypeKinds;

        static Index<TypeKind,TypeKey> _Keys;

        static Index<PrimalKind,Type> _RuntimePrimitives;

        static Index<PrimalKind,Type> _RuntimeTypes;

        static Index<NumericKind,NumericType> _IntrinsicNumeric;

        static object KeyLocker = new();

        static Index<PrimalKind,Type> CalcRuntimeTypes()
        {
            var kinds = _TypeKinds;
            var dst = alloc<Type>(kinds.Count);
            for(var i=0; i<kinds.Count; i++)
            {
                ref var type = ref seek(dst,i);
                switch(kinds[i])
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

                    case TypeKind.SegField:
                        type = typeof(SegFieldType);
                    break;

                    case TypeKind.SegVal:
                        type = typeof(SegValType);
                    break;

                    case TypeKind.None:
                        type = typeof(void);
                    break;


                    default:
                        Errors.Throw(AppMsg.UnhandledCase.Format(kinds[i]));
                    break;
                }
            }
            return dst;
        }

        static TypeKey NextKey(TypeKind kind)
        {
            lock(KeyLocker)
            {
                ref var key = ref _Keys[kind];
                key++;
                return key;
            }
        }

        static XedDataTypes()
        {
            _TypeKinds = Symbols.index<TypeKind>().Kinds.ToArray();
            _Keys = alloc<TypeKey>(_TypeKinds.Count);

            for(var i=0; i<_Keys.Length; i++)
                _Keys[(TypeKind)i] = TypeKey.Empty;

            _Primitives = PrimalType.Intrinsic.Types;
            _RuntimePrimitives = LiteralType.Intrinsic.ClrIntrinsic;
            _IntrinsicLiterals = LiteralType.Intrinsic.Types;
            _RuntimeTypes = CalcRuntimeTypes();
            _IntrinsicNumeric = NumericType.Intrinsic.Types;
        }

        public static ref readonly Index<PrimalKind,LiteralType> IntrinsicLiterals
        {
            [MethodImpl(Inline), Op]
            get => ref _IntrinsicLiterals;
        }

        public static ref readonly Index<NumericKind,NumericType> IntrinsicNumeric
        {
            [MethodImpl(Inline), Op]
            get => ref _IntrinsicNumeric;
        }

        public static ref readonly Index<PrimalKind,PrimalType> PrimalTypes
        {
            [MethodImpl(Inline), Op]
            get  => ref _Primitives;
        }

        public static ref readonly Index<PrimalKind,Type> RuntimePrimitives
        {
            [MethodImpl(Inline), Op]
            get  => ref _RuntimePrimitives;
        }

        public static ref readonly Index<TypeKind> TypeKinds
        {
            [MethodImpl(Inline), Op]
            get => ref _TypeKinds;
        }

        public XedDataTypes()
        {

        }

        public static PrimalType ToPrimalType(PrimalKind kind)
            => PrimalType.type(kind);

        public static PrimalKind ToPrimalKind(ClrEnumKind scalar)
        {
            var @base = PrimalKind.None;
            switch(scalar)
            {
                case ClrEnumKind.I8:
                case ClrEnumKind.U8:
                    @base = PrimalKind.U8;
                break;
                case ClrEnumKind.I16:
                case ClrEnumKind.U16:
                    @base = PrimalKind.U16;
                break;
                case ClrEnumKind.I32:
                case ClrEnumKind.U32:
                    @base = PrimalKind.U32;
                break;
                case ClrEnumKind.I64:
                case ClrEnumKind.U64:
                    @base = PrimalKind.U64;
                break;
            }
            return @base;
        }

        public static PrimalKind ToPrimalKind(NumericKind src)
            => src switch{
                NumericKind.U8 => PrimalKind.U8,
                NumericKind.U16 => PrimalKind.U16,
                NumericKind.U32 => PrimalKind.U32,
                NumericKind.U64 => PrimalKind.U64,
                NumericKind.I8 => PrimalKind.U8,
                NumericKind.I16 => PrimalKind.U16,
                NumericKind.I32 => PrimalKind.U32,
                NumericKind.I64 => PrimalKind.U64,
                _ => PrimalKind.None
            };

        public static PrimalType CalcPrimitive(Type src)
        {
            if(src == typeof(bit))
                return PrimalType.Intrinsic.U1;
            else if(src == typeof(void))
                return PrimalType.Intrinsic.Void;
            else if(src.IsPrimalNumeric())
                return ToPrimalType(ToPrimalKind(src.NumericKind()));
            else if(src.IsEnum)
                return ToPrimalType(ToPrimalKind(src.EnumScalarKind()));
            else if(src == typeof(Null))
                return PrimalType.Intrinsic.Empty;
            else
                Errors.Throw($"{src.Name} is not primitive");
            return PrimalType.Intrinsic.Empty;
        }

        public static LiteralType[] CalcLiteralTypes(params Type[] src)
        {
            var count = src.Length;
            var dst = alloc<LiteralType>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = CalcLiteralType(NextKey(TypeKind.Literal), skip(src,i));
            return dst;
        }

        public static LiteralType CalcLiteralType(TypeKey key, Type type)
        {
            var @base = CalcPrimitive(type);
            var name = type.DisplayName();
            Require.invariant(name.Length <= 32);
            var tag = type.Tag<WidthAttribute>();
            var width = (byte)SizeCalc.width(type);
            var packed = width;
            if(tag)
                packed = (byte)((NativeSize)tag.Require().TypeWidth).Width;
            return literal(key, name, @base, packed);
        }

        [MethodImpl(Inline), Op]
        public static PrimalType primitive(PrimalKind kind, asci16 name, AlignedWidth width)
            => new PrimalType(kind, name,width);

        [MethodImpl(Inline), Op]
        public static LiteralType literal(TypeKey key, asci32 name, PrimalType @base, byte packed)
            => new LiteralType(key, name, @base, packed);

        [MethodImpl(Inline)]
        public static LiteralValue literal<T>(TypeKey type, T value)
            where T : unmanaged
                => new LiteralValue<T>(type, value);

        [MethodImpl(Inline)]
        public static LiteralValue literal<T>(LiteralType type, T value)
            where T : unmanaged
                => literal(type.Key,value);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(asci32 name, TypeKey @base, byte packed)
            => new TypedLiteral(name, @base, packed);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(asci32 name, LiteralType @base, byte packed)
            => typed(name, @base.Key, packed);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(TypeKey key, asci16 name, NumericWidth width)
            => new NumericType(key, name, width);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(PrimalType key, asci16 name, NumericWidth width)
            => numeric(key, name, width);

        [MethodImpl(Inline), Op]
        public static CellType cell(TypeKey key, asci16 name, TypeKey @base, byte packed)
            => new CellType(key, name, @base, packed);

        [MethodImpl(Inline), Op]
        public static CellType cell(TypeKey key, asci16 name, PrimalType @base, byte packed)
            => cell(key, name, @base.Key, packed);

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
        public static SegValType segval(SegField seg, TypeKey type)
            => new SegValType(seg,type);

        [MethodImpl(Inline), Op]
        public static SegValType segval(SegField seg, CellType type)
            => segval(seg,type.Key);
    }
}