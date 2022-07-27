//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct SettingMembers
    {
        public readonly ReadOnlySeq<FieldInfo> Fields;

        public readonly ReadOnlySeq<PropertyInfo> Props;

        [MethodImpl(Inline), Op]
        public SettingMembers(FieldInfo[] fields, PropertyInfo[] props)
        {
            Fields = fields;
            Props = props;
        }

        public bool Member(string name, out FieldInfo dst)
        {
            var result = false;
            dst = EmptyVessels.EmptyField;
            for(var i=0; i<Fields.Count; i++)
            {
                ref readonly var member = ref Fields[i];
                if(member.Name == name)
                {
                    dst = member;
                    break;
                }
            }
            return result;
        }

        public bool Member(string name, out PropertyInfo dst)
        {
            var result = false;
            dst = default;
            for(var i=0; i<Fields.Count; i++)
            {
                ref readonly var member = ref Props[i];
                if(member.Name == name)
                {
                    dst = member;
                    break;
                }
            }
            return result;
        }

        public string Format()
        {
            var dst = text.emitter();
            for(var i=0; i<Fields.Count; i++)
            {
                ref readonly var member = ref Fields[i];
                dst.AppendLine($"{member.Name}:{member.FieldType.DisplayName()}");
            }
            for(var i=0; i<Props.Count; i++)
            {
                ref readonly var member = ref Props[i];
                dst.AppendLine($"{member.Name}:{member.PropertyType.DisplayName()}");
            }

            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}