//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class AsciLines
    {
        [Op]
        public static uint render(in AsciLine src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            if(src.IsNonEmpty)
                text.render(src.Codes, ref i, dst);
            return i - i0;
        }

        [Op]
        public static uint render(in AsciLine src, Span<char> dst)
        {
            var i = 0u;
            if(src.IsNonEmpty)
                text.render(src.Codes, ref i, dst);
            return i;
        }

        [Op]
        public static uint render<T>(in AsciLine<T> src, ref uint i, Span<char> dst)
            where T : unmanaged
        {
            var i0 = i;
            if(src.IsNonEmpty)
                text.render(recover<T,AsciCode>(src.View), ref i, dst);
            return i - i0;
        }
    }
}