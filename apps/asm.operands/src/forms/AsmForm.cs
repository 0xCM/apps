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
            => new AsmForm(text47.Empty,sig, opcode);

        public static AsmForm define(in text47 name, in AsmSig sig, in AsmOpCode opcode)
            => new AsmForm(name, sig, opcode);

        public readonly text47 Name;
        public readonly AsmSig Sig;

        public readonly AsmOpCode OpCode;

        [MethodImpl(Inline)]
        public AsmForm(text47 name, AsmSig sig, AsmOpCode oc)
        {
            Name = name;
            Sig = sig;
            OpCode = oc;
        }

        public Hex32 Id
            => alg.hash.calc(Format());

        [MethodImpl(Inline)]
        public AsmForm WithName(in text47 name)
            => define(name, Sig, OpCode);

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