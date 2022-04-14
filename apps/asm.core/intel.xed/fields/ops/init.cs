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
            var reflected = alloc<ReflectedField>(count);
            var specs = alloc<FieldSpec>(count);
            var types = alloc<Type>(count);
            var szTotal = z16;
            var dwTotal = z16;

            for(var i=z16; i<count; i++)
            {
                ref readonly var field = ref skip(src,i);
                ref var record = ref seek(reflected,i);
                ref var type = ref seek(types,i);
                ref var spec = ref seek(specs,i);

                var tag = field.Tag<RuleFieldAttribute>().Require();
                var kind = tag.Kind;
                var fw = (byte)width(field.FieldType);
                var fsize = (byte)(fw/8);
                var dw = tag.Width;
                type = tag.EffectiveType;
                szTotal = (ushort)(szTotal + fsize);
                dwTotal += dw;

                record.Index = i;
                record.DataSize = fsize;
                record.DataWidth = fw;
                record.DomainWidth = dw;
                record.Field = tag.Kind;
                record.DataKind = new(kind,field.FieldType.DisplayName());
                record.DomainType = new(kind,type.DisplayName());
                record.DomainSizeT = (ushort)(dwTotal/8 + ((dwTotal % 8) == 0 ? 0 : 1));
                record.DataSizeT = szTotal;
                record.DataWidthT = (ushort)(szTotal*8);
                record.DomainWidthT = dwTotal;
                record.Description = tag.Description;

                spec = new(kind, record.DataKind,record.DomainType, fw, dw);
            }

            EffectiveFieldTypes = types;
            _Reflected = reflected;
            _Specs = specs;
        }
    }
}