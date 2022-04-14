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
            var total = z16;
            var totalE = z16;

            for(var i=z16; i<count; i++)
            {
                ref readonly var field = ref skip(src,i);
                ref var record = ref seek(reflected,i);
                ref var type = ref seek(types,i);
                ref var spec = ref seek(specs,i);

                var tag = field.Tag<RuleFieldAttribute>().Require();
                var kind = tag.Kind;
                var w = (byte)width(field.FieldType);
                var wE = tag.Width;
                type = tag.EffectiveType;
                total = (ushort)(total + (w/8));
                totalE += wE;

                record.Index = i;
                record.FieldWidthE = wE;
                record.FieldWidth = w;
                record.TotalSize = total;
                record.Field = tag.Kind;
                record.TotalWidthE = totalE;
                record.FieldType = new(kind,field.FieldType.DisplayName());
                record.FieldTypeE = new(kind,type.DisplayName());
                record.TotalSizeE = (ushort)(totalE/8 + ((totalE % 8) == 0 ? 0 : 1));
                record.Description = tag.Description;

                spec = new(kind, record.FieldType,record.FieldTypeE, record.FieldWidth, record.FieldWidthE);
            }

            EffectiveFieldTypes = types;
            _Reflected = reflected;
            _Specs = specs;

        }
        static void init()
        {
            var kinds = Symbols.index<FieldKind>().Kinds;
            var count = kinds.Length;
            var src = typeof(RuleState).InstanceFields().Tagged<RuleFieldAttribute>();
            var fields = src.Map(f => (f.Tag<RuleFieldAttribute>().Require().Kind, f)).ToDictionary();

            var reflected = alloc<ReflectedField>(count);

            var specs = alloc<FieldSpec>(count);
            seek(specs,0) = FieldSpec.Empty;

            var types = alloc<Type>(count);
            seek(types,0) = typeof(void);

            var total = z16;
            var totalE = z16;
            var k=1;
            for(var i=z16; i<count; i++,k++)
            {
                ref readonly var kind = ref skip(kinds,i);
                ref var record = ref seek(reflected,k);
                ref var type = ref seek(types,k);
                ref var spec = ref seek(specs,k);
                if(fields.TryGetValue(kind, out var field))
                {
                    var tag = field.Tag<RuleFieldAttribute>().Require();
                    var w = (byte)width(field.FieldType);
                    var wE = tag.Width;
                    type = tag.EffectiveType;
                    total = (ushort)(total + (w/8));
                    totalE += wE;

                    record.Index = (ushort)kind;
                    record.FieldWidthE = wE;
                    record.FieldWidth = w;
                    record.TotalSize = total;
                    record.Field = tag.Kind;
                    record.TotalWidthE = totalE;
                    record.FieldType = new(kind,field.FieldType.DisplayName());
                    record.FieldTypeE = new(kind,type.DisplayName());
                    record.TotalSizeE = (ushort)(totalE/8 + ((totalE % 8) == 0 ? 0 : 1));
                    record.Description = tag.Description;

                    spec = new(kind, record.FieldType,record.FieldTypeE, record.FieldWidth, record.FieldWidthE);
                }
                else
                {
                    Errors.Throw($"{kind} is invalid");
                }
            }

            EffectiveFieldTypes = types;
            _Reflected = reflected;
            _Specs = specs;
        }
    }
}