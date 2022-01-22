//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigModels;
    using static core;

    partial class AsmSigs
    {
        [Op]
        public static AsmSig sig(AsmOpCode opcode, AsmMnemonic mnemonic, params AsmSigOp[] ops)
            => ops.Length switch{
                0 => new AsmSig(opcode, mnemonic),
                1 => new AsmSig(opcode, mnemonic, skip(ops,0)),
                2 => new AsmSig(opcode, mnemonic, skip(ops,0), skip(ops,1)),
                3 => new AsmSig(opcode, mnemonic, skip(ops,0), skip(ops,1), skip(ops,2)),
                4 => new AsmSig(opcode, mnemonic, skip(ops,0), skip(ops,1), skip(ops,2), skip(ops,3)),
                _ => AsmSig.Empty
            };

        [Op, MethodImpl(Inline)]
        public static AsmSig sig(AsmOpCode oc, AsmMnemonic name, GpReg reg0, GpReg reg1)
            => asm.sig(oc,name, reg0, reg1);

        [Op, MethodImpl(Inline)]
        public static AsmSig sig(AsmOpCode oc, AsmMnemonic name, GpReg reg, Imm imm)
            => asm.sig(oc,name, reg, imm);

        [Op, MethodImpl(Inline)]
        public static AsmSig sig(AsmOpCode oc, AsmMnemonic name, Mem mem, GpReg reg)
            => asm.sig(oc,name, mem, reg);

        [Op, MethodImpl(Inline)]
        public static AsmSig sig(AsmOpCode oc, AsmMnemonic name, Mem mem, Imm imm)
            => asm.sig(oc,name, mem, imm);

        [Op, MethodImpl(Inline)]
        public static AsmSig sig(AsmOpCode oc, AsmMnemonic name, GpReg reg, Mem mem)
            => asm.sig(oc,name, reg, mem);

    }
}