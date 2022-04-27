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

            var dst = ReflectedFields.init();
            var indexed = ReflectedFields.init();
            var types = alloc<Type>(count);
            var total = FieldSize.Empty;

            for(var i=z8; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                ref var effective = ref seek(types,i);

                var tag = field.Tag<RuleFieldAttribute>().Require();
                var kind = tag.Kind;
                effective = tag.EffectiveType;
                var fwidth = width(field.FieldType);
                var dw = tag.Width;
                var size = new FieldSize(fwidth/8, fwidth, dw/8 + ((dw % 8) == 0 ? 0 : 1), dw);
                total += size;

                ref var record = ref dst[i + 1];
                record.Pos = i;
                record.Field = tag.Kind;
                record.Index = (byte)tag.Kind;
                record.DataType = new(kind, field.FieldType.DisplayName());
                record.DomainType = new(kind, effective.DisplayName());
                record.FieldSize = size;
                record.TotalSize = total;
                record.Description = tag.Description;
                indexed[(byte)tag.Kind] = record;
            }

            EffectiveFieldTypes = types;
            _ReflectedByPos = dst;
            _ReflectedByIndex = indexed.IndexSort();
            _FieldLookup = FieldLookup.create();
        }
    }
}