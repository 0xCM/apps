//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class NaturalType : IType
    {
        public ulong Value {get;}

        [MethodImpl(Inline)]
        public NaturalType(ulong value)
        {
            Value = value;
        }

        public TypeSpec Spec
            => TypeSyntax.nat(Value);

        public Identifier Name
            => Value.ToString();

        public string Format()
            => Name;

        public override string ToString()
            => Format();
    }
}