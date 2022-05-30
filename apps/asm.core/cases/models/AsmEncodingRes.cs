//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmEncodingRes
    {
        public readonly AsmMnemonic Mnemonic;

        public readonly ResText OpCode;

        public readonly ResText Sig;

        public readonly ResText Statement;

        public readonly ResText Encoding;

        [MethodImpl(Inline)]
        public AsmEncodingRes(AsmMnemonic mnemonic, ResText oc, ResText sig, ResText statement, ResText code)
        {
            Mnemonic = mnemonic;
            OpCode = oc;
            Sig = sig;
            Statement = statement;
            Encoding = code;
        }

        public string Format()
            => string.Format("{0}[{1}] {2} => {3}", Mnemonic, OpCode, Statement, Encoding.Format());

        public override string ToString()
            => Format();
    }
}