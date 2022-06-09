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
            AsmOpCodes.parse(oc.Format(), out dst.OpCode);
            AsmHexCode.parse(encoding.Format(), out dst.Encoding);
            AsmSigs.parse(sig.Format(), out dst.Sig);
            dst.Asm = statement.Format();
            return dst;
        }
    }
}