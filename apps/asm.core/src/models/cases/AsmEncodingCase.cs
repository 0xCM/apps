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
        public static AsmEncodingCase define(AsmMnemonic monic, ushort seq, AsmText oc, AsmText sig, AsmText statement, AsmText encoding)
            => new AsmEncodingCase(monic, seq, oc, sig, statement, encoding);

        public ushort Id {get;}

        public AsmMnemonic Mnemonic {get;}

        public AsmText OpCode {get;}

        public AsmText Sig {get;}

        public AsmText Statement {get;}

        public AsmText Encoding {get;}

        [MethodImpl(Inline)]
        public AsmEncodingCase(AsmMnemonic mnemonic, ushort seq, AsmText oc, AsmText sig, AsmText statement, AsmText code)
        {
            Id= seq;
            Mnemonic = mnemonic;
            OpCode = oc;
            Sig = sig;
            Statement = statement;
            Encoding = code;
        }

        public string Format()
            => string.Format("{0}[{1:D4}] = <{2}>({3}) {4} => {5}", Mnemonic, Id, OpCode, Sig, Statement, Encoding.Format());

        public override string ToString()
            => Format();
    }
}