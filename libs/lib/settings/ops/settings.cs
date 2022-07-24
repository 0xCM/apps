//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SettingIndex
    {
        public static SettingIndex index<T>(T src)
        {
            var _fields = typeof(T).PublicInstanceFields();
            var _props = typeof(T).PublicInstanceProperties();

            var _fieldValues = from f in _fields
                                let value = f.GetValue(src)
                                where f != null
                                select setting(f.Name, value);

            var _propValues = from f in _props
                                let value = f.GetValue(src)
                                where f != null
                                select setting(f.Name, value);

            return _fieldValues.Union(_propValues).Array();
        }
    }
}