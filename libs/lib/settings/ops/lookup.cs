//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    partial class Settings
    {
        public static SettingLookup lookup<T>(T src)
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

        public static SettingLookup lookup(FS.FilePath src, char sep)
        {
            var dst = list<Setting>();
            var line = AsciLineCover.Empty;
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, sep);
                    if(i > 0)
                    {
                        var name = Asci.format(SQ.left(content,i));
                        var value = Asci.format(SQ.right(content,i));
                        dst.Add(new Setting(name,value));
                    }
                }
            }
            return new SettingLookup(dst.ToArray());
        }
    }
}