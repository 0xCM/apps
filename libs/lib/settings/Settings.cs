//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    [ApiHost]
    public class Settings
    {
        const NumericKind Closure = UnsignedInts;

        public static Settings64 from(params Setting64[] src)
            => new Settings64(src);

        public static string format<K,V>(K key, V value)
            => string.Format(RP.Setting, key, value);

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

        public static string format(Index<Setting> src, char sep)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format(sep)));
            return dst.Emit();
        }

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

        public static void render(SettingIndex src, ITextEmitter dst)
        {
            for(var i=0; i<src.Count; i++)
                dst.AppendLine(src[i]);
        }

        [Op]
        public static uint store(in SettingIndex src, StreamWriter dst)
        {
            var settings = src.View;
            var count = (uint)settings.Length;
            if(count == 0)
                return count;

            for(var i = 0; i<count; i++)
            {
                ref readonly var setting = ref skip(settings,i);
                dst.WriteLine(string.Format(RpOps.Setting, setting.Name, setting.Value));
            }
            return count;
        }

        public static void store(ReadOnlySpan<Setting> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            Tables.emit(src,emitter);
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

        public static SettingIndex rows(FS.FilePath src)
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
            return new SettingIndex(src,dst);
        }

        public static SettingIndex config(FS.FilePath src, char sep = Chars.Colon)
        {
            var dst = core.list<Setting>();
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
                        var name = text.format(SQ.left(content,i));
                        var value = text.format(SQ.right(content,i));
                        dst.Add(new Setting(name,value));
                    }
                }
            }
            return new SettingIndex(dst.ToArray());
        }

        [MethodImpl(Inline), Op]
        public static Setting64 setting(Name name, asci64 value)
            => new Setting64(name,value);

        [MethodImpl(Inline), Op]
        public static Setting<Name,V> asci<V>(Name name, V value)
            where V : IAsciSeq<V>
                => new Setting<Name,V>(name,value);

        [MethodImpl(Inline)]
        public static Settings<Name,V> asci<V>(params Setting<Name,V>[] src)
            where V : IAsciSeq<V>
                => new Settings<Name,V>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Setting<T> setting<T>(Name name, T value)
            => new Setting<T>(name, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Setting<T> setting<T>(Name name, SettingType type, T value)
            => new Setting<T>(name, type, value);

        [MethodImpl(Inline), Op]
        public static Setting setting(Name name, SettingType type, string value)
            => new Setting(name, type, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Setting<T> setting<T>(Setting src, Func<string,T> parser)
            => new Setting<T>(src.Name, parser(src.ValueText));
    }
}
