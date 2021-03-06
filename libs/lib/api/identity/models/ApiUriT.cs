//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiUri<T> : IApiUri<ApiUri<T>>
    {
        readonly public T Value {get;}

        public string UriText
        {
            [MethodImpl(Inline)]
            get => Value?.ToString() ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(UriText);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(UriText);
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