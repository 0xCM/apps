//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Lines
    {
        [Op]
        public static string format(in AsciLine src)
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            render(src, ref i, buffer);
            return text.format(buffer);
        }

        [Op]
        public static string format<T>(in AsciLine<T> src)
            where T : unmanaged
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            render(src, ref i, buffer);
            return text.format(buffer);
        }
    }
}