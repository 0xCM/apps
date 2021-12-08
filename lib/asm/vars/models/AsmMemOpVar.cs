//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using Operands;

    public abstract class AsmMemOpVar<T> : AsmOpVar<T>
        where T : IMemOp
    {
        public AsmMemOpVar(byte index, Func<byte,T> resolver)
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

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(base.Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmMem8Var : AsmMemOpVar<m8>
    {
        public AsmMem8Var(byte index, Func<byte,m8> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(base.Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmMem16Var : AsmMemOpVar<m16>
    {
        public AsmMem16Var(byte index, Func<byte,m16> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(base.Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmMem32Var : AsmMemOpVar<m32>
    {
        public AsmMem32Var(byte index, Func<byte,m32> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmMem64Var : AsmMemOpVar<m64>
    {
        public AsmMem64Var(byte index, Func<byte,m64> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmMem128Var : AsmMemOpVar<m128>
    {
        public AsmMem128Var(byte index, Func<byte,m128> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmMem256Var : AsmMemOpVar<m256>
    {
        public AsmMem256Var(byte index, Func<byte,m256> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmMem512Var : AsmMemOpVar<m512>
    {
        public AsmMem512Var(byte index, Func<byte,m512> resolver)
             : base(index,resolver)
       {

       }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }
}