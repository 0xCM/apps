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
            var src = typeof(RuleState).InstanceFields().Tagged<RuleFieldAttribute>();
            var count = src.Length;

            //var reflected = alloc<ReflectedField>(count);
            var reflected = ReflectedFields.init();
            var specs = alloc<FieldSpec>(count);
            var types = alloc<Type>(count);
            var total = FieldSize.Empty;

            for(var i=z16; i<count; i++)
            {
                ref readonly var field = ref skip(src,i);
                ref var type = ref seek(types,i);
                ref var spec = ref seek(specs,i);

                var tag = field.Tag<RuleFieldAttribute>().Require();
                var kind = tag.Kind;
                type = tag.EffectiveType;
                var fwidth = width(field.FieldType);
                var dw = tag.Width;
                var size = new FieldSize(fwidth/8, fwidth, dw/8 + ((dw % 8) == 0 ? 0 : 1), dw);
                total += size;

                ref var dst = ref reflected[i + 1];
                dst.Index = i;
                dst.Field = tag.Kind;
                dst.DataKind = new(kind,field.FieldType.DisplayName());
                dst.DomainType = new(kind,type.DisplayName());
                dst.FieldSize = size;
                dst.TotalSize = total;
                dst.Description = tag.Description;

                spec = new(kind,  size, dst.DataKind, dst.DomainType);
            }

            EffectiveFieldTypes = types;
            _Reflected = reflected;
            _Specs = specs;
        }
    }
}