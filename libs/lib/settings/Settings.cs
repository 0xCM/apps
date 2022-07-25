//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Refs;
    using static Algs;


    [ApiHost]
    public partial class Settings
    {
        const NumericKind Closure = UnsignedInts;

        public static Name name(Type src)
            => src.Tag<ConfigAttribute>().MapValueOrElse(tag => tag.Name, () => (Name)src.DisplayName());

        public static Name name<T>()
            => name(typeof(T));


        public static string json(Setting src)
            => string.Concat(text.enquote(src.Name), Chars.Colon, Chars.Space, src.ValueText.Enquote());

        [Op]
        public static bool search(in SettingLookup src, Name key, out Setting value)
        {
            value = Setting.Empty;
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

        public static FS.FilePath path()
            => FS.path(ExecutingPart.Component.Location).FolderPath + FS.file($"{ExecutingPart.Id.Format()}.settings", FileKind.Csv);

        public static Settings64 from(params Setting64[] src)
            => new Settings64(src);

        public static SettingType type<T>(T src)
            => type(src.GetType());

        public static SettingType type(Type src)
        {
            var dst = SettingType.None;
            if(src == typeof(bool))
                dst = SettingType.Bool;
            else if(src == typeof(string))
                dst = SettingType.String;
            else if(src == typeof(FS.FilePath) || src == typeof(FS.FileUri))
                dst = SettingType.File;
            else if(src == typeof(FS.FolderPath))
                dst = SettingType.Folder;
            return dst;
        }

        [Op]
        public static uint store(in SettingLookup src, char sep, StreamWriter dst)
        {
            var settings = src.View;
            var count = (uint)settings.Length;
            if(count == 0)
                return count;

            for(var i = 0; i<count; i++)
            {
                ref readonly var setting = ref skip(settings,i);
                dst.WriteLine(string.Format("{0}{1}{2}", setting.Name, sep, setting.Value));
            }
            return count;
        }

        public static void store(ReadOnlySpan<Setting> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            Tables.emit(src, emitter);
            using var writer = dst.Writer(encoding);
            writer.Write(emitter.Emit());
        }

        public static void store<T>(ReadOnlySpan<Setting<T>> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            Tables.emit(src, emitter);
            using var writer = dst.Writer(encoding);
            writer.Write(emitter.Emit());
        }

        public static SettingLookup rows(FS.FilePath src)
        {
            var formatter = Tables.formatter<Setting>();
            var data = src.ReadLines(true);
            var dst = sys.alloc<Setting>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line, Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting(text.trim(skip(parts,0)), text.trim(skip(parts,1)));
            }
            return new SettingLookup(src,dst);
        }
    }
}