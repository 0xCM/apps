//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static CsLang;

    public static class Svc
    {
        public static AppDb AppDb(this IWfRuntime wf)
            => Z0.AppDb.create(wf);

        public static AppServices AppServices(this IWfRuntime wf)
            => Z0.AppServices.create(wf);

        public static ApiServices ApiServices(this IWfRuntime wf)
            => Z0.ApiServices.create(wf);

        public static AppCmdRunner AppCmdRunner(this IWfRuntime wf)
            => Z0.AppCmdRunner.create(wf);

        public static GStringLits GenLiterals(this IWfRuntime wf)
            => GStringLits.create(wf);

        public static GAsciLookup GenAsciLookups(this IWfRuntime wf)
            => GAsciLookup.create(wf);

        public static GRecord GenRecords(this IWfRuntime wf)
            => GRecord.create(wf);

        public static GLiteralProvider GenLiteralProviders(this IWfRuntime wf)
            => GLiteralProvider.create(wf);

    }
}