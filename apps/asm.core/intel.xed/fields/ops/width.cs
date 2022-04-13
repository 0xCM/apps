//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedFields
    {
        public static ushort width(Type src)
        {
            var result = z16;
            var attrib = src.Tag<DataWidthAttribute>();
            if(src.IsEnum)
                result = (ushort)NativeSizes.convert(PrimalBits.width(Enums.@base(src))).Width;
            else if(attrib.IsSome())
                result = attrib.MapRequired(w => w.StorageWidth == 0 ?  (ushort)w.ContentWidth : (ushort)w.StorageWidth);

            if(result != 0)
                return result;

            if(src == typeof(bit) || src == typeof(byte))
                result = 8;
            else if(src == typeof(ushort))
                result = 16;
            return result;
        }
    }
}
