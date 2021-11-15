//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeIdentityProvider : ITypeIdentityProvider
    {
        readonly Func<Type,TypeIdentity> Fx;

        [MethodImpl(Inline)]
        public TypeIdentityProvider(Func<Type,TypeIdentity> f)
            => Fx = f;

        [MethodImpl(Inline)]
        public TypeIdentity Identify(Type src)
            => Fx(src);
    }
}