//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct DataTypes
    {
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

        public static DataSize measure(Type src)
        {
            var dst = DataSize.Empty;
            try
            {
                var tag = src.Tag<DataWidthAttribute>();
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

                        dst = (tag.Value.PackedWidth, Sizes.bitwidth(src));
                    }
                    else
                    {
                        var width = Sizes.bitwidth(src);
                        dst = (width,width);
                    }
                }
            }
            catch(AmbiguousMatchException)
            {
                term.error($"Ambiguous {nameof(DataWidthAttribute)} match on {src.DisplayName()}");
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

        public static Index<DataType> discover(Assembly src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(candidates(src), t => dst.Add(new DataType(t.Name, measure(t))),pll);
            return dst.ToArray().Sort();
        }

        public static Index<DataType> discover(Assembly[] src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(src, a =>  iter(candidates(a), t => dst.Add(new DataType(t.Name, measure(t))),pll),pll);
            return dst.Index().Sort();
        }

        public static Index<DataType> discover(Type[] src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(src, t => dst.Add(new DataType(t.Name, measure(t))),pll);
            return dst.Index().Sort();
        }

        static DataTypeRecord record(Type src)
        {
            var dst = default(DataTypeRecord);
            var size = measure(src);
            dst.Name = src.Name;
            dst.Part = src.Assembly.PartName();
            dst.PackedWidth = size.PackedWidth;
            dst.NativeWidth = size.NativeWidth;
            dst.PackedSize = size.PackedWidth != 0 ? (size.PackedWidth/8 + (size.PackedWidth % 8 == 0 ? 0 : 1)) : 0;
            dst.NativeSize = size.NativeWidth/8;
            return dst;
        }

        static Type[] candidates(Assembly src)
            => src.Types().Concrete().Where(x => x.IsStruct() || x.IsEnum);

        static uint bitwidth(NativeTypeWidth src)
        {
            var dst = (uint)src;
            if(dst == 1)
                dst = 8;
            return dst;
        }
    }

    partial class XTend
    {
        // public static Index<DataType> DataTypes(this Assembly[] src)
        //     => api.discover(src);

        // public static Index<DataType> DataTypes(this Type[] src)
        //     => api.discover(src);

        // public static Index<DataType> DataTypes(this Index<Type> src)
        //     => api.discover(src);

        // public static Index<DataType> DataTypes(this Assembly src)
        //     => api.discover(src);

        // public static Index<DataType> DataTypes(this Index<Assembly> src)
        //     => api.discover(src);
    }
}