//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    [ApiHost]
    public static class XSvc
    {
        [Op]
        public static ApiResolver ApiResolver(this IWfRuntime wf)
            => Z0.ApiResolver.create(wf);
    }
}