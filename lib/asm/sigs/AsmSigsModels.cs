//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    [ApiHost]
    public partial class AsmSigModels : Service<AsmSigModels>
    {
        public AsmSigModels()
        {

        }

        const NumericKind Closure = UnsignedInts;
    }
}