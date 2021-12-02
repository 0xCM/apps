//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using Operands;

    public abstract class AsmRegOpVar<T> : AsmOpVar<T>
        where T : IRegOp
    {
        public AsmRegOpVar(byte index,Func<byte,T> resolver)
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

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmReg8Var : AsmRegOpVar<r8>
    {
        public AsmReg8Var(byte index, Func<byte,r8> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmReg16Var : AsmRegOpVar<r16>
    {
        public AsmReg16Var(byte index, Func<byte,r16> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmReg32Var : AsmRegOpVar<r32>
    {
        public AsmReg32Var(byte index, Func<byte,r32> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmReg64Var : AsmRegOpVar<r64>
    {
        public AsmReg64Var(byte index, Func<byte,r64> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmReg128Var : AsmRegOpVar<xmm>
    {
        public AsmReg128Var(byte index, Func<byte,xmm> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmReg256Var : AsmRegOpVar<ymm>
    {
        public AsmReg256Var(byte index, Func<byte,ymm> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = new AsmOperand(Resolve(seq));
            return ref dst;
        }
    }

    public sealed class AsmReg512Var : AsmRegOpVar<zmm>
    {
        public AsmReg512Var(byte index, Func<byte,zmm> resolver)
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