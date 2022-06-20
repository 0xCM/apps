//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class EnvSets
    {
        public static void render<T>(Settings<T> src, ITextEmitter dst)
            => Tables.emit(src.View, dst);

        [Op]
        public static bool search<T>(in Settings<T> src, string key, out Setting<T> value)
        {
            value = Setting<T>.Empty;
            var result = false;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var setting = ref src[i];
                if(string.Equals(setting.Name, key, NoCase))
                {
                    value = setting;
                    result = true;
                }
            }
            return result;
        }

        public static EnvSet<S> load<S>(string name, S src)
            where S : struct
                => new EnvSet<S>(name, src, ClrFields.values(src).Select(x => new Setting<string,object>(x.Field.Name, x.Value)));

        public static Settings config(FS.FilePath src, char sep = Chars.Colon)
        {
            var dst = list<Setting>();
            var line = AsciLine.Empty;
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
                        var name = text.format(SQ.left(content,i));
                        var value = text.format(SQ.right(content,i));
                        dst.Add(new Setting(name,value));
                    }
                }
            }
            return new Settings(dst.ToArray());
        }

        public static EnvVars<string> load(FS.FilePath src, char sep)
        {
            var k = z16;
            var dst = list<EnvVar<string>>();
            var line = AsciLine.Empty;
            var buffer = alloc<char>(1024*4);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var i = SQ.index(content, sep);
                if(i == NotFound)
                    continue;

                var _name = text.format(SQ.left(content,i), buffer);
                var _value = text.format(SQ.right(content,i), buffer);
                dst.Add(new (_name, _value));
            }
            return dst.ToArray().Sort();
        }
    }
}