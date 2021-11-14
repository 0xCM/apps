//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmEncodingCase : ITextual
    {
        [MethodImpl(Inline), Op]
        public static AsmEncodingCase define(AsmMnemonicCode monic, ushort seq, AsmText oc, AsmText sig, AsmText statement, AsmText encoding)
            => new AsmEncodingCase(monic, seq, oc, sig, statement, encoding);

        [MethodImpl(Inline)]
        public static AsmCaseId identify(AsmMnemonicCode monic, ushort seq)
            => (ulong)monic |((ulong)seq << 11);

        public AsmCaseId Id {get;}

        public AsmText OpCode {get;}

        public AsmText Sig {get;}

        public AsmText Statement {get;}

        public AsmText Encoding {get;}

        [MethodImpl(Inline)]
        public AsmEncodingCase(AsmMnemonicCode mnemonic, ushort seq, AsmText oc, AsmText sig, AsmText statement, AsmText code)
        {
            Id= identify(mnemonic, seq);
            OpCode = oc;
            Sig = sig;
            Statement = statement;
            Encoding = code;
        }

        public AsmMnemonicCode Mnemonic
        {
            [MethodImpl(Inline)]
            get => Id.Segment<AsmMnemonicCode>(0,10);
        }
        public string Format()
            => string.Format("{0}[{1:D4}] = <{2}>({3}) {4} => {5}", Mnemonic, Id.Segment<ushort>(11, 16), OpCode, Sig, Statement, Encoding.Format());

        public override string ToString()
            => Format();
    }
}