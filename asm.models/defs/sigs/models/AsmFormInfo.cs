//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmFormInfo : ISyntaxPart<AsmFormInfo>
    {
        public AsmOpCodeString OpCode {get;}

        public AsmSigInfo Sig {get;}

        [MethodImpl(Inline)]
        public AsmFormInfo(AsmOpCodeString opcode, AsmSigInfo sig)
        {
            OpCode = opcode;
            Sig = sig;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpCode.IsEmpty || Sig.IsEmpty;
        }

        public TextBlock Content
        {
            [MethodImpl(Inline)]
            get => string.Format("({0})<{1}>", Sig, OpCode);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsmFormInfo src)
            => OpCode == src.OpCode && Sig == src.Sig;

        public override bool Equals(object src)
            => src is AsmFormInfo x && Equals(x);

        public override int GetHashCode()
            => (int)FastHash.combine(OpCode.GetHashCode(), Sig.GetHashCode());

        public string Format()
            => Content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmFormInfo((AsmOpCodeString oc, AsmSigInfo sig) src)
            => new AsmFormInfo(src.oc, src.sig);

        public static AsmFormInfo Empty
            => new AsmFormInfo(AsmOpCodeString.Empty, AsmSigInfo.Empty);
    }
}