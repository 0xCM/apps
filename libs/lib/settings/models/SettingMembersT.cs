//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct SettingMembers<T>
        where T : new()
    {
        public readonly SettingMembers Data;

        [MethodImpl(Inline), Op]
        public SettingMembers(SettingMembers src)
        {
            Data = src;
        }

        public bool Member(string name, out FieldInfo dst)
            => Data.Member(name, out dst);

        public bool Member(string name, out PropertyInfo dst)
            => Data.Member(name, out dst);

        public string Format()
            => Data.Format();


        public override string ToString()
            => Format();

        [MethodImpl(Inline), Op]
        public static implicit operator SettingMembers<T>(SettingMembers src)
            => new SettingMembers<T>(src);
    }
}