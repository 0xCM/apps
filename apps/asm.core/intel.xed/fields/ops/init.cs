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
        static void TypeInit()
        {
            var fields = typeof(OperandState).InstanceFields().Tagged<RuleFieldAttribute>();
            var count = fields.Length;

            var positioned = ReflectedFields.init();
            var indexed = ReflectedFields.init();
            var types = alloc<Type>(count);
            var packed = z16;
            var native = z16;

            for(var i=z8; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                ref var type = ref seek(types,i);
                ref var dst = ref positioned[i + 1];

                var tag = field.Tag<RuleFieldAttribute>().Require();
                var nwidth = width(field.FieldType);
                var pwidth = tag.Width;
                var index = (byte)tag.Kind;
                type = tag.EffectiveType;
                dst.Pos = i;
                dst.Field = tag.Kind;
                dst.Index = index;
                dst.DataType = type.DisplayName();
                dst.NativeType = field.FieldType.DisplayName();
                dst.NativeWidth = nwidth;
                dst.NativeOffset = native;
                dst.PackedWidth = new DataSize(pwidth);
                dst.PackedOffset = packed;
                dst.Description = tag.Description;
                indexed[index] = dst;

                packed += pwidth;
                native += nwidth;
            }

            EffectiveFieldTypes = types;
            _ReflectedByPos = positioned;
            _ReflectedByIndex = indexed.IndexSort();
            _FieldLookup = FieldLookup.create();
        }
    }
}