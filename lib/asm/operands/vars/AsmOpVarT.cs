//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class AsmOpVar<F,T> : IAsmOpVar<F,T>
        where F : AsmOpVar<F,T>
        where T : struct, IAsmOp
    {
        public VarSymbol Name {get;}

        public T Value {get; protected set;}

        protected AsmOpVar(VarSymbol name)
        {
            Name = name;
            Value = default;
        }

        protected AsmOpVar(VarSymbol name, T value)
        {
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public F Set(T value)
        {
            Value = value;
            return (F)this;
        }


        public AsmOpClass OpClass => Value.OpClass;

        public NativeSize Size => Value.Size;
    }
}