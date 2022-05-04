//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedFields
    {
        static uint width(Type src)
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

        static void TypeInit()
        {
            var fields = typeof(OperandState).InstanceFields().Tagged<RuleFieldAttribute>();
            var count = fields.Length;

            var positioned = ReflectedFields.init();
            var indexed = ReflectedFields.init();
            var types = alloc<Type>(count);
            var packed = z32;
            var aligned = z32;

            for(var i=z8; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                ref var type = ref seek(types,i);
                ref var dst = ref positioned[i + 1];

                var tag = field.Tag<RuleFieldAttribute>().Require();
                var awidth = width(field.FieldType);
                var pwidth = tag.Width;
                var index = (byte)tag.Kind;
                type = tag.EffectiveType;
                dst.Pos = i;
                dst.Field = tag.Kind;
                dst.Index = index;
                dst.DataType = type.DisplayName();
                dst.NativeType = field.FieldType.DisplayName();
                dst.PackedWidth = pwidth;
                dst.AlignedWidth = awidth;
                dst.PackedOffset = packed;
                dst.AlignedOffset = aligned;
                dst.Description = tag.Description;
                indexed[index] = dst;
                packed += pwidth;
                aligned += awidth;
            }

            EffectiveFieldTypes = types;
            _ReflectedByPos = positioned;
            _ReflectedByIndex = indexed.IndexSort();
        }
    }
}