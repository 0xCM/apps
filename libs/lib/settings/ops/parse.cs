//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using DP = DataParser;

    partial class Settings
    {
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
        public static Settings parse(ReadOnlySpan<string> src)
        {
            var count = src.Length;

            var buffer = alloc<Setting>(count);
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

        public static Outcome parse<T>(string src, out Setting<T> dst, char delimiter = Chars.Colon)
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