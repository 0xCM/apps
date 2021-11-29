//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Arrow<T> : IArrow<T>
    {
        public T Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public Arrow(T src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public string IdentityText
        {
            [MethodImpl(Inline)]
            get => string.Format(RP.Arrow, Source, Target);
        }

        public string Format()
            => IdentityText;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Arrow<T>((T src, T dst) x)
            => new Arrow<T>(x.src,x.dst);

        [MethodImpl(Inline)]
        public static implicit operator (T src, T dst)(Arrow<T> a)
            => (a.Source, a.Target);
    }
}