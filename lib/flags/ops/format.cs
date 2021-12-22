//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Text;

    using static Root;
    using static core;

    partial struct Flags
    {
        [Op, Closures(UInt8k)]
        public static string format<E>(Flags8<E> src, bool enabledOnly = true)
            where E : unmanaged
                => _format(src,enabledOnly);

        [Op, Closures(UInt8k | UInt16k)]
        public static string format<E>(Flags16<E> src, bool enabledOnly = true)
            where E : unmanaged
                => _format(src,enabledOnly);

        [Op, Closures(UInt8k | UInt16k | UInt32k)]
        public static string format<E>(Flags32<E> src, bool enabledOnly = true)
            where E : unmanaged
                => _format(src,enabledOnly);

        [Op, Closures(UnsignedInts)]
        public static string format<E>(Flags64<E> src, bool enabledOnly = true)
            where E : unmanaged
                => _format(src, enabledOnly);

        [Op, Closures(UnsignedInts)]
        public static string format<T>(Flags<T> src)
            where T : unmanaged
                => BitRender.formatter<T>().Format(src.State);

        const string RenderPattern = "{0,-48}: {1}" + Eol;

        [MethodImpl(Inline)]
        static void render(FieldInfo field, bit state, StringBuilder dst, bit enabledOnly)
        {
            if(enabledOnly)
            {
                if(state)
                    dst.AppendFormat(RenderPattern, field.Name, state);
            }
            else
                dst.AppendFormat(RenderPattern, field.Name, state);
        }

        [MethodImpl(Inline)]
        static string _format<E>(IFlags<E> src, bool enabledOnly = true)
            where E : unmanaged
        {
            var type = typeof(E);
            var buffer = new StringBuilder();
            if(type.IsEnum)
            {
                var fields = type.GetFields(ReflectionFlags.BF_All);
                var count = min(fields.Length, src.DataWidth);
                for(byte i=0; i<count; i++)
                    render(skip(fields,i), src[i], buffer, enabledOnly);
            }
            else
            {
                buffer.Append(BitRender.formatter<E>().Format(src.State));
            }
            return buffer.ToString();
        }
    }
}