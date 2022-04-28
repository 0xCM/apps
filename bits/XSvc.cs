//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        [Op]
        public static BitfieldServices Bitfields(this IWfRuntime wf)
            => Z0.BitfieldServices.create(wf);

        [Op]
        public static BitMaskServices ApiBitMasks(this IWfRuntime wf)
            => Z0.BitMaskServices.create(wf);
    }
}