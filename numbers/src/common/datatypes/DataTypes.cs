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

        public static DataTypeInfo describe(Type src)
        {
            var dst = DataTypeInfo.Empty;
            var size = Sizes.measure(src);
            var width = Sizes.bits(src);
            dst.Name = src.Name;
            dst.Part = src.Assembly.PartName();
            dst.PackedWidth = size.Packed;
            dst.NativeWidth = size.Native;
            dst.NativeSize = size.Native/8;
            return dst;
        }

        public static Index<DataTypeInfo> describe(Assembly[] src, bool pll = true)
        {
            var types = src.Types().Concrete().Where(x => x.IsStruct() || x.IsEnum);
            var dst = bag<DataTypeInfo>();
            iter(types, t => dst.Add(describe(t)), pll);
            return dst.ToArray().Index().Sort().Resequence();
        }

        public static TypeKey NextKey(DataTypeKind kind)
        {
            lock(KeyLocker)
            {
                ref var key = ref _TypeKeys[kind];
                key++;
                return key;
            }
        }

        public static LiteralType literal(TypeKey key, Type type)
        {
            var @base = primal(type);
            var name = type.DisplayName();
            Require.invariant(name.Length <= 32);
            var tag = type.Tag<WidthAttribute>();
            var width = (byte)Sizes.bits(type);
            var packed = width;
            if(tag)
                packed = (byte)((NativeSize)tag.Require().TypeWidth).Width;
            return literal(key, name, @base, new DataSize(packed, @base.Size.NativeWidth));
        }

        public static PrimalType type(PrimalKind kind)
            => PrimalType.type(kind);

        public static LiteralType[] literals(params Type[] src)
        {
            var count = src.Length;
            var dst = alloc<LiteralType>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = literal(NextKey(DataTypeKind.Literal), skip(src,i));
            return dst;
        }

        public static PrimalType primal(Type src)
        {
            if(src == typeof(bit))
                return PrimalType.Intrinsic.U1;
            else if(src == typeof(void))
                return PrimalType.Intrinsic.Void;
            else if(src.IsPrimalNumeric())
                return type(DataTypes.primitive(src.NumericKind()));
            else if(src.IsEnum)
                return type(DataTypes.primitive(src.EnumScalarKind()));
            else if(src == typeof(Null))
                return PrimalType.Intrinsic.Empty;
            else
                Errors.Throw($"{src.Name} is not primitive");
            return PrimalType.Intrinsic.Empty;
        }

        public static PrimalKind primitive(ClrEnumKind scalar)
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

        public static PrimalKind primitive(NumericKind src)
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

        static Type[] candidates(Assembly src)
            => src.Types().Concrete().Where(x => x.IsStruct() || x.IsEnum);

        static object KeyLocker = new();

        static DataTypes()
        {
            init(out _TypeKeys);
        }

        static Index<DataTypeKind,TypeKey> _TypeKeys;

        static void init(out Index<DataTypeKind,TypeKey> dst)
        {
            var kinds = Symbols.index<DataTypeKind>();
            dst = alloc<TypeKey>(kinds.Count);
            for(var i=0; i<kinds.Count; i++)
                dst[kinds[i].Kind] = TypeKey.Empty;
        }
    }
}