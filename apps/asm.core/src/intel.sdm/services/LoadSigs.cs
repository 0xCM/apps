//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<AsmSigExpr> LoadSigs()
        {
            return Data(nameof(LoadSigs), Load);

            Index<AsmSigExpr> Load()
                => ExtractSigs(LoadOcDetails());
        }

        Index<AsmSigExpr> ExtractSigs(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmSigExpr>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = SdmOps.sig(skip(src,i));
            return buffer;
        }
    }
}