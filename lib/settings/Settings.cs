//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;

    using static core;

    using DP = DataParser;

    [ApiHost]
    public class Settings : IIndex<Setting>, ILookup<string,Setting>
    {
        public static Index<Setting> load(FS.FilePath src)
        {
            var formatter = Tables.formatter<Setting>();
            var data = src.ReadLines(true);
            var dst = alloc<Setting>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line,Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting(skip(parts,0), skip(parts,1));
            }
            return dst;
        }

        public static Index<Setting<T>> load<T>(FS.FilePath src, Func<string,T> parser)
        {
            var formatter = Tables.formatter<Setting<T>>();
            var data = src.ReadLines(true);
            var dst = alloc<Setting<T>>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line,Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting<T>(skip(parts,0), parser(skip(parts,1)));
            }
            return dst;
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
            Tables.emit(src,emitter);
            using var writer = dst.Writer(encoding);
            writer.Write(emitter.Emit());
        }

        [Op]
        public static Settings parse(ReadOnlySpan<string> src)
        {
            var count = src.Length;

            var buffer = alloc<Setting>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst, i) = parse(skip(src,i));
            return buffer;
        }

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
        public static Settings parse(ReadOnlySpan<TextLine> src)
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


        public static Settings from<T>(T src)
        {
            var _fields = typeof(T).PublicInstanceFields();
            var _props = typeof(T).PublicInstanceProperties();
            var _fieldValues = from f in _fields
                                let value = f.GetValue(src)
                                where f != null
                                select new Setting(f.Name, value);

            var _propValues = from f in _props
                                let value = f.GetValue(src)
                                where f != null
                                select new Setting(f.Name, value);

            return _fieldValues.Union(_propValues).Array();
        }


        const NumericKind Closure = UnsignedInts;

        readonly Index<Setting> Data;

        [MethodImpl(Inline)]
        public Settings(Setting[] src)
            => Data = src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Setting<T> empty<T>()
            => Setting<T>.Empty;

        [MethodImpl(Inline)]
        public static Setting empty()
            => Setting.Empty;

        public ref Setting this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Setting this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            get => Data.Length;
        }

        public Setting[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Span<Setting> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<Setting> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public bool Lookup(string key, out Setting value)
            => search(this,key,out value);

        public string Format()
            => format(Data);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Settings(Setting[] src)
            => new Settings(src);

        [MethodImpl(Inline)]
        public static implicit operator Setting[](Settings src)
            => src.Storage;

        public static Outcome parse(string src, Type type, out Setting dst, char delimiter = Chars.Colon)
        {
            dst = Settings.empty();
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
                    dst = (name, input);
                    return true;
                }
                else if (type == typeof(bool))
                {
                    if(DP.parse(input, out bool value))
                    {
                        dst = (name, value);
                        return true;
                    }
                }
                else if(type == typeof(bit))
                {
                    if(DP.parse(input, out bit u1))
                    {
                        dst = (name, u1);
                        return true;
                    }
                }
                else if(type.IsPrimalNumeric())
                {
                    if(DP.numeric(input, type, out var n))
                    {
                        dst = (name,n);
                        return true;
                    }
                }
                else if(type.IsEnum)
                {
                    if(Enums.parse(type, src, out object o))
                    {
                        dst = (name, o);
                        return true;
                    }
                }
                else if(src.Length == 1 && type == typeof(char))
                {
                    dst = (name, name[0]);
                    return true;
                }
            }
            return false;
        }

        public static Outcome parse<T>(string src, out Setting<T> dst, char delimiter = Chars.Colon)
        {
            dst = Settings.empty<T>();
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
                    dst = (name, generic<T>(input));
                    return true;
                }
                else if (typeof(T) == typeof(bool))
                {
                    if(DP.parse(input, out bool value))
                    {
                        dst = (name, generic<T>(value));
                        return true;
                    }
                }
                else if(typeof(T) == typeof(bit))
                {
                    if(DP.parse(input, out bit u1))
                    {
                        dst = (name, generic<T>((bool)u1));
                        return true;
                    }
                }
                else if(DP.numeric(input, out T g))
                {
                    dst = (name, g);
                    return true;
                }
                else if(typeof(T).IsEnum)
                {
                    if(Enums.parse(typeof(T), src, out object o))
                    {
                        dst = (name, (T)o);
                        return true;
                    }
                }
                else if(src.Length == 1 && typeof(T) == typeof(char))
                {
                    dst = (name, generic<T>(name[0]));
                    return true;
                }
            }
            return false;
        }

        [Op]
        public static uint save(in Settings src, StreamWriter dst)
        {
            var settings = src.View;
            var count = (uint)settings.Length;
            if(count == 0)
                return count;

            for(var i = 0; i<count; i++)
            {
                ref readonly var setting = ref skip(settings,i);
                dst.WriteLine(string.Format(RP.Setting, setting.Name, setting.Value));
            }
            return count;
        }

        [Op]
        public static bool search(in Settings src, string key, out Setting value)
        {
            var view = src.Data.View;
            var count = src.Data.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref skip(view,i);
                if(string.Equals(setting.Name, key, NoCase))
                {
                    value = setting;
                    return true;
                }
            }
            value = Setting.Empty;
            return false;
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

        public static string format(Index<Setting> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            return dst.Emit();
        }

        [Op, Closures(Closure)]
        public static string format<T>(Setting<T> src)
            => string.Format(RP.Setting, src.Name, src.Value);

        public static string format(Setting src, bool json)
        {
            if(json)
                return string.Concat(src.Name.Enquote(), Chars.Colon, Chars.Space, src.Value.Enquote());
            else
                return format(core.ifempty(src.Name, "<anonymous>"), src.Value);
        }

        /// <summary>
        /// Renders a k/v pair as a setting
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        [MethodImpl(Inline), Op]
        public static string format<K,V>(K key, V value)
            => string.Format(RP.Setting, key, value);


        public static Settings Empty => new Settings(sys.empty<Setting>());
    }
}