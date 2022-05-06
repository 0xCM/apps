//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = DataTypes;

    [ApiHost]
    public readonly struct DataTypes
    {
        public static DataSize measure(Type src)
        {
            var tag = src.Tag<DataWidthAttribute>();
            var dst = DataSize.Empty;
            if(src.IsEnum)
            {
                var native = bitwidth(PrimalBits.width(Enums.@base(src)));
                if(tag)
                    dst = (tag.Value.PackedWidth, native);
                else
                    dst = (native,native);
            }
            else
            {
                if(tag)
                {
                    dst = tag.Value.DataSize;
                }
                else
                {
                    var width = SizeCalc.width(src);
                    dst = (width,width);
                }
            }
            return dst;
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

        public static Index<DataType> discover(Assembly src)
            => src.TaggedTypes<DataWidthAttribute>().Select(x => new DataType(x.Type.Name, x.Tag.DataSize));

        public static Index<DataType> discover(Assembly[] src)
            => src.TaggedTypes<DataWidthAttribute>().Select(x => new DataType(x.Type.Name, x.Tag.DataSize));

        public static Index<DataType> discover(Type[] src)
            => src.Tagged<DataWidthAttribute>().Select(x => new DataType(x.Name, x.RequiredTag<DataWidthAttribute>().DataSize));

        static uint bitwidth(NativeTypeWidth src)
        {
            var dst = (uint)src;
            if(dst == 1)
                dst = 8;
            return dst;
        }

        readonly struct SizeCalc<T>
        {
            [MethodImpl(Inline)]
            public static int calc()
                => Unsafe.SizeOf<T>();
        }

        readonly struct SizeCalc
        {
            public static uint width(Type src)
            {
                if(src is null || src == typeof(void) || src == typeof(Null))
                    return 0;

                var type = typeof(SizeCalc<>).MakeGenericType(src);
                var method = first(type.StaticMethods().Public());
                return ((uint)method.Invoke(null, sys.empty<object>()))*8;
            }

            public static uint width<T>()
                => width(typeof(T));
        }
    }

    partial class XTend
    {
        public static Index<DataType> DataTypes(this Assembly[] src)
            => api.discover(src);

        public static Index<DataType> DataTypes(this Type[] src)
            => api.discover(src);

        public static Index<DataType> DataTypes(this Index<Type> src)
            => api.discover(src);

        public static Index<DataType> DataTypes(this Assembly src)
            => api.discover(src);

        public static Index<DataType> DataTypes(this Index<Assembly> src)
            => api.discover(src);
    }
}