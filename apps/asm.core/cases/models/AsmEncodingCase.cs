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
        public static AsmEncodingCase define(AsmMnemonic monic, uint seq, ResText oc, ResText sig, ResText statement, ResText encoding)
            => new AsmEncodingCase(monic, seq, oc, sig, statement, encoding);

        public uint Id {get;}

        public AsmMnemonic Mnemonic {get;}

        public ResText OpCode {get;}

        public ResText Sig {get;}

        public ResText Statement {get;}

        public ResText Encoding {get;}

        [MethodImpl(Inline)]
        public AsmEncodingCase(AsmMnemonic mnemonic, uint seq, ResText oc, ResText sig, ResText statement, ResText code)
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