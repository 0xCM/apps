//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static CsLang;

    public static class XAppDb
    {
        public static DbTargets Logs(this AppDb db)
            => db.Targets("logs");

        public static DbTargets CgStage(this AppDb db)
            => db.Targets("cgstage");

        public static DbSources IntelSources(this AppDb db)
            => db.Sources("intel");

        public static DbTargets IntelTargets(this AppDb db)
            => db.Targets("intel");

        public static DbTargets SdeTargets(this AppDb db)
            => db.IntelTargets().Targets("sde");

        public static DbTargets LlvmTargets(this AppDb db)
            => db.Targets("llvm");

        public static DbSources LlvmSources(this AppDb db)
            => db.Sources("llvm");

        public static DbTargets ApiTargets(this AppDb db)
            => db.Targets("api");

        public static DbSources CpuIdSources(this AppDb db)
            => db.IntelSources().Scoped("sde.cpuid");

        public static DbSources IntelNotationDocs(this AppDb db)
            => db.IntelSources().Scoped("notation");

        public static DbSources IntelEncodingDocs(this AppDb db)
            => db.IntelSources().Scoped("encoding");

        public static DbSources MsSources(this AppDb db)
            => db.Sources("ms");
    }


    public static class Svc
    {
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