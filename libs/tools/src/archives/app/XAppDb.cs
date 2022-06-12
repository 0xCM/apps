//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class XAppDb
    {
        public static IDbTargets CgStage(this IAppDb db)
            => db.DbTargets("cgstage");

        public static IDbTargets CgStage(this IAppDb db, string scope)
            => db.DbTargets($"cgstage/{scope}");

        public static IDbSources IntelSources(this IAppDb db)
            => db.DbSources("intel");

        public static IDbTargets IntelTargets(this IAppDb db)
            => db.DbTargets("intel");

        public static IDbTargets SdeTargets(this IAppDb db)
            => db.DbTargets().Targets("sde");

        public static IDbTargets LlvmTargets(this IAppDb db)
            => db.DbTargets("llvm");

        public static IDbSources LlvmSources(this IAppDb db)
            => db.DbSources("llvm");

        public static IDbTargets ApiTargets(this IAppDb db, string scope)
            => db.DbTargets($"api/{scope}");

        public static IDbTargets MsilTargets(this IAppDb db)
            => db.ApiTargets("msil");

        public static IDbTargets MsilTargets(this IAppDb db, string scope)
            => db.ApiTargets($"msil/{scope}");

        public static IDbSources CpuIdSources(this IAppDb db)
            => db.IntelSources().Sources("sde.cpuid");
    }
}