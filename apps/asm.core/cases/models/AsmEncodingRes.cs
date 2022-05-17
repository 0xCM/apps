//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmEncodingRes
    {
        public static AsmEncodingCase @case(uint seq, AsmMnemonic monic, ResText oc, ResText sig, ResText statement, ResText encoding)
        {
            var dst = AsmEncodingCase.Empty;
            dst.Seq = seq;
            dst.Mnemonic = monic;
            AsmParser.parse(oc.Format(), out dst.OpCode);
            AsmParser.parse(encoding.Format(), out dst.Encoding);
            AsmParser.parse(sig.Format(), out dst.Sig);
            dst.Asm = statement.Format();
            AsmParser.parse(encoding.Format(), out dst.Encoding);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsmEncodingRes resource(AsmMnemonic monic, ResText oc, ResText sig, ResText statement, ResText encoding)
            => new AsmEncodingRes(monic, oc, sig, statement, encoding);

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