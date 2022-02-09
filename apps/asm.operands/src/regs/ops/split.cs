//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmRegs
    {
        [MethodImpl(Inline), Op]
        public static void split(RegKind src, out RegIndexCode c, out RegClassCode k, out NativeSizeCode w)
        {
            c = index(src);
            k = @class(src);
            w = width(src);
        }
    }
}