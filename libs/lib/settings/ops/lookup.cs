//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
        [MethodImpl(Inline), Op]
        public static SettingMembers members(Type src)
            => new (src.PublicInstanceFields().Where(f => !f.IsInitOnly), src.PublicInstanceProperties().WithSet());

        public static SettingMembers<T> members<T>()
            where T : new()
                => new SettingMembers<T>(members(typeof(T)));

        public static T hydrate<T>(SettingLookup src)
            where T : new()
        {
            var dst = new T();
            var m = members<T>();
            foreach(var member in m.Data.Fields)
            {
                if(src.Find(member.Name, out var setting))
                    member.SetValue(dst, setting.Value);
            }

            return dst;
        }

        public static SettingLookup<T> lookup<T>(T src)
            where T : new()
                => new (typeof(T).PublicInstanceFields().Select(f => new Setting(f.Name, f.GetValue(src))));
    }
}