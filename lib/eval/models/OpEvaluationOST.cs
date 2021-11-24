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

    /// <summary>
    /// Defines an evaulation which is, byt definition, the triple (O,S,T)
    /// where O is an operation type, S is an input type and T is type of value produce
    /// when an O value is applied to an S value
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct OpEvaluation<O,S,T> : IOpEvaluation<O,S,T>
        where O : IOperation
    {
        public O Actor {get;}

        public S Input {get;}

        public T Output {get;}

        [MethodImpl(Inline)]
        public OpEvaluation(O op, S src, T result)
        {
            Actor = op;
            Input = src;
            Output = result;
        }

        public string Format()
            => eval.format(this);

        public override string ToString()
            => Format();
    }
}