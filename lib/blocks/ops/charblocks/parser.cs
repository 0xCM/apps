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

        readonly struct CharBlockParser<T> : IParser<T>
            where T : unmanaged, ICharBlock<T>
        {
            public Outcome Parse(string src, out T dst)
            {
                dst = default;
                CharBlocks.init(src, out dst);
                return true;
            }
        }
    }
}