//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct OpEvaluation<S,T> : IOpEvaluation<S,T>
    {
        public IOperation Actor {get;}

        public S Input {get;}

        public T Output {get;}

        [MethodImpl(Inline)]
        public OpEvaluation(IOperation actor, S src, T result)
        {
            Actor = actor;
            Input = src;
            Output = result;
        }

        public string Format()
            => eval.format(this);

        public override string ToString()
            => Format();
    }
}