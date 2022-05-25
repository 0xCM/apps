//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        public static SymHeaps SymHeaps(this IWfRuntime wf)
            => Z0.SymHeaps.create(wf);

        public static ApiEmitters ApiEmitters(this IWfRuntime wf)
            => Z0.ApiEmitters.create(wf);

        [Op]
        public static ApiComments ApiComments(this IWfRuntime wf)
            => Z0.ApiComments.create(wf);

        public static ApiServices ApiServices(this IWfRuntime wf)
            => Z0.ApiServices.create(wf);

    }
}