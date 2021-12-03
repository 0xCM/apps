//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static minicore;

    public readonly struct ApiClass<K> : ITextual
        where K : unmanaged, IApiClass<K>
    {
        readonly K Kind;

        [MethodImpl(Inline)]
        public ApiClass(K kind)
            => Kind = kind;

        [MethodImpl(Inline)]
        public static implicit operator ApiClass<K>(K src)
            => new ApiClass<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiClass(ApiClass<K> src)
            => new ApiClass(@as<K,ApiClassKind>(src.Kind));

        public string Format()
            => Kind.Format();

        public override string ToString()
            => Format();
    }
}