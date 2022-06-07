//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = JsonData;

    public readonly struct Json<T> : IJsonSource<Json<T>>
    {
        public readonly T[] Content {get;}

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