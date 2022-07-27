//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    using DP = DataParser;
    using NP = NumericParser;

    partial class Settings
    {
        public static bool parse<T>(ReadOnlySpan<string> src, char sep, out T dst)
            where T : new()
        {
            dst = new();
            var settings = parse(src, sep);
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
                    result = parse(setting.Format(sep), type, sep, out var s);
                    if(result.Fail)
                        break;
                    field.SetValue(dst, s.Value);
                }
            }
            return result;
        }

        public static Setting parse(string src, char sep)
        {
            var i = text.index(src, sep);
            var setting = Setting.Empty;
            if(i > 0)
                setting = new Setting(text.trim(text.left(src, i)), text.trim(text.right(src, i)));
            return setting;
        }

        [Op]
        public static SettingLookup parse(ReadOnlySpan<string> src, char sep)
        {
            var count = src.Length;
            var dst = sys.alloc<Setting>(count);
            for(var i=0; i<count; i++)
                seek(dst, i) = parse(skip(src,i), sep);
            return new (dst);
        }

        [Parser]
        public static Outcome parse(string src, char sep, out Setting<string> dst)
        {
            if(sys.empty(src))
            {
                dst = default;
                return (false, "!!Empty!!");
            }
            else
            {
                var i = src.IndexOf(sep);
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
        public static SettingLookup parse(ReadOnlySpan<TextLine> src, char sep)
        {
            var count = src.Length;
            var buffer = span<Setting>(count);
            ref var dst = ref first(buffer);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                var content = line.Content;
                var j = text.index(content, sep);
                if(j > 0)
                {
                    var name = text.left(content, j).Trim();
                    var value = text.right(content, j).Trim();
                    seek(dst, counter++) = new Setting(name, value);
                }
            }
            return new(slice(buffer,0,counter).ToArray());
        }

        public static Outcome parse(string src, Type type, char sep, out Setting dst)
        {
            dst = Setting.Empty;
            if(nonempty(src))
            {
                var name = EmptyString;
                var input = src;
                if(SQ.contains(src, sep))
                {
                    name = src.LeftOfFirst(sep);
                    input = src.RightOfFirst(sep);
                }

                if(type == typeof(string))
                {
                    dst = setting(name, SettingType.String, input);
                    return true;
                }
                else if (type == typeof(bool))
                {
                    if(BitParser.semantic(input, out var value))
                    {
                        dst = setting(name, SettingType.Bool, value);
                        return true;
                    }
                }
                else if(type == typeof(bit))
                {
                    if(BitParser.parse(input, out bit u1))
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

        public static Outcome parse<T>(string src, char sep, out T dst)
        {
            dst = Setting<T>.Empty;
            if(nonempty(src))
            {
                var name = EmptyString;
                var input = src;
                if(SQ.contains(src, sep))
                {
                    name = src.LeftOfFirst(sep);
                    input = src.RightOfFirst(sep);
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

        static bool numeric(string src, Type type, out dynamic dst)
        {
            Outcome result = (false, string.Format("The {0} type is unsupported", type.Name));
            dst = 0;
            if(type.IsUInt8())
            {
                result = NP.parse(src, out byte x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt8())
            {
                result = NP.parse(src, out sbyte x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt16())
            {
                result = NP.parse(src, out short x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt16())
            {
                result = NP.parse(src, out ushort x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt32())
            {
                result = NP.parse(src, out uint x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt32())
            {
                result = NP.parse(src, out int x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt64())
            {
                result = NP.parse(src, out ulong x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt64())
            {
                result = NP.parse(src, out long x);
                if(result)
                    dst = x;
            }
            else if(type.IsFloat32())
            {
                result = NP.parse(src, out float x);
                if(result)
                    dst = x;
            }
            else if(type.IsFloat64())
            {
                result = NP.parse(src, out double x);
                if(result)
                    dst = x;
            }
            return result;
        }
    }
}