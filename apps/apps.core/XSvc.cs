//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public static partial class XSvc
    {
        [Op]
        public static ApiAssets ApiAssets(this IWfRuntime wf)
            => Z0.ApiAssets.create(wf);

        [Op]
        public static ApiComments ApiComments(this IWfRuntime wf)
            => Z0.ApiComments.create(wf);

        public static CsLang CsLang(this IWfRuntime wf)
            => Z0.CsLang.create(wf);

        public static Parsers Parsers(this IWfRuntime wf)
            => Z0.Parsers.create(wf);
    }
}