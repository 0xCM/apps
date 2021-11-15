//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Tools;

    using Svc = Tools;

    [ApiHost]
    public static partial class XTools
    {
        [Op]
        public static MsDocPipe MsDocs(this IWfRuntime wf)
            => Svc.MsDocPipe.create(wf);
    }
}