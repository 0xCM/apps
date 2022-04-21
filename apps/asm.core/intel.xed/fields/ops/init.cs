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
            var src = typeof(OperandState).InstanceFields().Tagged<RuleFieldAttribute>();
            var count = src.Length;

            var positional = ReflectedFields.init();
            var indexed = ReflectedFields.init();
            var types = alloc<Type>(count);
            var total = FieldSize.Empty;

            for(var i=z8; i<count; i++)
            {
                ref readonly var field = ref skip(src,i);
                ref var type = ref seek(types,i);

                var tag = field.Tag<RuleFieldAttribute>().Require();
                var kind = tag.Kind;
                type = tag.EffectiveType;
                var fwidth = width(field.FieldType);
                var dw = tag.Width;
                var size = new FieldSize(fwidth/8, fwidth, dw/8 + ((dw % 8) == 0 ? 0 : 1), dw);
                total += size;

                ref var dst = ref positional[i + 1];
                dst.Pos = i;
                dst.Field = tag.Kind;
                dst.Index = (byte)tag.Kind;
                dst.DataType = new(kind,field.FieldType.DisplayName());
                dst.DomainType = new(kind,type.DisplayName());
                dst.FieldSize = size;
                dst.TotalSize = total;
                dst.Description = tag.Description;
                indexed[(byte)tag.Kind] = dst;

            }

            EffectiveFieldTypes = types;
            _ReflectedByPos = positional;
            _ReflectedByIndex = indexed.IndexSort();
            _FieldLookup = FieldLookup.create();
        }
    }
}