//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public partial class AsmCases : AppService<AsmCases>
    {
        static SymbolDispenser CaseSymbols;

        static AsmCases()
        {
            CaseSymbols = Alloc.symbols();
        }
    }
}