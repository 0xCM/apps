//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    readonly struct FlagFormatters
    {
        public abstract class FlagFormatter<F,W,E,T> : IFormatter<T>
            where E : unmanaged, Enum
            where W : unmanaged, ITypeWidth
            where F : FlagFormatter<F,W,E,T>, new()
            where T : unmanaged
        {
            public abstract string Format(T src);
        }

        public sealed class Enum8Formatter<E> : FlagFormatter<Enum8Formatter<E>, W8, E, Flags8<E>>
            where E : unmanaged, Enum
        {
            public override string Format(Flags8<E> src)
                => format(src);
        }

        public sealed class Enum16Formatter<E> : FlagFormatter<Enum16Formatter<E>, W16, E, Flags16<E>>
            where E : unmanaged, Enum
        {
            public override string Format(Flags16<E> src)
                => format(src);
        }

        public sealed class Enum32Formatter<E> : FlagFormatter<Enum32Formatter<E>, W32, E, Flags32<E>>
            where E : unmanaged, Enum
        {
            public override string Format(Flags32<E> src)
                => format(src);
        }

        public sealed class Enum64Formatter<E> : FlagFormatter<Enum64Formatter<E>, W64, E, Flags64<E>>
            where E : unmanaged, Enum
        {
            public override string Format(Flags64<E> src)
                => format(src);
        }

        static string format<E>(Flags8<E> src)
            where E : unmanaged, Enum
                => _format(src);

        static string format<E>(Flags16<E> src)
            where E : unmanaged, Enum
                => _format(src);

        static string format<E>(Flags32<E> src)
            where E : unmanaged, Enum
                => _format(src);

        static string format<E>(Flags64<E> src)
            where E : unmanaged, Enum
                => _format(src);

        [MethodImpl(Inline)]
        static string _format<F,W,E>(IFlags<F,E,W> src, bool enabledOnly = true)
            where E : unmanaged,Enum
            where W : unmanaged
            where F : IFlags<F,E,W>
        {
            var symbols = Symbols.index<E>();
            var buffer = text.buffer();
            var count = min(symbols.Length, src.DataWidth);
            for(byte i=0; i<count; i++)
            {
                ref readonly var symbol = ref symbols[i];
                var state = src[@as<ulong,W>(Pow2.pow(i))];
                render(symbol, state, buffer, enabledOnly);
            }
            return buffer.ToString();
        }

        [MethodImpl(Inline)]
        static void render<E>(Sym<E> symbol, bit state, ITextBuffer dst, bit enabledOnly)
            where E : unmanaged,Enum
        {
            const string RenderPattern = "{0,-48}: {1}" + Eol;
            if(enabledOnly)
            {
                if(state)
                    dst.AppendFormat(RenderPattern, symbol.Expr, state);
            }
            else
                dst.AppendFormat(RenderPattern, symbol.Expr, state);
        }
    }
}