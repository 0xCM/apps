//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    partial struct SdmOps
    {
        public static SdmSigDetails sigs(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var dst = new SdmSigDetails();
            iter(src, d => dst.Include(d));
            return dst;
        }
    }
}