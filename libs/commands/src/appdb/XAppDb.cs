//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class XAppDb
    {
        const string xed = "xed";

        public static DbTargets CgStage(this IAppDb db)
            => db.Targets("cgstage");

        public static DbTargets CgStage(this IAppDb db, string scope)
            => db.Targets($"cgstage/{scope}");

        public static DbSources IntelSources(this IAppDb db)
            => db.Sources("intel");

        public static DbTargets IntelTargets(this IAppDb db)
            => db.Targets("intel");

        public static DbTargets SdeTargets(this IAppDb db)
            => db.Targets().Targets("sde");

        public static DbTargets LlvmTargets(this IAppDb db)
            => db.Targets("llvm");

        public static DbSources LlvmSources(this IAppDb db)
            => db.Sources("llvm");

        public static DbTargets ApiTargets(this IAppDb db, string scope)
            => db.Targets($"api/{scope}");

        public static DbTargets MsilTargets(this IAppDb db)
            => db.ApiTargets("msil");

        public static DbTargets MsilTargets(this IAppDb db, string scope)
            => db.ApiTargets($"msil/{scope}");

        public static DbSources CpuIdSources(this IAppDb db)
            => db.IntelSources().Scoped("sde.cpuid");
    }
}