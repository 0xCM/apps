//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataType("arrow<s:{0},t:{1}>")]
    public readonly struct Arrow<S,T> : IArrow<S,T>
    {
        public S Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public Arrow(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public string IdentityText
        {
            [MethodImpl(Inline)]
            get => string.Format(RP.Arrow, Source, Target);
        }

        [MethodImpl(Inline)]
        public string Format()
            => IdentityText;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Arrow<S,T>((S src, T dst) x)
            => new Arrow<S,T>(x.src, x.dst);

        [MethodImpl(Inline)]
        public static implicit operator (S src, T dst)(Arrow<S,T> a)
            => (a.Source, a.Target);
    }
}