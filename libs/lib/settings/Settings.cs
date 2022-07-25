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

    using DP = DataParser;

    [ApiHost]
    public class Settings
    {
        const NumericKind Closure = UnsignedInts;

        public static Name name(Type src)
            => src.Tag<ConfigAttribute>().MapValueOrElse(tag => tag.Name, () => (Name)src.DisplayName());

        public static Name name<T>()
            => name(typeof(T));


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

        public static string json(Setting src)
            => string.Concat(text.enquote(src.Name), Chars.Colon, Chars.Space, src.ValueText.Enquote());

        [Op]
        public static bool search(in SettingIndex src, Name key, out Setting value)
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

        public static FS.FilePath path(FS.FolderPath dir, string name, FileKind kind)
            => dir + FS.file(name, kind);

        public static Outcome single<T>(FS.FilePath src, char sep, out T dst)
            where T : new()
        {
            var result = Outcome.Success;
            dst = new();
            if(!src.Exists)
                return (false, FS.missing(src));
            return single(src.ReadLines(), sep, out dst);
        }

        public static Outcome single<T>(ReadOnlySpan<string> src, char sep, out T dst)
            where T : new()
        {
            dst = new();
            var settings = parse(src);
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
                    result = parse(setting.Format(sep), type, out var s);
                    if(result.Fail)
                        break;
                    field.SetValue(dst, s.Value);
                }
            }
            return result;
        }

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

        public static Setting parse(string src)
        {
            var i = text.index(src, Chars.Colon);
            var setting = Setting.Empty;
            if(i > 0)
            {
                setting = new Setting(text.trim(text.left(src, i)), text.trim(text.right(src, i)));
            }
            return setting;
        }

        [Op]
        public static SettingIndex parse(ReadOnlySpan<string> src)
        {
            var count = src.Length;

            var buffer = sys.alloc<Setting>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst, i) = parse(skip(src,i));
            return buffer;
        }

        [Parser]
        public static Outcome parse(string src, out Setting<string> dst)
        {
            if(sys.empty(src))
            {
                dst = default;
                return (false, "!!Empty!!");
            }
            else
            {
                var i = src.IndexOf(Chars.Colon);
                if(i == NotFound)
                {
                    dst = default;
                    return (false, "Setting delimiter not found");
                }
                else
                {
                    if(i == 0)
                        dst = new Setting<string>(EmptyString, text.slice(src,i+1));
                    else
                        dst = new Setting<string>(text.slice(src,0, i), text.slice(src,i+1));
                    return true;
                }
            }
        }

        [Op]
        public static SettingIndex parse(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var buffer = span<Setting>(count);
            ref var dst = ref first(buffer);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j > 0)
                {
                    var name = text.left(content, j).Trim();
                    var value = text.right(content, j).Trim();
                    seek(dst, counter++) = new Setting(name, value);
                }
            }
            return slice(buffer,0,counter).ToArray();
        }

        public static Outcome parse(string src, Type type, out Setting dst, char delimiter = Chars.Colon)
        {
            dst = Setting.Empty;
            if(nonempty(src))
            {
                var name = EmptyString;
                var input = src;
                if(SQ.contains(src, delimiter))
                {
                    name = src.LeftOfFirst(delimiter);
                    input = src.RightOfFirst(delimiter);
                }

                if(type == typeof(string))
                {
                    dst = setting(name, SettingType.String, input);
                    return true;
                }
                else if (type == typeof(bool))
                {
                    if(DP.parse(input, out bool value))
                    {
                        dst = setting(name, SettingType.Bool, value);
                        return true;
                    }
                }
                else if(type == typeof(bit))
                {
                    if(DP.parse(input, out bit u1))
                    {
                        dst = setting(name, SettingType.Bit, u1);
                        return true;
                    }
                }
                else if(type.IsPrimalNumeric())
                {
                    if(numeric(input, type, out var n))
                    {
                        type.ClrPrimitiveKind();
                        dst = setting(name, SettingType.Integer, n);
                        return true;
                    }
                }
                else if(type.IsEnum)
                {
                    if(Enums.parse(type, src, out object o))
                    {
                        dst = setting(name, SettingType.Enum, o);
                        return true;
                    }
                }
                else if(src.Length == 1 && type == typeof(char))
                {
                    dst = setting(name, SettingType.Char, name[0]);
                    return true;
                }
            }
            return false;
        }

        public static Outcome parse<T>(string src, out T dst, char delimiter = Chars.Colon)
        {
            dst = Setting<T>.Empty;
            if(nonempty(src))
            {
                var name = EmptyString;
                var input = src;
                if(SQ.contains(src, delimiter))
                {
                    name = src.LeftOfFirst(delimiter);
                    input = src.RightOfFirst(delimiter);
                }

                if(typeof(T) == typeof(string))
                {
                    dst = generic<T>(input);
                    return true;
                }
                else if (typeof(T) == typeof(bool))
                {
                    if(DP.parse(input, out bool value))
                    {
                        dst = generic<T>(value);
                        return true;
                    }
                }
                else if(typeof(T) == typeof(bit))
                {
                    if(DP.parse(input, out bit u1))
                    {
                        dst = generic<T>((bool)u1);
                        return true;
                    }
                }
                else if(DP.numeric(input, out T g))
                {
                    dst = g;
                    return true;
                }
                else if(typeof(T).IsEnum)
                {
                    if(Enums.parse(typeof(T), src, out object o))
                    {
                        dst =(T)o;
                        return true;
                    }
                }
                else if(src.Length == 1 && typeof(T) == typeof(char))
                {
                    dst = generic<T>(name[0]);
                    return true;
                }
            }
            return false;
        }

        static Outcome numeric(string src, Type type, out dynamic dst)
        {
            Outcome result = (false, string.Format("The {0} type is unsupported", type.Name));
            dst = 0;
            if(type.IsUInt8())
            {
                result = DP.parse(src, out byte x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt8())
            {
                result = DP.parse(src, out sbyte x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt16())
            {
                result = DP.parse(src, out short x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt16())
            {
                result = DP.parse(src, out ushort x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt32())
            {
                result = DP.parse(src, out uint x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt32())
            {
                result = DP.parse(src, out int x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt64())
            {
                result = DP.parse(src, out ulong x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt64())
            {
                result = DP.parse(src, out long x);
                if(result)
                    dst = x;
            }
            else if(type.IsFloat32())
            {
                result = DP.parse(src, out float x);
                if(result)
                    dst = x;
            }
            else if(type.IsFloat64())
            {
                result = DP.parse(src, out double x);
                if(result)
                    dst = x;
            }
            return result;
        }
    }
}