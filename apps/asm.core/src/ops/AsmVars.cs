//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static AsmOperands;

    public interface IAsmVar
    {
        IAsmOp Bind();

        AsmOpClass OpClass {get;}
    }

    public interface IAsmVar<T> : IAsmVar
        where T : IAsmOp
    {
        new T Bind();

        IAsmOp IAsmVar.Bind()
            => Bind();
    }

    public interface IAsmRegVar : IAsmVar
    {
        AsmOpClass IAsmVar.OpClass
            => AsmOpClass.R;
    }

    public interface IAsmRegVar<T> : IAsmRegVar, IAsmVar<T>
        where T : IRegOp
    {

    }

    public interface IAsmImmVar : IAsmVar
    {
        AsmOpClass IAsmVar.OpClass
            => AsmOpClass.Imm;

    }

    public interface IAsmImmVar<T> : IAsmImmVar, IAsmVar<T>
        where T : IImm
    {

    }

    public interface IAsmMemVar : IAsmVar
    {
        AsmOpClass IAsmVar.OpClass
            => AsmOpClass.M;
    }

    public interface IAsmMemVar<T> : IAsmMemVar, IAsmVar<T>
        where T : IMemOp
    {

    }

    public readonly struct AsmVars
    {


    }

    public abstract class AsmVar
    {
        public NativeSize Size {get;}

        protected AsmVar(NativeSize size)
        {

        }

    }

    public abstract class AsmVar<T> : AsmVar
        where T : IAsmOp
    {
        protected AsmVar(NativeSize size)
            : base(size)
        {

        }

    }

    public abstract class AsmImmVar<T> : AsmVar<T>
        where T : IImmOp
    {
        protected AsmImmVar(NativeSize size)
            : base(size)
        {

        }

    }

    public abstract class AsmRegVar<T> : AsmVar<T>
        where T : IRegOp
    {

        protected AsmRegVar(NativeSize size)
            : base(size)
        {

        }

    }

    public abstract class AsmMemVar<T> : AsmVar<T>
        where T : IMemOp
    {

        protected AsmMemVar(NativeSize size)
            : base(size)
        {

        }

    }

    public sealed class AsmMem8Var : AsmMemVar<m8>
    {
        public AsmMem8Var()
            : base(asm.asmsize(8))
        {

        }
    }

    public sealed class AsmMem16Var : AsmMemVar<m16>
    {
        public AsmMem16Var()
            : base(asm.asmsize(16))
        {

        }

    }

    public sealed class AsmMem32Var : AsmMemVar<m32>
    {
        public AsmMem32Var()
            : base(asm.asmsize(32))
        {

        }
    }

    public sealed class AsmMem64Var : AsmMemVar<m64>
    {
        public AsmMem64Var()
            : base(asm.asmsize(64))
        {

        }

    }

    public sealed class AsmMem128Var : AsmMemVar<m128>
    {
        public AsmMem128Var()
            : base(asm.asmsize(128))
        {

        }

    }

    public sealed class AsmMem256Var : AsmMemVar<m256>
    {
        public AsmMem256Var()
            : base(asm.asmsize(256))
        {

        }

    }

    public sealed class AsmMem512Var : AsmMemVar<m512>
    {
        public AsmMem512Var()
            : base(asm.asmsize(512))
        {

        }

    }

    public sealed class AsmReg8Var : AsmRegVar<r8>
    {
        public AsmReg8Var()
            : base(asm.asmsize(8))
        {

        }

    }

    public sealed class AsmReg16Var : AsmRegVar<r16>
    {
        public AsmReg16Var()
            : base(asm.asmsize(16))
        {

        }

    }

    public sealed class AsmReg32Var : AsmRegVar<r32>
    {
        public AsmReg32Var()
            : base(asm.asmsize(32))
        {

        }

    }

    public sealed class AsmReg64Var : AsmRegVar<r64>
    {
        public AsmReg64Var()
            : base(asm.asmsize(64))
        {

        }

    }

    public sealed class AsmReg128Var : AsmRegVar<xmm>
    {
        public AsmReg128Var()
            : base(asm.asmsize(128))
        {

        }

    }

    public sealed class AsmReg256Var : AsmRegVar<ymm>
    {
        public AsmReg256Var()
            : base(asm.asmsize(256))
        {

        }

    }

    public sealed class AsmReg512Var : AsmRegVar<zmm>
    {
        public AsmReg512Var()
            : base(asm.asmsize(512))
        {

        }
    }


    public sealed class AsmImm8Var : AsmImmVar<imm8>
    {
        public AsmImm8Var()
            : base(asm.asmsize(8))
        {

        }
    }

    public sealed class AsmImm16Var : AsmImmVar<imm16>
    {
        public AsmImm16Var()
            : base(asm.asmsize(16))
        {

        }

    }

    public sealed class AsmImm32Var : AsmImmVar<imm32>
    {
        public AsmImm32Var()
            : base(asm.asmsize(32))
        {

        }

    }

    public sealed class AsmImm64Var : AsmImmVar<imm64>
    {
        public AsmImm64Var()
            : base(asm.asmsize(64))
        {

        }
    }
}