//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ParseFunction<T> : IParser<T>
    {
        readonly ParserDelegate<T> F;

        [MethodImpl(Inline)]
        public ParseFunction(ParserDelegate<T> f)
            => F = f;

        [MethodImpl(Inline)]
        public Outcome Parse(string src, out T dst)
            => F(src, out dst);
    }
}