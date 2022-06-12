//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class XAppDb
    {
        const string xed = "xed";

        public static IDbTargets CgStage(this IAppDb db)
            => db.Targets("cgstage");

        public static IDbTargets CgStage(this IAppDb db, string scope)
            => db.Targets($"cgstage/{scope}");

        public static IDbSources IntelSources(this IAppDb db)
            => db.Sources("intel");

        public static IDbTargets IntelTargets(this IAppDb db)
            => db.Targets("intel");

        public static IDbTargets SdeTargets(this IAppDb db)
            => db.Targets().Targets("sde");

        public static IDbTargets LlvmTargets(this IAppDb db)
            => db.Targets("llvm");

        public static IDbSources LlvmSources(this IAppDb db)
            => db.Sources("llvm");

        public static IDbTargets ApiTargets(this IAppDb db, string scope)
            => db.Targets($"api/{scope}");

        public static IDbTargets MsilTargets(this IAppDb db)
            => db.ApiTargets("msil");

        public static IDbTargets MsilTargets(this IAppDb db, string scope)
            => db.ApiTargets($"msil/{scope}");

        public static IDbSources CpuIdSources(this IAppDb db)
            => db.IntelSources().Sources("sde.cpuid");
    }
}