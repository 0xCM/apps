//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct CharBlocks
    {
        [MethodImpl(Inline)]
        public static IParser<T> parser<T>()
            where T : unmanaged, ICharBlock<T>
                => new CharBlockParser<T>();

        public static ref T parse<T>(string src, out T dst)
            where T : unmanaged, ICharBlock<T>
        {
            dst = default;
            Z0.text.copy(src, ref dst);
            return ref dst;
        }

        readonly struct CharBlockParser<T> : IParser<T>
            where T : unmanaged, ICharBlock<T>
        {
            public Outcome Parse(string src, out T dst)
            {
                CharBlocks.init(src, out dst);
                return true;
            }
        }
    }
}