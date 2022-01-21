//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct SdmSigOpCode : IEquatable<SdmSigOpCode>, IComparable<SdmSigOpCode>
    {
        public AsmSigExpr Sig;

        public AsmOpCode OpCode;

        [MethodImpl(Inline)]
        public SdmSigOpCode(AsmSigExpr sig, AsmOpCode oc)
        {
            Sig = sig;
            OpCode = oc;
        }

        public AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => Sig.Mnemonic;
        }

        public string Text
            => string.Format("{0} {1}", Sig, OpCode);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.marvin(Text);
        }

        public string Format()
            => Text;

        public int CompareTo(SdmSigOpCode src)
            =>  Text.CompareTo(src.Text);

        public bool Equals(SdmSigOpCode src)
            => Text.Equals(src.Text);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object obj)
            => obj is SdmSigOpCode x && Equals(x);

    }
}