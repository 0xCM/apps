//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiUri<T> : IApiUri<ApiUri<T>>
    {
        public T Value {get;}

        public string UriText
        {
            [MethodImpl(Inline)]
            get => Value?.ToString() ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public ApiUri(T value)
            => Value = value;

        [MethodImpl(Inline)]
        public string Format()
            => UriText;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ApiUri<T>(T src)
            => new ApiUri<T>(src);
    }
}