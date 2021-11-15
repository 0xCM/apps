//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigs
    {
        [Op]
        public static void decompose(GpRmToken src, out GpRegToken gp, out MemToken m)
        {
            gp = default;
            m = default;
            switch(src)
            {
                case GpRmToken.r:
                    gp = GpRegToken.reg;
                break;
                case GpRmToken.rm8:
                    gp = GpRegToken.r8;
                    m = MemToken.m8;
                break;
                case GpRmToken.rm16:
                    gp = GpRegToken.r16;
                    m = MemToken.m16;
                break;
                case GpRmToken.rm32:
                    gp = GpRegToken.r32;
                    m = MemToken.m32;
                break;
                case GpRmToken.rm64:
                    gp = GpRegToken.r64;
                    m =  MemToken.m64;
                break;
            }
        }
    }
}