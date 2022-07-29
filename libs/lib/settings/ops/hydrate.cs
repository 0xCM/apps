//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
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
    }
}