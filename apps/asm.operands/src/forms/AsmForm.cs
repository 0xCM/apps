//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AsmForm : IComparable<AsmForm>
    {
        public static AsmForm define(in AsmSig sig, in AsmOpCode opcode)
            => new AsmForm(sig, opcode);

        public readonly AsmSig Sig;

        public readonly AsmOpCode OpCode;

        [MethodImpl(Inline)]
        public AsmForm(AsmSig sig, AsmOpCode oc)
        {
            Sig = sig;
            OpCode = oc;
        }

        public Hex32 Id
            => alg.hash.combine(Sig.Hash, OpCode.Hash);

        public AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => Sig.Mnemonic;
        }

        public byte OpCount
        {
            [MethodImpl(Inline)]
            get => Sig.OpCount;
        }

        public AsmSigOps Operands
        {
            [MethodImpl(Inline)]
            get => Sig.Operands;
        }

        public int CompareTo(AsmForm src)
        {
            var result = Sig.CompareTo(src.Sig);
            if(result == 0)
                result = OpCode.Format().CompareTo(src.OpCode.Format());
            return result;
        }

        public string Format()
            => string.Format("{0,-48} | {1}", Sig, OpCode);

        public override string ToString()
            => Format();

        public static AsmForm Empty => default;
    }
}