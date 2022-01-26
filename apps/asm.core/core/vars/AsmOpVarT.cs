//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class AsmOpVar<T> : IAsmOpVar<T>
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
        public void Update(T value)
        {
            Value = value;
        }

        public AsmOpClass OpClass => Value.OpClass;

        public NativeSize Size => Value.Size;
    }
}