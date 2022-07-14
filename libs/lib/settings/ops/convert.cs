//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = SettingType;

    partial class Settings
    {
        public static void convert<T>(Settings src, out T dst)
            where T : new()
        {
            var fields = typeof(T).PublicInstanceFields().Index();
            dst = new();
            for(var i=0; i<fields.Count; i++)
            {
                ref readonly var field = ref src[i];
                if(src.Find(field.Name, out var s))
                {

                }
            }
        }


        static bool convert(Setting src, Type type, out object dst)
        {
            var result = false;
            dst = EmptyString;
            switch(src.Type)
            {
                case K.Asci16:
                break;
                case K.Asci32:
                break;
                case K.Asci64:
                break;
                case K.Bit:
                break;
                case K.Bool:
                break;
            }
            return result;
        }


    }
}