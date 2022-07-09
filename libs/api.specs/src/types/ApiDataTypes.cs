//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiDataTypes
    {
        public static Index<ApiTypeInfo> describe(Index<ApiDataType> types)
        {
            var count = types.Count;
            var dst = alloc<ApiTypeInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref var record = ref seek(dst,i);
                ref readonly var type = ref types[i];
                record.Part = type.Part;
                record.Name = type.Name;
                record.Concrete = type.Definition.IsConcrete();
                record.NativeSize = type.Size.Native/8;
                record.NativeWidth = type.Size.Native;
                record.PackedWidth = type.Size.Packed;
            }

            return dst;
        }

        public static Index<ApiDataType> discover(Assembly[] src)
        {
            var types = src.Types().Where(t => t.IsEnum || t.IsStruct()).Ignore().Index();
            var count = types.Count;
            var dst = alloc<ApiDataType>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref types[i];
                seek(dst,i) = new ApiDataType(type, Sizes.measure(type));
            }
            return dst.Sort();
        }
    }
}