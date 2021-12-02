//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public abstract class AsmImmOpVar<T> : AsmOpVar<T>
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

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmImm8Var : AsmImmOpVar<imm8>
    {
        public AsmImm8Var(byte index,Func<byte,imm8> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmImm16Var : AsmImmOpVar<imm16>
    {
        public AsmImm16Var(byte index,Func<byte,imm16> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(base.Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmImm32Var : AsmImmOpVar<imm32>
    {
        public AsmImm32Var(byte index,Func<byte,imm32> resolver)
            : base(index,resolver)
        {
        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }

    }

    public sealed class AsmImm64Var : AsmImmOpVar<imm64>
    {
        public AsmImm64Var(byte index,Func<byte,imm64> resolver)
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