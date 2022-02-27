//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial struct XedModels
    {
        partial struct RuleStateCalcs
        {
            [MethodImpl(Inline), Op]
            public static bool sib(in FieldState src, out Sib dst)
            {
                if(src.HAS_SIB)
                {
                    dst = Sib.init();
                    dst.Base = src.SIBBASE;
                    dst.Index = src.SIBINDEX;
                    dst.Scale = src.SIBSCALE;
                    return true;
                }
                else
                {
                    dst = Sib.Empty;
                    return false;
                }
            }
        }
    }
}