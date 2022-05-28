//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class XAppDb
    {
        public static DbTargets Logs(this AppDb db)
            => db.Targets("logs");

        public static DbTargets CgStage(this AppDb db)
            => db.Targets("cgstage");

        public static DbTargets CgStage(this AppDb db, string scope)
            => db.Targets($"cgstage/{scope}");

        public static DbSources IntelSources(this AppDb db)
            => db.Sources("intel");

        public static DbTargets IntelTargets(this AppDb db)
            => db.Targets("intel");

        public static DbTargets SdeTargets(this AppDb db)
            => db.Targets().Targets("sde");

        public static DbTargets LlvmTargets(this AppDb db)
            => db.Targets("llvm");

        public static DbSources LlvmSources(this AppDb db)
            => db.Sources("llvm");

        public static DbTargets ApiTargets(this AppDb db)
            => db.Targets("api");

        public static DbTargets ApiTargets(this AppDb db, string scope)
            => db.Targets($"api/{scope}");

        public static DbTargets MsilTargets(this AppDb db)
            => db.ApiTargets("msil");

        public static DbTargets MsilTargets(this AppDb db, string scope)
            => db.ApiTargets($"msil/{scope}");

        public static DbSources CpuIdSources(this AppDb db)
            => db.IntelSources().Scoped("sde.cpuid");

        public static DbSources IntelNotationDocs(this AppDb db)
            => db.IntelSources().Scoped("notation");

        public static DbSources IntelEncodingDocs(this AppDb db)
            => db.IntelSources().Scoped("encoding");

        public static DbSources MsSources(this AppDb db)
            => db.Sources("ms");
    }
}