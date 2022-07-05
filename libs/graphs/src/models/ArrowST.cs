//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Arrow<S,T> : IArrow<S,T>
    {
        /// <summary>
        /// The source
        /// </summary>
        public readonly S Source;

        /// <summary>
        /// The target
        /// </summary>
        public readonly T Target;

        [MethodImpl(Inline)]
        public Arrow(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public string IdentityText
        {
            [MethodImpl(Inline)]
            get => string.Format(RpOps.Arrow, Source, Target);
        }

        S IArrow<S,T>.Source
            => Source;

        T IArrow<S,T>.Target
            => Target;

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