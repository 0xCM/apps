//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json;

    using static Root;
    using static Chars;
    using static core;

    /// <summary>
    /// Defines the canonical <see cref='IJsonSettings'/> reification
    /// </summary>
    public class JsonSettings : IJsonSettings
    {
        public static void Save<S>(S src, FS.FilePath dst)
            where S : ISettingsProvider
        {
            const string indent = "    ";

            var settings = src.Settings.View;
            if(settings.Length != 0)
            {
                using var writer = dst.Writer();
                writer.WriteLine(LBrace);
                for(var i = 0; i<settings.Length; i++)
                {
                    var line = indent + settings[i].Format();
                    if(i != settings.Length - 1)
                        line += Chars.Comma;
                    writer.WriteLine(line);
                }
                writer.WriteLine(RBrace);
            }
        }

        public static S load<S>(IJsonSettings src)
            where S : new()
        {
            var dst = new S();
            foreach(var name in SettingNames<S>())
                src.Setting(name).OnSome(value => WriteSetting(name, value, dst));
            return dst;
        }

        public static IJsonSettings Load(FS.FilePath src)
        {
            var dst = new Dictionary<string,string>();
            if(src.Exists)
            {
                JsonData.absorb(src, dst);
                return new JsonSettings(dst.Select(kvp => (kvp.Key, kvp.Value)));
            }
            else
            {
                return JsonSettings.Empty;
            }
        }

        public static string format<S>(S src)
            where S : IJsonSettings
        {
            var dst = text.buffer();
            var settings = @readonly(src.All.Array());
            var count = settings.Length;
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref skip(settings,i);
                var value = JsonSerializer.Serialize(setting.Value);
                dst.AppendFormat("{0}: {1}", setting.Name, value);
                if(i != count - 1)
                    dst.Append(Chars.Comma);
                dst.AppendLine();
            }

            dst.AppendLine(Chars.RBrace);
            return dst.Emit();
        }

        internal JsonSettings(IEnumerable<(string,string)> pairs)
            => Pairs = pairs.Select(pair => new KeyValuePair<string, string>(pair.Item1, pair.Item2)).ToArray();

        internal JsonSettings(IEnumerable<KeyValuePair<string,string>> pairs)
            => Pairs = pairs.ToArray();

        IEnumerable<KeyValuePair<string,string>> Pairs {get;}

        public Option<string> Setting(string name)
        {
            var matches = Pairs.Where(p => p.Key == name).ToArray();
            if(matches.Length == 0)
                return Option.none<string>();
            else
                return matches[0].Value;
        }

        public IEnumerable<ISetting> All
            => from p in Pairs select new Setting(p.Key, p.Value) as ISetting;

        public string this[string name]
            => Setting(name).ValueOrDefault(string.Empty);

        static Option<S> WriteSetting<S>(string name, string value, S dst)
        {
            try
            {
                var wf = from p in typeof(S).Property(name)
                         let v = Convert.ChangeType(value, p.PropertyType)
                         from r in p.Write(v, dst)
                         select (S)r;
                return wf;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e);
                return Option.none<S>();
            }
        }

        static IEnumerable<FieldInfo> SettingFields<S>()
            => typeof(S).InstanceFields();

        static IEnumerable<PropertyInfo> SettingProperties<S>()
            => from p in typeof(S).InstanceProperties()
                where p.HasPublicGetter() && p.HasPublicSetter()
                select p;

        static IEnumerable<MemberInfo> SettingMembers<S>()
            => SettingProperties<S>().Cast<MemberInfo>().Union(SettingFields<S>());

        static IEnumerable<string> SettingNames<S>()
            => SettingMembers<S>().Select(m => m.Name);

        static IEnumerable<Setting> PropSettings<S>(object src)
            => SettingProperties<S>().Select(p => new Setting(p.Name, p.GetValue(src)?.ToString() ?? EmptyString));

        static IEnumerable<Setting> FieldSettings<S>(object src)
            => SettingFields<S>().Select(p => new Setting(p.Name, p.GetValue(src)?.ToString() ?? EmptyString));

        public static IEnumerable<Setting> Settings<S>(object src)
            => PropSettings<S>(src).Union(FieldSettings<S>(src));

        public static IJsonSettings Empty
            => new JsonSettings(new KeyValuePair<string,string>[]{});
    }
}