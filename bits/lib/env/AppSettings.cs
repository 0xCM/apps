//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    using SQ = SymbolicQuery;

    public sealed class AppSettings : AppService<AppSettings>
    {
        public static string format<T>(in T src)
        {
            var fields = typeof(T).PublicInstanceFields();
            var count = fields.Length;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendLineFormat("{0}:{1}",field.Name, field.GetValue(src));
            }
            return dst.Emit();
        }

        public static Outcome<Settings> load(FS.FilePath src)
        {
            try
            {
                var dst = list<Setting>();
                using var reader = src.AsciLineReader();
                while(reader.Next(out var line))
                {
                    var content = line.Codes;
                    var length = content.Length;
                    if(length != 0)
                    {
                        if(SQ.hash(first(content)))
                            continue;

                        var i = SQ.index(content, Chars.Colon);
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
            catch(Exception e)
            {
                return e;
            }
        }

        public Settings Load(FS.FilePath src)
        {
            var result = load(src);
            if(result)
            {
                return result.Data;
            }
            else
            {
                Error(result.Message);
                return Settings.Empty;
            }
        }

        public Settings Load(ReadOnlySpan<TextLine> src)
        {
            var dst = Settings.Empty;
            try
            {
                dst = Settings.parse(src);
            }
            catch(Exception e)
            {
                Error(e);
            }

            return dst;
        }

        public Outcome Load<T>(FS.FilePath src, out T dst)
            where T : new()
        {
            var result = Outcome.Success;
            dst = new();
            if(!src.Exists)
                return (false, FS.missing(src));
            var settings = src.ReadLines();
            return Load(settings, out dst);
        }

        public Outcome Load<T>(ReadOnlySpan<string> src, out T dst)
            where T : new()
        {
            dst = new();
            var settings = Settings.parse(src);
            var result = Outcome.Success;
            var fields = typeof(T).PublicInstanceFields().Select(x => (x.Name,x)).ToDictionary();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref settings[i];
                if(setting.IsEmpty)
                    continue;

                if(fields.TryGetValue(setting.Name, out var field))
                {
                    var type = field.FieldType;
                    result = Settings.parse(setting.Format(), type, out var s);
                    if(result.Fail)
                        break;
                    field.SetValue(dst, s.Value);
                }
            }
            return result;
        }

        public Outcome Save<T>(T src, FS.FilePath dst)
            where T : new()
        {
            using var writer = dst.Writer();
            writer.WriteLine(format(src));
            return true;
        }
    }
}