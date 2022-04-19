//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        [Op]
        public static ApiComments ApiComments(this IWfRuntime wf)
            => Z0.ApiComments.create(wf);

    }
}

