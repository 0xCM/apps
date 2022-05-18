//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies the origin of a bitfield definition
    /// </summary>
    public readonly record struct BfOrigin<T>
    {
        public readonly T Value;

        readonly Func<T,string> Render;

        [MethodImpl(Inline)]
        public BfOrigin(T value)
        {
            Value = value;
            Render = (T x) => x?.ToString();
        }

        public BfOrigin(T value, Func<T,string> render)
        {
            Value = value;
            Render = render;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Render?.Invoke(Value);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BfOrigin<T>(T src)
            => new BfOrigin<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator BfOrigin(BfOrigin<T> src)
            => new BfOrigin(src.Value, (dynamic x) => src.Render((T)x));
    }
}