//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FormatFunction<T> : IFormatter<T>
    {
        readonly FormatterDelegate<T> F;

        [MethodImpl(Inline),Op]
        public FormatFunction(FormatterDelegate<T> f)
        {
            F = f;
        }

        [MethodImpl(Inline),Op]
        public string Format(T src)
            => F(src);

        [MethodImpl(Inline)]
        public static implicit operator FormatFunction<T>(FormatterDelegate<T> src)
            => new FormatFunction<T>(src);
    }
}