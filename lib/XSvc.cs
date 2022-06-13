//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [ApiHost]
    public static partial class XSvc
    {
        [Op]
        public static AppSettings AppSettings(this IWfRuntime wf)
            => Z0.AppSettings.create(wf);

        [Op]
        public static ApiJit ApiJit(this IWfRuntime wf)
            => Z0.ApiJit.create(wf);

        [Op]
        public static ApiQuery ApiQuery(this IWfRuntime wf)
            => Z0.ApiQuery.create(wf);
    }
}