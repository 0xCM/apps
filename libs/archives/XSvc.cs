//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {

        [Op]
        public static AppSettings AppSettings(this IWfRuntime wf)
            => Z0.AppSettings.create(wf);

   }
}