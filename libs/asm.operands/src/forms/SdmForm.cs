//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SdmForm : IComparable<SdmForm>
    {
        public static SdmForm define(in AsmSig sig, in SdmOpCode opcode)
            => new SdmForm(text47.Empty,sig, opcode);

        public static SdmForm define(in text47 name, in AsmSig sig, in SdmOpCode opcode)
            => new SdmForm(name, sig, opcode);

        public readonly text47 Name;

        public readonly AsmSig Sig;

        public readonly SdmOpCode OpCode;

        [MethodImpl(Inline)]
        public SdmForm(text47 name, AsmSig sig, SdmOpCode oc)
        {
            Name = name;
            Sig = sig;
            OpCode = oc;
        }

        public Hex32 Id
            => alg.hash.calc(Format());

        [MethodImpl(Inline)]
        public SdmForm WithName(in text47 name)
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

        public int CompareTo(SdmForm src)
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

        public static SdmForm Empty => default;
    }
}