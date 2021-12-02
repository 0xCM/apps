//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class AsmOpVar<T> : OperandVar<T>
        where T : IAsmOp
    {
        public AsmOpVar(byte index, Func<byte,T> resolver)
            : base(index,resolver)
        {

        }
    }

    public class AsmRegOpVar<T> : AsmOpVar<T>
        where T : IRegOp
    {
        public AsmRegOpVar(byte index,Func<byte,T> resolver)
            : base(index,resolver)
        {

        }
    }

    public class AsmMemOpVar<T> : AsmOpVar<T>
        where T : IMemOp
    {
        public AsmMemOpVar(byte index,Func<byte,T> resolver)
            : base(index,resolver)
        {

        }
    }

    public class AsmImmOpVar<T> : AsmOpVar<T>
        where T : IImmOp
    {
        public AsmImmOpVar(byte index,Func<byte,T> resolver)
            : base(index,resolver)
        {

        }
    }

    public class AsmImmOpVar : AsmImmOpVar<ImmOp>
    {
        public AsmImmOpVar(byte index,Func<byte,ImmOp> resolver)
            : base(index,resolver)
        {

        }
    }

    public class AsmRegOpVar : AsmRegOpVar<RegOp>
    {
        public AsmRegOpVar(byte index,Func<byte,RegOp> resolver)
            : base(index,resolver)
        {

        }
    }

    public class AsmMemOpVar : AsmMemOpVar<MemOp>
    {
        public AsmMemOpVar(byte index,Func<byte,MemOp> resolver)
            : base(index,resolver)
        {

        }
    }

    public class AsmOpVar : AsmOpVar<AsmOperand>
    {
        public AsmOpVar(byte index,Func<byte,AsmOperand> resolver)
            : base(index,resolver)
        {

        }
    }
}