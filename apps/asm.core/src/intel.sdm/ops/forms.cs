//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct SdmOps
    {
        public static AsmForms forms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var dst = new AsmForms();
            iter(src, d => dst.Include(d));
            return dst;
        }
    }
}