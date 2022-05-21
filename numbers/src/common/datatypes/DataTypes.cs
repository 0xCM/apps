//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class DataTypes
    {
        static object KeyLocker = new();

        public static TypeKey NextKey(DataTypeKind kind)
        {
            lock(KeyLocker)
            {
                ref var key = ref _DataTypeKeys[kind];
                key++;
                return key;
            }
        }

        static void init(out Index<DataTypeKind,TypeKey> dst)
        {
            var kinds = Symbols.index<DataTypeKind>();
            dst = alloc<TypeKey>(kinds.Count);
            for(var i=0; i<kinds.Count; i++)
                dst[kinds[i].Kind] = TypeKey.Empty;
        }


        static DataTypes()
        {
            init(out _DataTypeKeys);
            init(out _RuntimeDataTypes);

            _Primitives = PrimalType.Intrinsic.Types;
            _RuntimePrimitives = LiteralType.Intrinsic.ClrIntrinsic;
            _IntrinsicLiterals = LiteralType.Intrinsic.Types;
            _IntrinsicNumeric = NumericType.Intrinsic.Types;
        }

        static Index<PrimalKind,PrimalType> _Primitives;

        static Index<PrimalKind,LiteralType> _IntrinsicLiterals;

        static Index<PrimalKind,Type> _RuntimePrimitives;

        static Index<NumericKind,NumericType> _IntrinsicNumeric;

        static Index<DataTypeKind,Type> _RuntimeDataTypes;

        static Index<DataTypeKind,TypeKey> _DataTypeKeys;

        static ref Index<DataTypeKind,Type> init(out Index<DataTypeKind,Type> dst)
        {
            var types = Symbols.index<DataTypeKind>();
            dst = alloc<Type>(types.Count);
            for(var i=0; i<types.Count; i++)
            {
                ref var type = ref dst[types[i].Kind];
                switch(types[i].Kind)
                {
                    case DataTypeKind.Primitive:
                        type = typeof(PrimalType);
                    break;

                    case DataTypeKind.Numeric:
                        type = typeof(NumericType);
                    break;

                    case DataTypeKind.Literal:
                        type = typeof(LiteralType);
                    break;

                    case DataTypeKind.TypedLiteral:
                        type = typeof(TypedLiteral);
                    break;
                    case DataTypeKind.None:
                        type = typeof(void);
                    break;

                    default:
                        type = typeof(void);
                    break;
                }
            }

            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static PrimalType primitive(PrimalKind kind, asci64 name, AlignedWidth width)
            => new PrimalType(kind, name,width);

        [MethodImpl(Inline), Op]
        public static LiteralType literal(TypeKey key, asci64 name, PrimalType @base, DataSize size)
            => new LiteralType(key, name, @base, size);

        [MethodImpl(Inline), Op]
        public static LiteralType literal(TypeKey key, asci64 name, PrimalType @base, byte size)
            => new LiteralType(key, name, @base, (size,size));

        [MethodImpl(Inline)]
        public static LiteralValue literal<T>(TypeKey type, T value)
            where T : unmanaged
                => new LiteralValue<T>(type, value);

        [MethodImpl(Inline)]
        public static LiteralValue literal<T>(LiteralType type, T value)
            where T : unmanaged
                => literal(type.Key,value);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(asci64 name, TypeKey @base, DataSize size)
            => new TypedLiteral(name, @base, size);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(asci64 name, LiteralType @base, DataSize size)
            => typed(name, @base.Key, size);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(TypeKey key, asci64 name, DataSize size)
            => new NumericType(key, name, size);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(TypeKey key, asci64 name, byte width)
            => new NumericType(key, name, width);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(PrimalType key, asci64 name, NumWidth width)
            => numeric(key, name, width);

        public static LiteralType CalcLiteralType(TypeKey key, Type type)
        {
            var @base = CalcPrimitive(type);
            var name = type.DisplayName();
            Require.invariant(name.Length <= 32);
            var tag = type.Tag<WidthAttribute>();
            var width = (byte)Sizes.bits(type);
            var packed = width;
            if(tag)
                packed = (byte)((NativeSize)tag.Require().TypeWidth).Width;
            return literal(key, name, @base, new DataSize(packed, @base.Size.NativeWidth));
        }

        public static PrimalType ToPrimalType(PrimalKind kind)
            => PrimalType.type(kind);

        public static LiteralType[] CalcLiteralTypes(params Type[] src)
        {
            var count = src.Length;
            var dst = alloc<LiteralType>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = CalcLiteralType(NextKey(DataTypeKind.Literal), skip(src,i));
            return dst;
        }

        public static PrimalType CalcPrimitive(Type src)
        {
            if(src == typeof(bit))
                return PrimalType.Intrinsic.U1;
            else if(src == typeof(void))
                return PrimalType.Intrinsic.Void;
            else if(src.IsPrimalNumeric())
                return ToPrimalType(DataTypes.ToPrimalKind(src.NumericKind()));
            else if(src.IsEnum)
                return ToPrimalType(DataTypes.ToPrimalKind(src.EnumScalarKind()));
            else if(src == typeof(Null))
                return PrimalType.Intrinsic.Empty;
            else
                Errors.Throw($"{src.Name} is not primitive");
            return PrimalType.Intrinsic.Empty;
        }


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

        public static Index<DataTypeRecord> records(Assembly[] src, bool pll = true)
        {
            var types = src.Types().Concrete().Where(x => x.IsStruct() || x.IsEnum);
            var dst = bag<DataTypeRecord>();
            iter(types, t => dst.Add(record(t)),pll);
            return resequence(dst.ToArray().Index().Sort());
        }

        public static Index<T> resequence<T>(Index<T> src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                src[i].Seq = i;
            return src;
        }

        public static T[] resequence<T>(T[] src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                seek(src,i).Seq = i;
            return src;
        }

        public static Span<T> resequence<T>(Span<T> src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                seek(src,i).Seq = i;
            return src;
        }

        [MethodImpl(Inline)]
        public static DataType define(asci32 name, DataSize size)
            => new DataType(name,size);

        /// <summary>
        /// Determines whether the source type defines a <see cref='DataType'/>
        /// </summary>
        /// <param name="src">The type to test</param>
        public static bool test(Type src)
            => src.Tagged<DataWidthAttribute>();

        public static Index<DataType> discover(Assembly src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(candidates(src), t => dst.Add(new DataType(t.Name, Sizes.measure(t))),pll);
            return dst.ToArray().Sort();
        }

        public static Index<DataType> discover(Assembly[] src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(src, a =>  iter(candidates(a), t => dst.Add(new DataType(t.Name, Sizes.measure(t))),pll),pll);
            return dst.Index().Sort();
        }

        public static Index<DataType> discover(Type[] src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(src, t => dst.Add(new DataType(t.Name, Sizes.measure(t))),pll);
            return dst.Index().Sort();
        }

        static DataTypeRecord record(Type src)
        {
            var dst = default(DataTypeRecord);
            var size = Sizes.measure(src);
            dst.Name = src.Name;
            dst.Part = src.Assembly.PartName();
            dst.PackedWidth = size.Packed;
            dst.NativeWidth = size.Native;
            dst.PackedSize = size.Packed != 0 ? (size.Packed/8 + (size.Packed % 8 == 0 ? 0 : 1)) : 0;
            dst.NativeSize = size.Native/8;
            return dst;
        }

        static Type[] candidates(Assembly src)
            => src.Types().Concrete().Where(x => x.IsStruct() || x.IsEnum);
    }
}