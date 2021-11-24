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
    public readonly struct OpEvaluation : IOpEvaluation
    {
        public IOperation Actor {get;}

        public dynamic Input {get;}

        public dynamic Output {get;}

        [MethodImpl(Inline)]
        public OpEvaluation(IOperation op, dynamic src, dynamic result)
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