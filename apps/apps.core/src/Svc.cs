//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static CsLang;

    public static class Svc
    {
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