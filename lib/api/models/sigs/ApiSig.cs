//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = ApiSigs;

    public class ApiSig : IEquatable<ApiSig>
    {
        public ApiClass Class {get;}

        public Index<Type> Components {get;}

        [MethodImpl(Inline)]
        public ApiSig(Index<Type> components)
        {
            Class = ApiClass.Empty;
            Components = components;
        }

        [MethodImpl(Inline)]
        public ApiSig(ApiClass @class, Index<Type> components)
        {
            Class = @class;
            Components = components;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public bool Equals(ApiSig src)
            => api.eq(this, src);

        public override int GetHashCode()
            => (int)api.hash(this);

        public override bool Equals(object src)
            => src is ApiSig s && Equals(s);
    }
}