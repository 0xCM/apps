//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        [MethodImpl(Inline), Op]
        public static bool sib(in OpState src, out Sib dst)
        {
            if(src.has_sib)
            {
                dst = Sib.init();
                dst.Base = src.sibbase;
                dst.Index = src.sibindex;
                dst.Scale = src.sibscale;
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