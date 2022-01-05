//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsmSyntaxModel
    {
        public struct Operand<K,T> : IOperand<K,T>
            where K : unmanaged
            where T : unmanaged
        {
            public K Kind {get;}

            public T Value {get;}

            [MethodImpl(Inline)]
            public Operand(K kind, T value)
            {
                Kind = kind;
                Value = value;
            }
        }
    }
}