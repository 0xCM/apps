//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct VarResolver<T> : IVarResolver<T>
    {
        readonly Func<Label,T> Emitter;

        [MethodImpl(Inline)]
        public VarResolver(Func<Label,T> f)
        {
            Emitter = f;
        }

        [MethodImpl(Inline)]
        public Value<T> Resolve(IVar<T> var)
            => Emitter(var.Name);

        Value<dynamic> IVarResolver.Resolve(IVar var)
            => new Value<dynamic>(Emitter(var.Name));

        [MethodImpl(Inline)]
        public static implicit operator VarResolver<T>(Func<Label,T> f)
            => new VarResolver<T>(f);
    }
}