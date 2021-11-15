//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;


    public static class XSvc
    {
        [Op]
        public static AsmCmdService AsmCmd(this IWfRuntime context)
            => AsmCmdService.create(context);
    }
}