//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    [ApiHost]
    public partial class AsmSigs : Service<AsmSigs>
    {
        public AsmSigs()
        {

        }

        const NumericKind Closure = UnsignedInts;
    }
}