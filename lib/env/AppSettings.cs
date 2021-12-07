//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public sealed class AppSettings : AppService<AppSettings>
    {
        public static Outcome<Settings> load(FS.FilePath src)
        {
            Outcome<Settings> dst = Settings.Empty;
            try
            {
                dst = Settings.parse(src.ReadLines());
            }
            catch(Exception e)
            {
                dst = e;
            }
            return dst;
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
                    result = DataParser.setting(setting.Format(), type, out var s);
                    if(result.Fail)
                        break;
                    field.SetValue(dst, s.Value);
                }
            }
            return result;
        }

        public Outcome Store<T>(T src, FS.FilePath dst)
            where T : new()
        {
            var fields = typeof(T).PublicInstanceFields();
            var data = Settings.format(src);
            using var writer = dst.Writer();
            writer.WriteLine(data);
            return true;
        }
    }
}