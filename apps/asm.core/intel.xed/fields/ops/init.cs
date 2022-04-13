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
            var k=1;
            for(var i=1; i<count; i++,k++)
            {
                ref readonly var kind = ref skip(kinds,i);
                ref var record = ref seek(reflected,k);
                ref var type = ref seek(types,k);
                ref var spec = ref seek(specs,k);
                if(fields.TryGetValue(kind, out var field))
                {
                    var tag = field.Tag<RuleFieldAttribute>().Require();
                    var dw = (byte)width(field.FieldType);
                    type = tag.EffectiveType;
                    total = (ushort)(total + (dw/8));
                    record.Index = (ushort)kind;
                    record.EffectiveWidth = tag.Width;
                    record.FieldWidth = dw;
                    record.TotalSize = total;
                    record.Field = tag.Kind;
                    record.FieldType = new(kind,field.FieldType.DisplayName());
                    record.EffectiveType = new(kind,type.DisplayName());
                    record.Description = tag.Description;

                    spec = new(kind, record.FieldType,record.EffectiveType, record.FieldWidth, record.EffectiveWidth);
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