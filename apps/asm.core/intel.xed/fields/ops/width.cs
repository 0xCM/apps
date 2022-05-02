//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedFields
    {
        public static uint width(Type src)
        {
            var result = z32;
            var attrib = src.Tag<DataWidthAttribute>();
            if(src.IsEnum)
                result = MeasuredType.bitwidth(PrimalBits.width(Enums.@base(src)));
            else if(attrib.IsSome())
                result = attrib.MapRequired(w => w.StorageWidth == 0 ?  (uint)w.ContentWidth : (uint)w.StorageWidth);

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
