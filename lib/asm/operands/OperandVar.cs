//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class OperandVar<T>
    {
        readonly Func<byte,T> Resolver;

        [MethodImpl(Inline)]
        public OperandVar(byte index, Func<byte,T> resolver)
        {
            Resolver = resolver;
            Index = index;
        }

        public byte Index {get;}

        public T Resolve()
            => Resolver(Index);
    }
}