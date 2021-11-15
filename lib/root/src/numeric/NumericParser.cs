//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static minicore;

    using SP = ScalarParser;

    [ApiHost]
    public readonly struct NumericParser
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static NumericParser<T> create<T>()
            where T : unmanaged
                => default(NumericParser<T>);

        [MethodImpl(Inline), ParseFunction, NumericClosures(AllNumeric)]
        public static bool parse<T>(string src, out T dst)
            => parse_u(src, out dst);

        [MethodImpl(Inline)]
        static bool parse_u<T>(string src, out T dst)
        {
            if(typeof(T) == typeof(byte))
                return parse_8u(src, out dst);
            else if(typeof(T) == typeof(ushort))
                return parse_16u(src, out dst);
            else if(typeof(T) == typeof(uint))
                return parse_32u(src, out dst);
            else if(typeof(T) == typeof(ulong))
                return parse_64u(src, out dst);
            else
                return parse_i(src, out dst);
        }

        [MethodImpl(Inline)]
        static bool parse_i<T>(string src, out T dst)
        {
            if(typeof(T) == typeof(sbyte))
                return parse_8i(src, out dst);
            else if(typeof(T) == typeof(short))
                return parse_16i(src, out dst);
            else if(typeof(T) == typeof(int))
                return parse_32i(src, out dst);
            else if(typeof(T) == typeof(long))
                return parse_64i(src, out dst);
            else
                return parse_f(src, out dst);
        }

        [MethodImpl(Inline)]
        static bool parse_f<T>(string src, out T dst)
        {
            if(typeof(T) == typeof(float))
                return parse_32f(src, out dst);
            else if(typeof(T) == typeof(double))
                return parse_64f(src, out dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Int8k)]
        static bool parse_8i<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out sbyte x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        static bool parse_8u<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out byte x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(UInt16k)]
        static bool parse_16u<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out ushort x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(UInt32k)]
        static bool parse_32u<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out uint x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(UInt64k)]
        static bool parse_64u<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out ulong x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(Int16k)]
        static bool parse_16i<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out short x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(Int32k)]
        static bool parse_32i<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out int x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(Int64k)]
        static bool parse_64i<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out long x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(Float64k)]
        static bool parse_64f<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out double x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op, Closures(Float32k)]
        static bool parse_32f<T>(string src, out T dst)
        {
            if(SP.parse(base10, src, out float x))
            {
                dst = @as<T>(x);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}
