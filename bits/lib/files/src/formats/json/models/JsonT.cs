//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = JsonData;

    public readonly struct Json<T> : ITextual, IJsonSource<Json<T>>
    {
        public T[] Content {get;}

        [MethodImpl(Inline)]
        public Json(T[] src)
            => Content = src;

        [MethodImpl(Inline)]
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public JsonText ToJson()
            => api.jtext(this);

        [MethodImpl(Inline)]
        public static implicit operator Json<T>(T[] src)
            => new Json<T>(src);
    }
}