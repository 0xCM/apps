//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Just one, neither more nor less
    /// </summary>
    public readonly struct Single<T>
    {
        public T Element {get;}

        [MethodImpl(Inline)]
        public Single(T src)
            => Element = src;

        public Label Name 
            => "single<{0}>";

        [MethodImpl(Inline)]
        public static implicit operator Single<T>(T src)
            => new Single<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Single(Single<T> src)
            => new Single(src.Element);
    }    
}