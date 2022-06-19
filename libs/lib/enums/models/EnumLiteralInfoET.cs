//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EnumLiteralInfo<E,T>
        where E : unmanaged, Enum
        where T : unmanaged
    {
        public CliToken Token {get;}

        public uint Position {get;}

        public Name Name {get;}

        public E Literal {get;}

        public T Scalar {get;}

        [MethodImpl(Inline)]
        public EnumLiteralInfo(CliToken id, uint index, string name, E literal, T scalar)
        {
            Token = id;
            Position = index;
            Name = name;
            Literal = literal;
            Scalar = scalar;
        }
    }
}