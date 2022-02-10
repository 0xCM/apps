//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public partial class AsmSigSvc : AppService<AsmSigSvc>
    {
        const NumericKind Closure = UnsignedInts;

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        public Outcome Parse(string src, out AsmSig dst)
            => AsmSigs.parse(src, out dst);
    }
}