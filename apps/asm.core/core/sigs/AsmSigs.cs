//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    [ApiHost]
    public class AsmSigs
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static AsmForm form(in AsmSig sig, in AsmOpCode oc)
        {

            return default;
        }

    }
}