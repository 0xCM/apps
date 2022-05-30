//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public partial class AsmCases : AppService<AsmCases>
    {
        static SymbolDispenser CaseSymbols;

        static AsmCases()
        {
            CaseSymbols = Alloc.symbols();
        }

        [Op]
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
    }
}