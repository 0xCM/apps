//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct VarSymbol<T> : IVarSymbol<T>
    {
        public T Id {get;}

        [MethodImpl(Inline)]
        public VarSymbol(T id)
            => Id= id;

        public string Name
        {
            [MethodImpl(Inline)]
            get => Id?.ToString() ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => VarSymbol.format(this);

        [MethodImpl(Inline)]
        public string Format(VarContextKind vck)
            => VarSymbol.format(vck, this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator VarSymbol<T>(T id)
            => new VarSymbol<T>(id);
    }
}